using SQLInfo.Business;
using SQLInfo.Model;
using SQLInfo.ViewModel;
using SQLInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQLInfo.Web.Controllers
{
    [IsLogin]
    public class AdminController : Controller
    {
        // GET: Admin
        DatabaseBusinessLogic dataLogic = new DatabaseBusinessLogic();
        UserBusinessLogic userLogic = new UserBusinessLogic();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DeleteDbServer(int id)
        {
            JsonViewResult jsonViewResult = new JsonViewResult() { Success = false };
            jsonViewResult.Success=dataLogic.DeleteDbServer(id);
            return Json(jsonViewResult,JsonRequestBehavior.AllowGet);

        }

        public ActionResult AddServer()
        {
            //DbServerModel
            return View();
        }

        [HttpPost]
        public ActionResult AddServer(DbServerModel model)
        {
            //DbServerModel
            if (!ModelState.IsValid)
            {
                return View();
            }
            T_Database dbServer = new T_Database();
            dbServer.Server = model.Server;
            dbServer.Admin = model.Admin;
            dbServer.Password = model.Password;
            dbServer.DbType = (int)model.DbType;

            dataLogic.AddDbServer(dbServer);

            return RedirectToAction("AddServer");
        }

        public ActionResult AdminIndex()
        {
            var dataServers = dataLogic.GetAllServers();
            return View(dataServers);
        }

        public ActionResult Logout()
        {
            UserInfo.ClearUserInfo();
            return RedirectToAction("index","home",null);
        }
    }
}