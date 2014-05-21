using STIM.DALFactory;
using STIM.IDAL;
using System.Collections.Generic;
using System.Data;

namespace STIM.BLL
{
    /// <summary>
    /// 单表信息维护配置表
    /// </summary>
    public partial class STIM_CONFIG
    {
        private readonly ISTIM_CONFIG dal = DataAccess.CreateSTIM_CONFIG();
        public STIM_CONFIG()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TABLE_NAME)
        {
            return dal.Exists(TABLE_NAME);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(STIM.Model.STIM_CONFIG model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(STIM.Model.STIM_CONFIG model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string TABLE_NAME)
        {
            return dal.Delete(TABLE_NAME);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string TABLE_NAMElist)
        {
            return dal.DeleteList(TABLE_NAMElist);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public STIM.Model.STIM_CONFIG GetModel(string TABLE_NAME)
        {
            return dal.GetModel(TABLE_NAME);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<STIM.Model.STIM_CONFIG> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<STIM.Model.STIM_CONFIG> DataTableToList(DataTable dt)
        {
            List<STIM.Model.STIM_CONFIG> modelList = new List<STIM.Model.STIM_CONFIG>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                STIM.Model.STIM_CONFIG model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public int GetRecordCount(string strWhere)
        //{
        //    return dal.GetRecordCount(strWhere);
        //}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        //{
        //    return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        //}
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获得绑定到TreeView数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListForTreeView(string strWhere)
        {
            return dal.GetListForTreeView(strWhere);
        }
        /// <summary>
        /// 获取表信息（字段名称、数据类型、长度、精度、是否为空、默认值、字段说明）
        /// </summary>
        public DataSet GetTableInformation(string tableName)
        {
            return dal.GetTableInformation(tableName);
        }
        /// <summary>
        /// 根据表名和查询条件获取表数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataSet GetDataList(string tableName, string strWhere)
        {
            return dal.GetDataList(tableName, strWhere);
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="dictColumns">列字典</param>
        /// <returns></returns>
        public bool AddData(string tableName, Dictionary<string, object> dictColumns)
        {
            return dal.AddData(tableName, dictColumns);
        }
        #endregion  ExtensionMethod
    }
}

