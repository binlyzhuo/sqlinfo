using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLInfo.ViewModel
{
    [Serializable]
    public class TableDetail
    {
        public string TableName { set; get; }
        public int FieldNo { set; get; }
        public string FieldName { set; get; }

        public string IsIdentity { set; get; }

        public string IsPrimaryKey { set; get; }

        public string FieldType { set; get; }

        public int CharLength { set; get; }

        public string FieldLength { set; get; }

        public int DecimalDigits { set; get; }

        public string IsNull { set; get; }

        public string Description { set; get; }

        public string DefaultValue { set; get; }
        
    }
}
