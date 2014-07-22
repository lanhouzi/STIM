using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace STIM.WinFormUI.PropertyGrid
{
    public class ListItemDialog:UITypeEditor
    {  
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        { 
            return UITypeEditorEditStyle.Modal; 
        }
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext  context, System.IServiceProvider provider, object value)
        {  
            IWindowsFormsEditorService edSvc =(IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService)); 
            if (edSvc != null) 
           {  
                // 可以打开任何特定的对话框 
               FrmDataSource dialog = new FrmDataSource(value); 
                //dialog.AddExtension = false; 
                if (dialog.ShowDialog().Equals(DialogResult.OK)) 
                {  
                    return dialog.DataSouce; 
                }  
            }  
            return value;
        }
    }
}
