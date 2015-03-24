using SQLInfo.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQLInfo.Web.Models
{
    public class DbServerModel
    {
        public int ID
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Required(ErrorMessage="必填")]
        public string Server
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "必填")]
        public string Admin
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "必填")]
        public string Password
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public DbType DbType
        {
            get;
            set;
        }
    }
}