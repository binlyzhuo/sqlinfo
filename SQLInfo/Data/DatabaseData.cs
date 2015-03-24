using NPoco;
using SQLInfo.Common;
using SQLInfo.Model;
using SQLInfo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

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

        public List<string> GetAllTables(T_Database database,string dbName)
        {
            if (database.DbType == (int)DbType.SQLServer)
            {
                string connstring = string.Format("server={0};uid={1};pwd={2};database={3}", database.Server, database.Admin, database.Password,dbName);
                Database sqlserverDb = new Database(connstring, DatabaseType.SqlServer2012);
                string selectSql = "SELECT Name FROM SysObjects Where XType='U' ORDER BY Name";
                var databaseList = sqlserverDb.Fetch<string>(selectSql);
                return databaseList;
            }
            return null;
        }

        public List<TableDetail> GetTableDetail(T_Database database, string dbName, string tableName)
        {
            if (database.DbType == (int)DbType.SQLServer)
            {
                string connstring = string.Format("server={0};uid={1};pwd={2};database={3}", database.Server, database.Admin, database.Password, dbName);
                Database sqlserverDb = new Database(connstring, DatabaseType.SqlServer2012);
                string selectSql = string.Format(@"declare @table_name as varchar(max)
set @table_name = '{0}' 
select sys.columns.name as FieldName, sys.types.name as FieldType, sys.columns.max_length as MaxLength, sys.columns.is_nullable as IsNull, 
  (select count(*) from sys.identity_columns where sys.identity_columns.object_id = sys.columns.object_id and sys.columns.column_id = sys.identity_columns.column_id) as IsIdentity ,
  (select value from sys.extended_properties where sys.extended_properties.major_id = sys.columns.object_id and sys.extended_properties.minor_id = sys.columns.column_id) as Description
  from sys.columns, sys.tables, sys.types where sys.columns.object_id = sys.tables.object_id and sys.columns.system_type_id=sys.types.system_type_id and sys.tables.name=@table_name order by sys.columns.column_id",tableName);

                //var items = sqlserverDb.Connection.Query<TableDetail>(selectSql);
                System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection();
                sqlConn.ConnectionString = sqlserverDb.ConnectionString;
                sqlConn.Open();
                var items = sqlConn.Query<TableDetail>(selectSql);
                sqlConn.Close();
                
                //var tableDetails = sqlserverDb.Query<TableDetail>(selectSql).ToList();
                //sqlserverDb.Connection.Open();

                return items.ToList();
            }
            return null;
        }

    }

}
