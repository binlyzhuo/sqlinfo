using SQLInfo.Data;
using SQLInfo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLInfo.Business
{
    public class UserBusinessLogic
    {
        private UserData userData = new UserData();

        public T_User GetUserInfo(string userName,string password)
        {
            return userData.GetUserInfo(userName,password);
        }
    }
}
