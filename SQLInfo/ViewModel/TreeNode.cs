using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLInfo.ViewModel
{
    public class TreeNode
    {
        public int id { set; get; }
        public int pId { set; get; }
        public string name { set; get; }

        public int rootid { set; get; }
    }
}
