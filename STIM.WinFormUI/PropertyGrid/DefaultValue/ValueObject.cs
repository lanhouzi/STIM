using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STIM.WinFormUI.PropertyGrid
{
    public class ValueObject
    {
        //0,文本；1,系统变量；2,sql语句
        public string ValueType { get; set; }
        public string ValueStr { get; set; }
        public string ValueSql { get; set; }
        public string ValueApp { get; set; }
    }
}
