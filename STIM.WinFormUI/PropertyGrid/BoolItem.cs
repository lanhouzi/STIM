using System;
using System.Collections;
using System.ComponentModel; 

namespace STIM.WinFormUI.PropertyGrid
{
    public class BoolItem : ComboBoxItemTypeConvert
    {
        public override void GetConvertHash() 
        {
            _hash.Add(0, "否");
            _hash.Add(1, "是");  
        } 
    }
}
