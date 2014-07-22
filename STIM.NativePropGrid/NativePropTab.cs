using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.PropertyGridInternal;


namespace STIM.NativePropGrid
{
    public class NativePropTab : PropertiesTab
    {
        internal System.Windows.Forms.PropertyGrid PropertyGrid = null;

        public NativePropTab()
        {
            PropertyGrid = null;
        }
         
        public override bool CanExtend(object extendee)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(object component, Attribute[] attributes)
        {
            PropertyDescriptorCollection descriptors = new PropertyDescriptorCollection(null);             
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(component);
           
            foreach (PropertyDescriptor desc in properties)
            {               
                BrowsableAttribute browAttribute = desc.Attributes[typeof(BrowsableAttribute)] as BrowsableAttribute;
                if ((browAttribute == null) || browAttribute.Browsable)
                {
                    NativePropDesc descriptor5 = new NativePropDesc(desc);
                    
                    descriptors.Add(descriptor5);
                } 
            }
             
            if (((this.PropertyGrid != null) && (this.PropertyGrid.SelectedObjects != null)) && (this.PropertyGrid.SelectedObjects.Length > 1))
            {
                descriptors.Sort();               
            }

            return descriptors;
             
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object component, Attribute[] attributes)
        {
            return this.GetProperties(component, attributes);
        }

        //必须要有否则有错误
        public override System.Drawing.Bitmap Bitmap
        {
            get
            {
                Stream imgStream = null;
                try
                {
                    //string[] aaa = typeof(NativePropTab).Assembly.GetManifestResourceNames();
                    //这是读的嵌入资源
                    //System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();asm.GetName().Name + 
                    imgStream = typeof(NativePropTab).Assembly.GetManifestResourceStream("STIM.NativePropGrid.1.gif");
                    if (imgStream == null)
                    {
                        throw new Exception(string.Format("Resourse '{0}' is not founded!", "STIM.NativePropGrid.1.gif"));
                    }
                    return new Bitmap(imgStream);
                }
                finally
                {
                    if (imgStream != null)
                    {
                        imgStream.Close();
                        imgStream = null;
                    }
                }

            }
        }

        public override string TabName
        {
            get
            {
                return "NativeTab";
            }
        }
    }
}
