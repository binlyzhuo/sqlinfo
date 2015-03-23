using NPoco;
using SQLInfo.Common;
using SQLInfo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLInfo.Data
{
    public class DatabaseData:BaseData<T_Database>
    {
        public DatabaseData()
        {

        }

        public List<string> GetAllDatabases(T_Database database)
        {
            if(database.DbType==(int)DbType.SQLServer)
            {
                string connstring = string.Format("server={0};uid={1};pwd={2};database=Master",database.Server,database.Admin,database.Password);
                Database sqlserverDb = new Database(connstring, DatabaseType.SqlServer2012);
                string selectSql = "SELECT name FROM MASter..SysDatabASes ORDER BY name";
                var databaseList = sqlserverDb.Fetch<string>(selectSql);
                return databaseList;
            }
            return null;
        }


    }

}
