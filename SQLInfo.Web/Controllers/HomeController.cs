using SQLInfo.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQLInfo.Web.Controllers
{
    public class HomeController : Controller
    {
        DatabaseBusinessLogic dataLogic = new DatabaseBusinessLogic();
        // GET: Home
        public ActionResult Index()
        {
            var dbServer = dataLogic.GetDatabase(1);
            var dblist = dataLogic.GetAllDatabases(dbServer);
            return View();
        }
    }
}