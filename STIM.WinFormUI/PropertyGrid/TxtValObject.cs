using System;
using System.Text;

namespace STIM.WinFormUI.PropertyGrid
{
    public class TxtValObject
    {
         private string _Val;
        private string _Txt;
        public TxtValObject()
        { }
        public TxtValObject(string val, string txt)
        {
            _Val = val;
            _Txt = txt;
        }
        public string Val
        {
            get { return _Val; }
            set { _Val = value; }
        }
        public string Txt
        {
            get { return _Txt; }
            set { _Txt = value; }
        }
    }
}
