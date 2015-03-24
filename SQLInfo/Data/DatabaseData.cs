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
                string selectSql = string.Format(@"SELECT (case when a.colorder=1 then d.name else '' end) TableName,
                                                a.colorder FieldNo,a.name FieldName,
                                                (case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then '√'else '' end) IsIdentity,
                                                (case when (SELECT count(*) 
                                                FROM sysobjects 
                                                WHERE (name in (SELECT name
                                                FROM sysindexes
                                                WHERE (id = a.id) AND (indid in (SELECT indid
                                                FROM sysindexkeys
                                                WHERE (id = a.id) AND (colid in (SELECT colid
                                                FROM syscolumns
                                                WHERE (id = a.id) AND (name = a.name))))))
                                                ) AND (xtype = 'PK') 
                                                ) > 0 then '√' else '' end) IsPrimaryKey,
                                                b.name as FieldType,
                                                a.length as CharLength,
                                                COLUMNPROPERTY(a.id,a.name,'PRECISION') as FieldLength,
                                                isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0) as DecimalDigits,
                                                (case when a.isnullable=1 then '√'else '' end) IsNull,
                                                isnull(g.[value],'') AS Description ,
                                                isnull(e.text,'') DefaultValue
                               
                                                FROM  syscolumns a 
                                                left join systypes b on a.xtype=b.xusertype
                                                inner join sysobjects d on a.id=d.id  and  d.xtype='U' and d.name<>'dtproperties'
                                                left join syscomments e on a.cdefault=e.id
                                                left join sys.extended_properties g on a.id=g.major_id AND a.colid = g.minor_id  
                                                where d.name ='{0}'
                                                order by a.id,a.colorder ", tableName);

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
