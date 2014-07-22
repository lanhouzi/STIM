using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STIM.WinFormUI.PropertyGrid.Select
{
    public class ValueObject
    {
        public string Name { get; set; }//名称
        public string ListSql { get; set; }
        public string SearchParam { get; set; }
        public string ReturnColumnNames { get; set; }
    }
}
