using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLInfo.Common
{
    public class DbTypeHelper
    {
        public static string GetDbTypeName(int type)
        {
            switch ((DbType)type)
            {
                case DbType.SQLServer:
                    return "SQLServer";
                default:
                    return "";
            }
        }
    }
}
