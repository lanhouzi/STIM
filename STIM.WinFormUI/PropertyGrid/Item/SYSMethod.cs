using System;
using System.Collections;
using System.Collections.Generic;

namespace STIM.WinFormUI.PropertyGrid.Item
{
   public class SYSMethod
    {
       public List<TxtValObject> MethodList = new List<TxtValObject>();
       public SYSMethod()
       {
           MethodList.Add(new TxtValObject() { Val = "IsPhone", Txt = "电话号码验证" });
           MethodList.Add(new TxtValObject() { Val = "IsEmail", Txt = "EMAIL格式验证" });

       }
       public bool CheckValue(string method,string val)
       {
           bool ch = true;
           switch (method)
           {
               case "IsPhone": ch = IsPhone(val); break;
               case "IsEmail": ch = IsEmail(val); break; 
           }
           return ch;
       }
       public bool RegexCheck(string value, string MatchStr)
       {
           //@"(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,5}))?"
           return System.Text.RegularExpressions.Regex.IsMatch(value, MatchStr);
       }
       /// <summary>
       /// 验证电话号码
       /// </summary>
       /// <param name="str_Phone"></param>
       /// <returns></returns>
       public bool IsPhone(string str_Phone)
       {
           //固定号码
           bool ch1=RegexCheck(str_Phone, @"(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,5}))?");
           //手机号码
           bool ch2=RegexCheck(str_Phone, @"(?:13\d|15[1589])-?\d{5}(\d{3}|\*{3})");
           return ch1 || ch2;
       }
       
       /// <summary>
       /// 验证邮箱
       /// </summary>
       /// <param name="str_Email"></param>
       /// <returns></returns>
       public bool IsEmail(string str_Email)
       {
           return RegexCheck(str_Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");//
       }
    }
}
