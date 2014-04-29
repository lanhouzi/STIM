using System;

namespace STIM.Model
{
	/// <summary>
	/// 列字段 实体类
	/// </summary>
	[Serializable]
	public partial class STIM_CONFIG
	{
		public STIM_CONFIG()
		{

		}
		#region Model
		private string _table_name;
		private string _search_form_xml;
		private string _detail_form_xml;
		private string _datagridview_xml;
		private string _remark;
		/// <summary>
		/// 表名
		/// </summary>
		public string TABLE_NAME
		{
			set{ _table_name=value;}
			get{return _table_name;}
		}
		/// <summary>
		/// 查询表单布局XML
		/// </summary>
		public string SEARCH_FORM_XML
		{
			set{ _search_form_xml=value;}
			get{return _search_form_xml;}
		}
		/// <summary>
		/// 详细表单布局XML（新增或修改）
		/// </summary>
		public string DETAIL_FORM_XML
		{
			set{ _detail_form_xml=value;}
			get{return _detail_form_xml;}
		}
		/// <summary>
		/// DataGridView布局XML
		/// </summary>
		public string DATAGRIDVIEW_XML
		{
			set{ _datagridview_xml=value;}
			get{return _datagridview_xml;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string REMARK
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model
	}
}

