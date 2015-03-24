using SQLInfo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace SQLInfo.Data
{
    public class UserData:BaseData<T_User>
    {
        public UserData()
        {

        }

        public T_User GetUserInfo(string userName,string password)
        {
            Sql where = Sql.Builder.Where("UserName=@0 and Password=@1",userName,password);
            var userinfo = this.db.SingleOrDefault<T_User>(where);
            return userinfo;
        }
    }
}
