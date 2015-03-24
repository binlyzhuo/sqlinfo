using SQLInfo.Business;
using SQLInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQLInfo.Web.Controllers
{
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
    }
}