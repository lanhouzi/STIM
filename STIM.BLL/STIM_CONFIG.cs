using STIM.DALFactory;
using STIM.IDAL;
using System.Collections.Generic;
using System.Data;
using System.Collections;

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
        public DataSet GetDataList(string tableName, ArrayList al)
        {
            return dal.GetDataList(tableName, al);
        }
        /// <summary>
        /// 是否存在数据记录
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        public bool ExistsData(string strSql)
        {
            return dal.ExistsData(strSql);
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        public bool AddData(string strSql)
        {
            return dal.AddData(strSql);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        public bool UpdateData(string strSql)
        {
            return dal.UpdateData(strSql);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteDataList(string tableName, string strWhere, string strValues)
        {
            return dal.DeleteDataList(tableName, strWhere, strValues);
        }

        /// <summary>
        /// 获取定义的sql返回结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet getSqlResult(string sql)
        {
            return dal.getSqlResult(sql);
        }
        /// <summary>
        /// 获取自定义sql返回的结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet getSearchResult(string sql, Hashtable ht)
        {
            return dal.getSearchResult(sql, ht);
        }
        /// <summary>
        /// 获取定义的sql返回结构的第一个列的值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string getSqlDefaultValue(string sql)
        {
            try
            {
                using (DataSet ds = dal.getSqlResult(sql))
                {
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0].Rows[0][0].ToString();
                    }
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 通过定义的sql验证输入的值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool SqlCheckValue(string sql, Hashtable ht)
        {
            try
            {
                using (DataSet ds = dal.SqlCheckValue(sql,ht))
                {
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion  ExtensionMethod
    }
}

