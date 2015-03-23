using SQLInfo.Data;
using SQLInfo.Model;
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
    }
}
