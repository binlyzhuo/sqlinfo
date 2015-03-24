using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;

namespace SQLInfo.ViewModel
{
    public class UserInfo
    {
        private int userID;
        private string userName;
        public UserInfo(int uid,string userName)
        {
            this.userID = uid;
            this.userName = userName;
        }
        public string UserName { get {
            return this.userName;
        } }
        public int UserID { get {
            return this.userID;
        } }

        public static void SaveToSession(UserInfo userinfo)
        {
            HttpContext.Current.Session["UserInfo"] = userinfo;
        }

        public static UserInfo GetUserInfo()
        {
            return HttpContext.Current.Session["UserInfo"] as UserInfo;
        }
    }
}
