using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using STIM.IDAL;
using System;
using System.Data;
using System.Text;
using WMS.DBUtility;

namespace STIM.OracleDAL
{
    /// <summary>
    /// 数据访问类:STIM_CONFIG
    /// </summary>
    public partial class STIM_CONFIG : ISTIM_CONFIG
    {
        DbHelperOra ora = null;
        public STIM_CONFIG()
        {
            ora = new DbHelperOra("SYS_ConnectionString");
        }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TABLE_NAME)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from STIM_CONFIG");
            strSql.Append(" where TABLE_NAME=:TABLE_NAME ");
            OracleParameter[] parameters = {
                    new OracleParameter(":TABLE_NAME", OracleDbType.Varchar2)			};
            parameters[0].Value = TABLE_NAME;

            return ora.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(STIM.Model.STIM_CONFIG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into STIM_CONFIG(");
            strSql.Append("TABLE_NAME,SEARCH_FORM_XML,DETAIL_FORM_XML,DATAGRIDVIEW_XML,REMARK)");
            strSql.Append(" values (");
            strSql.Append(":TABLE_NAME,:SEARCH_FORM_XML,:DETAIL_FORM_XML,:DATAGRIDVIEW_XML,:REMARK)");
            OracleParameter[] parameters = {
                    new OracleParameter(":TABLE_NAME", OracleDbType.Varchar2),
                    new OracleParameter(":SEARCH_FORM_XML", OracleDbType.NClob),
                    new OracleParameter(":DETAIL_FORM_XML", OracleDbType.NClob),
                    new OracleParameter(":DATAGRIDVIEW_XML", OracleDbType.NClob),
                    new OracleParameter(":REMARK", OracleDbType.Varchar2)};
            parameters[0].Value = model.TABLE_NAME;
            parameters[1].Value = model.SEARCH_FORM_XML;
            parameters[2].Value = model.DETAIL_FORM_XML;
            parameters[3].Value = model.DATAGRIDVIEW_XML;
            parameters[4].Value = model.REMARK;

            int rows = ora.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(STIM.Model.STIM_CONFIG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update STIM_CONFIG set ");
            strSql.Append("SEARCH_FORM_XML=:SEARCH_FORM_XML,DETAIL_FORM_XML=:DETAIL_FORM_XML,DATAGRIDVIEW_XML=:DATAGRIDVIEW_XML,REMARK=:REMARK");
            strSql.Append(" where TABLE_NAME=:TABLE_NAME");

            OracleParameter[] parameters = {
                    new OracleParameter(":SEARCH_FORM_XML", OracleDbType.NClob),
                    new OracleParameter(":DETAIL_FORM_XML", OracleDbType.NClob),
                    new OracleParameter(":DATAGRIDVIEW_XML", OracleDbType.NClob),
                    new OracleParameter(":REMARK", OracleDbType.Varchar2),
                    new OracleParameter(":TABLE_NAME", OracleDbType.Varchar2)};
            parameters[0].Value = model.SEARCH_FORM_XML;
            parameters[1].Value = model.DETAIL_FORM_XML;
            parameters[2].Value = model.DATAGRIDVIEW_XML;
            parameters[3].Value = model.REMARK;
            parameters[4].Value = model.TABLE_NAME;

            int rows = ora.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string TABLE_NAME)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from STIM_CONFIG ");
            strSql.Append(" where TABLE_NAME=:TABLE_NAME ");
            OracleParameter[] parameters = {
                    new OracleParameter(":TABLE_NAME", OracleDbType.Varchar2)};
            parameters[0].Value = TABLE_NAME;

            int rows = ora.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string TABLE_NAMElist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from STIM_CONFIG ");
            strSql.Append(" where TABLE_NAME in (" + TABLE_NAMElist + ")  ");
            int rows = ora.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public STIM.Model.STIM_CONFIG GetModel(string TABLE_NAME)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TABLE_NAME,SEARCH_FORM_XML,DETAIL_FORM_XML,DATAGRIDVIEW_XML,REMARK from STIM_CONFIG ");
            strSql.Append(" where TABLE_NAME=:TABLE_NAME ");
            OracleParameter[] parameters = {
                    new OracleParameter(":TABLE_NAME", OracleDbType.Varchar2)			};
            parameters[0].Value = TABLE_NAME;

            STIM.Model.STIM_CONFIG model = new STIM.Model.STIM_CONFIG();
            DataSet ds = ora.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public STIM.Model.STIM_CONFIG DataRowToModel(DataRow row)
        {
            STIM.Model.STIM_CONFIG model = new STIM.Model.STIM_CONFIG();
            if (row != null)
            {
                if (row["TABLE_NAME"] != null)
                {
                    model.TABLE_NAME = row["TABLE_NAME"].ToString();
                }
                if (row["SEARCH_FORM_XML"] != null)
                {
                    model.SEARCH_FORM_XML = row["SEARCH_FORM_XML"].ToString();
                }
                if (row["DETAIL_FORM_XML"] != null)
                {
                    model.DETAIL_FORM_XML = row["DETAIL_FORM_XML"].ToString();
                }
                if (row["DATAGRIDVIEW_XML"] != null)
                {
                    model.DATAGRIDVIEW_XML = row["DATAGRIDVIEW_XML"].ToString();
                }
                if (row["REMARK"] != null)
                {
                    model.REMARK = row["REMARK"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TABLE_NAME,SEARCH_FORM_XML,DETAIL_FORM_XML,DATAGRIDVIEW_XML,REMARK ");
            strSql.Append(" FROM STIM_CONFIG ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return ora.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM STIM_CONFIG ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.TABLE_NAME desc");
            }
            strSql.Append(")AS Row, T.*  from STIM_CONFIG T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return ora.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            OracleParameter[] parameters = {
                    new OracleParameter(":tblName", OracleDbType.VarChar, 255),
                    new OracleParameter(":fldName", OracleDbType.VarChar, 255),
                    new OracleParameter(":PageSize", OracleDbType.Number),
                    new OracleParameter(":PageIndex", OracleDbType.Number),
                    new OracleParameter(":IsReCount", OracleDbType.Clob),
                    new OracleParameter(":OrderType", OracleDbType.Clob),
                    new OracleParameter(":strWhere", OracleDbType.VarChar,1000),
                    };
            parameters[0].Value = "STIM_CONFIG";
            parameters[1].Value = "TABLE_NAME";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return ora.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获得绑定到TreeView数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListForTreeView(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TABLE_NAME,REMARK ");
            strSql.Append(" FROM STIM_CONFIG ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return ora.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取表信息（字段名称、数据类型、长度、精度、是否为空、默认值、字段说明）
        /// </summary>
        public DataSet GetTableInformation(string tableName)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select T.COLUMN_NAME,T.DATA_TYPE,T.DATA_PRECISION,T.DATA_SCALE,T.NULLABLE,T.DATA_DEFAULT,C.COMMENTS");
            //strSql.Append(" from user_tab_columns T inner join user_col_comments C");
            //strSql.Append(" on T.table_name=C.table_name and T.column_name=C.column_name");
            //strSql.Append(" where T.table_name =upper('" + TableName + "') order by T.column_id");

            strSql.AppendFormat(@"SELECT T.COLUMN_ID,T.COLUMN_NAME,T.DATA_TYPE
,DECODE(T.DATA_TYPE, 'NUMBER', T.DATA_PRECISION, T.DATA_LENGTH) AS LENGTH
,T.DATA_PRECISION,T.DATA_SCALE,CASE WHEN PKCOL.COLUMN_POSITION > 0 THEN 'Y' ELSE 'N' END AS ISPK
,T.NULLABLE,T.DATA_DEFAULT,C.COMMENTS,T.NUM_DISTINCT FROM USER_TAB_COLUMNS T,USER_COL_COMMENTS C
,(SELECT AA.TABLE_NAME,AA.INDEX_NAME,AA.COLUMN_NAME,AA.COLUMN_POSITION
 FROM USER_IND_COLUMNS AA,USER_CONSTRAINTS BB
 WHERE BB.CONSTRAINT_TYPE = 'P' AND AA.TABLE_NAME = BB.TABLE_NAME
 AND AA.INDEX_NAME = BB.CONSTRAINT_NAME AND AA.TABLE_NAME IN (upper('{0}'))) PKCOL
 WHERE T.TABLE_NAME = C.TABLE_NAME AND T.COLUMN_NAME = C.COLUMN_NAME
 AND T.TABLE_NAME =upper('{1}') AND T.COLUMN_NAME = PKCOL.COLUMN_NAME(+)
 AND T.TABLE_NAME = PKCOL.TABLE_NAME(+) ORDER BY T.COLUMN_ID", tableName, tableName);

            //DataTable dt = new DataTable();
            //System.Data.OleDb.OleDbConnection conn1 = new System.Data.OleDb.OleDbConnection();
            //conn1.ConnectionString = ora.connectionString;
            //dt = conn1.GetSchema();
            //dt = conn1.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new Object[] { null, null, TableName, null });

            //OracleConnection conn2 = new OracleConnection();
            //conn2.ConnectionString = ora.connectionString;
            //conn2.GetSchema();

            return ora.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据表名和查询条件获取表数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataSet GetDataList(string tableName, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + tableName);
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }
            return ora.Query(strSql.ToString());
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsData(string tableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from STIM_CONFIG");
            strSql.Append(" where TABLE_NAME=:TABLE_NAME ");
            OracleParameter[] parameters = {
                    new OracleParameter(":TABLE_NAME", OracleDbType.Varchar2)			};
            parameters[0].Value = tableName;

            return ora.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="dictColumns">列字典</param>
        /// <returns></returns>
        public bool AddData(string tableName, Dictionary<string, object> dictColumns)
        {
            StringBuilder strSql = new StringBuilder("insert into " + tableName);
            StringBuilder sbColumns = new StringBuilder(" (");
            StringBuilder sbValues = new StringBuilder(" values (");
            OracleParameter[] parameters = { };
            //OracleParameter[] parameters = { 
            //        new OracleParameter(":TABLE_NAME", OracleDbType.Varchar2),
            //        new OracleParameter(":SEARCH_FORM_XML", OracleDbType.NClob),
            //        new OracleParameter(":DETAIL_FORM_XML", OracleDbType.NClob),
            //        new OracleParameter(":DATAGRIDVIEW_XML", OracleDbType.NClob),
            //        new OracleParameter(":REMARK", OracleDbType.Varchar2)};
            //parameters[0].Value = model.TABLE_NAME;
            //parameters[1].Value = model.SEARCH_FORM_XML;
            //parameters[2].Value = model.DETAIL_FORM_XML;
            //parameters[3].Value = model.DATAGRIDVIEW_XML;
            //parameters[4].Value = model.REMARK;

            foreach (var item in dictColumns)
            {
                sbColumns.Append("," + item.Key);
                sbValues.Append(",:" + item.Key);
                OracleDbType odbType;
                if (item.Value.GetType().Name == "String")
                    odbType = OracleDbType.Varchar2;
                else if (item.Value.GetType().Name == "DateTime")
                    odbType = OracleDbType.Date;
                else
                    odbType = OracleDbType.Decimal;
                OracleParameter[] p = { new OracleParameter(":" + item.Key, odbType) };
                p[0].Value = item.Value;
                p.CopyTo(parameters, parameters.Length);
            }
            sbColumns.Append(")");
            sbValues.Append(")");
            strSql.Append(sbColumns.ToString().TrimStart(','));
            strSql.Append(sbValues.ToString().TrimStart(','));

            int rows = ora.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateData(STIM.Model.STIM_CONFIG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update STIM_CONFIG set ");
            strSql.Append("SEARCH_FORM_XML=:SEARCH_FORM_XML,DETAIL_FORM_XML=:DETAIL_FORM_XML,DATAGRIDVIEW_XML=:DATAGRIDVIEW_XML,REMARK=:REMARK");
            strSql.Append(" where TABLE_NAME=:TABLE_NAME");

            OracleParameter[] parameters = {
                    new OracleParameter(":SEARCH_FORM_XML", OracleDbType.NClob),
                    new OracleParameter(":DETAIL_FORM_XML", OracleDbType.NClob),
                    new OracleParameter(":DATAGRIDVIEW_XML", OracleDbType.NClob),
                    new OracleParameter(":REMARK", OracleDbType.Varchar2),
                    new OracleParameter(":TABLE_NAME", OracleDbType.Varchar2)};

            parameters[0].Value = model.SEARCH_FORM_XML;
            parameters[1].Value = model.DETAIL_FORM_XML;
            parameters[2].Value = model.DATAGRIDVIEW_XML;
            parameters[3].Value = model.REMARK;
            parameters[4].Value = model.TABLE_NAME;

            int rows = ora.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteData(string tableName, string strWhere)
        {
            StringBuilder strSql = new StringBuilder("delete from " + tableName);
            if (string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
                int rows = ora.ExecuteSql(strSql.ToString());
                return rows > 0;
            }
            return false;
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteDataList(string tableName, string strWhere,string strValues)
        {
            StringBuilder strSql = new StringBuilder("delete from " + tableName);
            if (string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
                strSql.Append(" in (" + strValues + ")");
                int rows = ora.ExecuteSql(strSql.ToString());
                return rows > 0;
            }
            return false;
        }
        /// <summary>
        /// 得到表配置（查询条件，显示列）
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public DataSet TableConfig(string tableName)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"select T.COLUMN_ID,T.COLUMN_NAME,T.DATA_TYPE,
 regexp_replace(C.COMMENTS,'[@$]') as COMMENTS,
 case when instr(C.COMMENTS,'@')>0 THEN 'Y' ELSE 'N' END AS IsSearch,
 case when instr(C.COMMENTS,'$')>0 THEN 'Y' ELSE 'N' END AS IsViewColumn
 from user_tab_columns T inner join user_col_comments C
 on T.table_name=C.table_name and T.column_name=C.column_name
 where T.table_name =upper('{0}') order by T.column_id", tableName);

            return ora.Query(strSql.ToString());
        }

        #endregion  ExtensionMethod
    }
}

