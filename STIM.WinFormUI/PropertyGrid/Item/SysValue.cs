using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STIM.WinFormUI.PropertyGrid.Item
{
    public class SysValue
    { 
        public List<TxtValObject> ValueList=new List<TxtValObject>();
        public SysValue()
            {
                ValueList.Add(new TxtValObject() { Val = "SYS_USER_ID", Txt = "用户编码" });
                ValueList.Add(new TxtValObject() { Val = "SYS_EMP_Name", Txt = "用户名称" });
                ValueList.Add(new TxtValObject() { Val = "SYS_ORG_ID", Txt = "机构编码" });
                ValueList.Add(new TxtValObject() { Val = "SYS_ORG_Name", Txt = "机构名称" });
                ValueList.Add(new TxtValObject() { Val = "SYS_ORG_SEQ", Txt = "机构序列" });
                ValueList.Add(new TxtValObject() { Val = "SYS_OWNER_Id", Txt = "货主编码" });
                ValueList.Add(new TxtValObject() { Val = "SYS_OWNER_Name", Txt = "货主名称" });
                ValueList.Add(new TxtValObject() { Val = "SYS_sysdate", Txt = "数据库日期" });
            
        }
        public string GetValue(string key)
        {
            string val=string.Empty;
            switch (key)
            {
                case "SYS_USER_ID": val = ORG.Utilities.AppData.USER_ID; break;
                case "SYS_EMP_Name": val = ORG.Utilities.AppData.EmpName; break;
                case "SYS_ORG_ID": val = ORG.Utilities.AppData.ORG_ID; break;
                case "SYS_ORG_Name": val = ORG.Utilities.AppData.ORG_Name; break;
                case "SYS_ORG_SEQ": val = ORG.Utilities.AppData.ORGSEQ; break;
                case "SYS_OWNER_Id": val = ORG.Utilities.AppData.OwnerId; break;
                case "SYS_OWNER_Name": val = ORG.Utilities.AppData.OwnerName; break;
                case "SYS_sysdate": val = "sysdate"; break;
            }
            return val;
        }
    }
}
