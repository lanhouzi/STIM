using System.Data;

namespace STIM.IDAL
{
    /// <summary>
    /// 接口层单表信息维护配置表
    /// </summary>
    public interface ISTIM_CONFIG
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string TABLE_NAME);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(STIM.Model.STIM_CONFIG model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(STIM.Model.STIM_CONFIG model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string TABLE_NAME);
        bool DeleteList(string TABLE_NAMElist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        STIM.Model.STIM_CONFIG GetModel(string TABLE_NAME);
        STIM.Model.STIM_CONFIG DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx
        /// <summary>
        /// 获得绑定到TreeView数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataSet GetListForTreeView(string strWhere);
        /// <summary>
        /// 获取表信息（字段名称、数据类型、长度、精度、是否为空、默认值、字段说明）
        /// </summary>
        DataSet GetTableInformation(string tableName);
        /// <summary>
        /// 根据表名和查询条件获取表数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        DataSet GetDataList(string tableName, string strWhere);

        #endregion  MethodEx
    }
}
