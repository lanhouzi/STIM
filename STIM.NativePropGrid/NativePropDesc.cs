using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace STIM.NativePropGrid
{
    class NativePropDesc : PropertyDescriptor
    {
        protected PropertyDescriptor propertyDescriptor;

        public NativePropDesc(PropertyDescriptor propertyDescriptor)
            : base(propertyDescriptor)
        {
            
            this.propertyDescriptor = propertyDescriptor;
        }

        public override bool CanResetValue(object component)
        { 
            return this.propertyDescriptor.CanResetValue(component);
        }

        public override object GetValue(object component)
        {
            return this.propertyDescriptor.GetValue(component);
        }

        public override void ResetValue(object component)
        {
            this.propertyDescriptor.ResetValue(component);
        }

        public override void SetValue(object component, object value)
        {
            this.propertyDescriptor.SetValue(component, value);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return this.propertyDescriptor.ShouldSerializeValue(component);
        }

        public override string Description
        {
            get
            {
                return base.Description;
            }
        }
         
        public override string Category
        {
            get
            {
                return base.Category;
            }
        }

        public override Type ComponentType
        {
            get
            {
                return this.propertyDescriptor.ComponentType;
            }
        }

        /// <summary>
        /// 显示本地名, 由 NativeNameAttibute 属性确定
        /// </summary>
        public override string DisplayName
        {
            get
            {
                //这里可以做本地化处理
                NativeNameAttibute attribute = this.propertyDescriptor.Attributes[typeof(NativeNameAttibute)] as NativeNameAttibute;
                string dispName = base.DisplayName;
                if (attribute != null && !String.IsNullOrEmpty(attribute.NativeName))
                    dispName = attribute.NativeName;

                return dispName; 
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                return this.propertyDescriptor.IsReadOnly;
            }
        }

        public override Type PropertyType
        {
            get
            {
                return this.propertyDescriptor.PropertyType;
            }
        }
    }
}
