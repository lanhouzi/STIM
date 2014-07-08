﻿# Readme.md


To learn more about the markdown syntax, refer to these links:

 - [Markdown Syntax Guide](http://daringfireball.net/projects/markdown/syntax)
 - [Markdown Basics](http://daringfireball.net/projects/markdown/basics)
 - [GitHub Flavored Markdown](http://github.github.com/github-flavored-markdown/) 
 - [markdown at wikipedia](https://secure.wikimedia.org/wikipedia/en/wiki/Markdown)

已知有一个XML文件（bookstore.xml）如下：

<?xml version="1.0" encoding="gb2312"?> 
<bookstore> 
  <book genre="fantasy" ISBN="2-3631-4"> 
    <title>Oberon's Legacy</title> 
    <author>Corets, Eva</author> 
    <price>5.95</price> 
  </book> 
</bookstore>

1、往<bookstore>节点中插入一个<book>节点：

XmlDocument xmlDoc=new XmlDocument(); 
xmlDoc.Load("bookstore.xml"); 
XmlNode root=xmlDoc.SelectSingleNode("bookstore");//查找<bookstore>
XmlElement xe1=xmlDoc.CreateElement("book");//创建一个<book>节点 
xe1.SetAttribute("genre","陶维佳");//设置该节点genre属性 
xe1.SetAttribute("ISBN","2-3631-4");//设置该节点ISBN属性 

XmlElement xesub1=xmlDoc.CreateElement("title"); 
xesub1.InnerText="CS从入门到精通";//设置文本节点 
xe1.AppendChild(xesub1);//添加到<book>节点中 
XmlElement xesub2=xmlDoc.CreateElement("author"); 
xesub2.InnerText="张三"; 
xe1.AppendChild(xesub2); 
XmlElement xesub3=xmlDoc.CreateElement("price"); 
xesub3.InnerText="58.3"; 
xe1.AppendChild(xesub3); 

root.AppendChild(xe1);//添加到<bookstore>节点中 
xmlDoc.Save("bookstore.xml");

结果为：

<?xml version="1.0" encoding="gb2312"?> 
<bookstore> 
  <book genre="fantasy" ISBN="2-3631-4"> 
    <title>Oberon's Legacy</title> 
    <author>Corets, Eva</author> 
    <price>5.95</price> 
  </book> 
  <book genre="陶维佳" ISBN="2-3631-4"> 
    <title>CS从入门到精通</title> 
    <author>张三</author> 
    <price>58.3</price> 
  </book> 
</bookstore>

2、修改节点:将genre属性值为“陶维佳”的节点的genre值改为“update陶维佳”,将该节点的子节点<author>的文本修改为“比尔盖茨”。

  XmlNodeList nodeList=xmlDoc.SelectSingleNode("bookstore").ChildNodes;//获取bookstore节点的所有子节点 
  foreach(XmlNode xn in nodeList)//遍历所有子节点 
  { 
    XmlElement xe=(XmlElement)xn;//将子节点类型转换为XmlElement类型 
    if(xe.GetAttribute("genre")=="陶维佳")//如果genre属性值为“陶维佳” 
    { 
    xe.SetAttribute("genre","update陶维佳");//则修改该属性为“update陶维佳” 

    XmlNodeList nls=xe.ChildNodes;//继续获取xe子节点的所有子节点 
    foreach(XmlNode xn1 in nls)//遍历 
    { 
      XmlElement xe2=(XmlElement)xn1;//转换类型 
      if(xe2.Name=="author")//如果找到 
      { 
      xe2.InnerText="比尔盖茨";//则修改 
      break;//找到退出来就可以了 
      } 
    } 
    break; 
    } 
  } 
  xmlDoc.Save("bookstore.xml");//保存。

最后结果为：

<?xml version="1.0" encoding="gb2312"?> 
<bookstore> 
  <book genre="fantasy" ISBN="2-3631-4"> 
    <title>Oberon's Legacy</title> 
    <author>Corets, Eva</author> 
    <price>5.95</price> 
  </book> 
  <book genre="update陶维佳" ISBN="2-3631-4"> 
    <title>CS从入门到精通</title> 
    <author>比尔盖茨</author> 
    <price>58.3</price> 
  </book> 
</bookstore> 

3、删除 <book genre="fantasy" ISBN="2-3631-4">节点的genre属性，删除 <book genre="update陶维佳" ISBN="2-3631-4">节点。

XmlNodeList xnl=xmlDoc.SelectSingleNode("bookstore").ChildNodes; 

  foreach(XmlNode xn in xnl) 
  { 
    XmlElement xe=(XmlElement)xn; 
    if(xe.GetAttribute("genre")=="fantasy") 
    { 
    xe.RemoveAttribute("genre");//删除genre属性 
    } 
    else if(xe.GetAttribute("genre")=="update陶维佳") 
    { 
    xe.RemoveAll();//删除该节点的全部内容 
    } 
  } 
  xmlDoc.Save("bookstore.xml"); 

最后结果为：

<?xml version="1.0" encoding="gb2312"?> 
<bookstore> 
  <book ISBN="2-3631-4"> 
    <title>Oberon's Legacy</title> 
    <author>Corets, Eva</author> 
    <price>5.95</price> 
  </book> 
  <book> 
  </book> 
</bookstore> 

4、显示所有数据。

　XmlNode xn=xmlDoc.SelectSingleNode("bookstore"); 

  XmlNodeList xnl=xn.ChildNodes; 

  foreach(XmlNode xnf in xnl) 
  { 
    XmlElement xe=(XmlElement)xnf; 
    Console.WriteLine(xe.GetAttribute("genre"));//显示属性值 
    Console.WriteLine(xe.GetAttribute("ISBN")); 

    XmlNodeList xnf1=xe.ChildNodes; 
    foreach(XmlNode xn2 in xnf1) 
    { 
    Console.WriteLine(xn2.InnerText);//显示子节点点文本 
    } 
  }

-------------------------------------------------------------------------------------------------------------------------


补充:删除根节点下的所有子节点

<?xml version="1.0" encoding="gb2312"?>
<MyData>
  <Item Province="北京" County="昌平" Zipcode="102200" Areacode="010">
    <t>sdfsdf</t>
    <t2>sdfsdf</t2>
  </Item>
  <Item Province="北京" County="大兴" Zipcode="102600" Areacode="010" />
  <Item Province="北京" County="密云" Zipcode="101500" Areacode="010" />
</MyData>

一、XmlDocument xml = new XmlDocument();
        xml.Load(Server.MapPath("data.xml"));
        XmlNode xn = xml.DocumentElement;
        xn.RemoveAll();
        xml.Save(Server.MapPath("data.xml"));

执行之后：

<?xml version="1.0" encoding="gb2312"?>
<MyData>
</MyData>

二。扩展：删除某个标记下面的所有子节点

XmlDocument xml = new XmlDocument();
        xml.Load(Server.MapPath("data.xml"));
        XmlNodeList xnl = xml.SelectNodes("MyData/Item");
        foreach (XmlNode xn in xnl)
        {
            xn.RemoveAll();
        }
        
        xml.Save(Server.MapPath("data.xml"));

执行以后：

<?xml version="1.0" encoding="gb2312"?>
<MyData>
  <Item>
  </Item>
  <Item />
  <Item />
</MyData>