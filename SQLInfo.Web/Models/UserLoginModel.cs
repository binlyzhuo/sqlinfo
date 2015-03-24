using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SQLInfo.Web.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage="请输入用户名")]
        public string UserName { set; get; }

        [Required(ErrorMessage="请输入密码")]
        public string Password { set; get; }
    }
}