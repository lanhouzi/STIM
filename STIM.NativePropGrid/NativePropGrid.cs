using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
 
using System.Collections;
//using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.PropertyGridInternal;

namespace STIM.NativePropGrid
{
    public class NativePropGrid : PropertyGrid
    {
        public NativePropGrid()
        { 
            base.LineColor = SystemColors.Control;
           // SetStandardPropertyTabs();// 在这里使用，在设计时改变Size有Debug
        }


        private void SetPropertyGrid()
        {
            foreach (object obj2 in base.PropertyTabs)
            {
                NativePropTab tab = obj2 as NativePropTab;
                if (tab != null)
                {
                    tab.PropertyGrid = this;
                }
            }
        } 

        public virtual void SetStandardPropertyTabs()
        {
            base.PropertyTabs.RemoveTabType(typeof(PropertiesTab));
            base.PropertyTabs.AddTabType(typeof(NativePropTab), PropertyTabScope.Document);
            this.SetPropertyGrid();
        }

        //protected override void OnSizeChanged(EventArgs e)
        //{
        //    if (  base.PropertyTabs.Count ==0 )
        //        base.OnSizeChanged(e);
        //}

    }
}
