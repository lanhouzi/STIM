using System;
using System.Collections.Generic;
using System.Text;

namespace STIM.NativePropGrid
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NativeNameAttibute : Attribute
    {
        private string _nativeName;

        public NativeNameAttibute(string nativeName)
        {
            this._nativeName = nativeName;
        }
        public string NativeName
        {
            get { return this._nativeName; }
        }
    }
}
