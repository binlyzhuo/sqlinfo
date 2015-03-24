using SQLInfo.Business;
using SQLInfo.ViewModel;
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

        public JsonResult GetRoot(int id = 0, string name = "", int level = 0,int rootid=0)
        {
            if (id == 0)
            {
                var dbServers = dataLogic.GetAllServers();
                List<ParentTreeNode> nodes = dbServers.Select(u =>
                {
                    return new ParentTreeNode()
                    {
                        id = u.ID,
                        name = u.Server,
                        open = true,
                        pId = 0,
                        isParent = true, rootid = id
                    };
                }).ToList();
                return Json(nodes, JsonRequestBehavior.AllowGet);
            }
            else if(level==0)
            {
                var dbServer = dataLogic.GetDatabase(id);
                var dblist = dataLogic.GetAllDatabases(dbServer);
                var nodes = dblist.Select(u =>
                {
                    int index = 1;
                    return new ParentTreeNode()
                    {
                        id =Convert.ToInt32(string.Format("{0}00{1}",id,index++)),
                        name = u,
                        pId = id,
                        isParent = true,
                        open = true,rootid=dbServer.ID
                    };
                }).ToList();
                return Json(nodes, JsonRequestBehavior.AllowGet);
            }
            else if(level==1)
            {
                var dbServer = dataLogic.GetDatabase(rootid);
                var tables = dataLogic.GetAllTables(dbServer,name);
                var tableNodes = tables.Select(u => {
                    return new TreeNode() { 
                     pId = id, name = u, id = 0, rootid = rootid
                    };
                });
                return Json(tableNodes, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}