using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using NPoco;

namespace SQLInfo.Data
{
    public class BaseData
    {
        protected Database db;
        public BaseData()
        {
            db = new Database("SQLInfo");
        }
    }
}
