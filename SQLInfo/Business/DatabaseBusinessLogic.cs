using SQLInfo.Data;
using SQLInfo.Model;
using SQLInfo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLInfo.Business
{
    public class DatabaseBusinessLogic
    {
        private DatabaseData databaseData = new DatabaseData();
        public T_Database GetDatabase(int id)
        {
            return databaseData.Single(id);
        }

        public List<string> GetAllDatabases(T_Database database)
        {
            return databaseData.GetAllDatabases(database);
        }

        public List<T_Database> GetAllServers()
        {
            return databaseData.GetAll();
        }

        public List<string> GetAllTables(T_Database database,string dbName)
        {
            return databaseData.GetAllTables(database,dbName);
        }

        public List<TableDetail> GetTableDetail(T_Database database, string dbName, string tableName)
        {
            return databaseData.GetTableDetail(database,dbName,tableName);
        }
    }
}
