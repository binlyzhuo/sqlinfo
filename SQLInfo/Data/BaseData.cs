using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using NPoco;

namespace SQLInfo.Data
{
    public class BaseData<T>
        where T:class,new()
    {
        protected Database db;
        public BaseData()
        {
            string connstring = "datasource="+HttpContext.Current.Server.MapPath(ConfigurationManager.ConnectionStrings["SQLInfo"].ConnectionString);
            db = new Database(connstring, DatabaseType.SQLite);
        }

        public int Add(T item)
        {
          return Convert.ToInt32(this.db.Insert(item));
        }

        public T Single(int id)
        {
            return this.db.SingleOrDefaultById<T>(id);
        }

        public List<T> GetAll()
        {
            return this.db.Fetch<T>();
        }
    }
}
