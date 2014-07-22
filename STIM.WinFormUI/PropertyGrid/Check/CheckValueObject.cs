using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STIM.WinFormUI.PropertyGrid
{
    public class CheckValueObject
    {
        //0,系统方法；1,正则表达式；2,sql语句
        public string ValueType { get; set; }
        public string ValueRegular { get; set; }
        public string ValueSql { get; set; }
        public string ValueApp { get; set; }
    }
}
