using System;
using System.Collections.Generic; 
using System.ComponentModel;

namespace STIM.WinFormUI.PropertyGrid
{
    public class EnumFile
    {
        public enum AppDataValue
        {
            /// <summary>  
            /// 设备号  
            /// </summary>  
            [Description("常量")]
            Constant = 0,
            /// <summary>  
            /// 用户编码  
            /// </summary>  
            [Description("用户编码")]
            USER_ID = 1,
            /// <summary>  
            /// 用户名称  
            /// </summary>  
            [Description("用户名称")]
            EmpName = 2,
            /// <summary>  
            /// 组织机构  
            /// </summary>  
            [Description("组织机构")]
            ORG_ID = 3,
            /// <summary>  
            /// 组织机构名称 
            /// </summary>  
            [Description("组织机构名称")]
            ORG_Name = 4,
            /// <summary>  
            /// 组织机构序列  
            /// </summary>  
            [Description("组织机构序列")]
            ORGSEQ = 5,
            /// <summary>  
            /// 货主编码 
            /// </summary>  
            [Description("货主编码")]
            OwnerId =6,
            /// <summary>  
            /// 货主名称  
            /// </summary>  
            [Description("货主名称")]
            OwnerName = 7
        }  
    }
}
