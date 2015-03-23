using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLInfo.Model
{
    /// <summary>
    /// T_Database:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_Database
    {
        public T_Database()
        { }
        #region Model
        private int _id;
        private string _server;
        private string _admin;
        private string _password;
        private int _dbtype;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Server
        {
            set { _server = value; }
            get { return _server; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Admin
        {
            set { _admin = value; }
            get { return _admin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DbType
        {
            set { _dbtype = value; }
            get { return _dbtype; }
        }
        #endregion Model

    }
}
