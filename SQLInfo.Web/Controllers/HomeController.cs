﻿using SQLInfo.Business;
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
    public class HomeController : Controller
    {
        DatabaseBusinessLogic dataLogic = new DatabaseBusinessLogic();
        UserBusinessLogic userLogic = new UserBusinessLogic();
        // GET: Home
        public ActionResult Index()
        {
            //var dbServer = dataLogic.GetDatabase(1);
            //var dblist = dataLogic.GetAllDatabases(dbServer);
            return View();
        }

        public JsonResult GetRoot(int id = 0, string name = "", int level = 0,string pname="", int rootid = 0)
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
                        isParent = true,
                        rootid = id,
                        pName = pname
                    };
                }).ToList();
                return Json(nodes, JsonRequestBehavior.AllowGet);
            }
            else if (level == 0)
            {
                var dbServer = dataLogic.GetDatabase(id);
                var dblist = dataLogic.GetAllDatabases(dbServer);
                var nodes = dblist.Select(u =>
                {
                    int index = 1;
                    return new ParentTreeNode()
                    {
                        id = Convert.ToInt32(string.Format("{0}00{1}", id, index++)),
                        name = u,
                        pId = id,
                        isParent = true,
                        open = true,
                        rootid = dbServer.ID,
                        pName = pname
                    };
                }).ToList();
                return Json(nodes, JsonRequestBehavior.AllowGet);
            }
            else if (level == 1)
            {
                var dbServer = dataLogic.GetDatabase(rootid);
                var tables = dataLogic.GetAllTables(dbServer, name);
                var tableNodes = tables.Select(u =>
                {
                    return new TreeNode()
                    {
                        pId = id,
                        name = u,
                        id = 0,
                        rootid = rootid,
                        pName = pname
                    };
                });
                return Json(tableNodes, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        [HttpPost]
        public ActionResult TableDetail(int serverid,string dbName,string tableName)
        {
            var dbServer = dataLogic.GetDatabase(serverid);
            var tableDetails = dataLogic.GetTableDetail(dbServer, dbName, tableName);
            ViewBag.TableName = tableName;
            ViewBag.DbName = dbName;
            return View(tableDetails);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginModel model)
        {
            var userinfo = userLogic.GetUserInfo(model.UserName,model.Password);
            if(userinfo!=null)
            {
                var user = new UserInfo(userinfo.ID, userinfo.UserName);
                UserInfo.SaveToSession(user);
                return RedirectToAction("AdminIndex","Admin",null);
            }
            return View();
        }

        
        
    }
}