using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STIM.WinFormUI.PropertyGrid
{
    public class ComboBoxItem : ComboBoxItemTypeConvert  
    {
        public override void GetConvertHash()
        {
            _hash.Add(0, "TextBox");
            _hash.Add(1, "DateTimePicker");
            _hash.Add(2, "NumericUpDown");
            _hash.Add(3, "CheckBox");
            _hash.Add(4, "RadioButton");
            _hash.Add(5, "ComboBox");
            _hash.Add(6, "CheckBoxGroup");
            _hash.Add(7, "ListBox");
            _hash.Add(8, "RadioButtonGroup");
            _hash.Add(9, "TextBoxFrm");
        }
    }
}
