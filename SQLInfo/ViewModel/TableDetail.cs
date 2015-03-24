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
        public string FieldName { set; get; }
        public string FieldType { set; get; }
        public string MaxLength { set; get; }
        public int IsNull { set; get; }
        public int IsIdentity { set; get; }
        public string Description { set; get; }
    }
}
