using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Com.Winfotian.Model;

namespace Com.Winfotian.DB.Provider
{
    public class DtuGroupProvider
    {
        /// <summary>
        /// 根据公司Id查询分组信息
        /// </summary>
        public List<T_DTU_GroupEx> GetSiteGroupByCompanyId(string companyId)
        {
            List<T_DTU_GroupEx> list = new List<T_DTU_GroupEx>();
            StringBuilder sb = new StringBuilder();
            sb.Append("select a.*,b.GroupName as ParentName ");
            sb.Append("from [Infa]..[T_DTU_Group] as a left join [Infa]..[T_DTU_Group] as b on a.ParentCode=b.GroupCode ");
            sb.Append("where a.CompanyId=@CompanyId order by b.ParentCode asc");
            SqlParameter[] parameters = { 
                           new SqlParameter("@CompanyId",companyId)
                                        };
            using (SqlDataReader reader = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyRead, CommandType.Text, sb.ToString(), parameters))
            {
                while (reader.Read())
                {
                    var model = IDataT_DTU_GroupExReader(reader);
                    if (model != null)
                    {
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 获取T_DTU_GroupEx
        /// </summary>
        private T_DTU_GroupEx IDataT_DTU_GroupExReader(IDataReader dr)
        {
            T_DTU_GroupEx model = new T_DTU_GroupEx();
            try
            {
                model.GroupCode = (dr["GroupCode"] is DBNull) ? string.Empty : dr["GroupCode"].ToString();
                model.GroupName = (dr["GroupName"] is DBNull) ? string.Empty : dr["GroupName"].ToString();
                model.GroupDesc = (dr["GroupDesc"] is DBNull) ? string.Empty : dr["GroupDesc"].ToString();
                model.ParentCode = (dr["ParentCode"] is DBNull) ? string.Empty : dr["ParentCode"].ToString();
                model.Status = (dr["Status"] is DBNull) ? 0 : Convert.ToInt32(dr["Status"].ToString());
                model.CompanyId = (dr["CompanyId"] is DBNull) ? 0 : Convert.ToInt32(dr["CompanyId"].ToString());
                model.UpdateFlag = (dr["UpdateFlag"] is DBNull) ? 0 : Convert.ToInt32(dr["UpdateFlag"].ToString());
                model.ParentName = (dr["ParentName"] is DBNull) ? string.Empty : dr["ParentName"].ToString();
            }
            catch
            {
                return null;
            }
            return model;
        }

        /// <summary>
        /// 根据分组编码查询
        /// </summary>
        public T_DTU_Group GetGroupDeatail(string groupCode)
        {
            T_DTU_Group model = new T_DTU_Group();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from [Infa]..[T_DTU_Group] where GroupCode=@GroupCode");
            SqlParameter[] parameters = {                               
                           new SqlParameter("@GroupCode",groupCode)
                                        };
            using (var reader = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyRead, CommandType.Text, sb.ToString(), parameters))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        model = IDataT_DTU_GroupReader(reader);
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(T_DTU_Group model)
        {
            bool result = false;
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into [Infa]..[T_DTU_Group](");
            sb.Append("GroupCode,GroupName,GroupDesc,ParentCode,Status,CompanyId,UpdateFlag)");
            sb.Append(" values (");
            sb.Append("@GroupCode,@GroupName,@GroupDesc,@ParentCode,@Status,@CompanyId,@UpdateFlag)");
            SqlParameter[] parameters = {
					       new SqlParameter("@GroupCode", SqlDbType.VarChar,30),
					       new SqlParameter("@GroupName", SqlDbType.NVarChar,30),
					       new SqlParameter("@GroupDesc", SqlDbType.NVarChar,50),
					       new SqlParameter("@ParentCode", SqlDbType.VarChar,30),
					       new SqlParameter("@Status", SqlDbType.SmallInt,2),
					       new SqlParameter("@CompanyId", SqlDbType.Int,4),
					       new SqlParameter("@UpdateFlag", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.GroupCode;
            parameters[1].Value = model.GroupName;
            parameters[2].Value = model.GroupDesc;
            parameters[3].Value = model.ParentCode;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.CompanyId;
            parameters[6].Value = model.UpdateFlag;
            int rows = SqlHelper.DBHelper.ExecuteNonQuery(SqlHelper.DBHelper.OnlyWrite, CommandType.Text, sb.ToString(), parameters);
            if (rows > 0)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(T_DTU_Group model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update [Infa]..[T_DTU_Group] set ");
            sb.Append("GroupName=@GroupName,");
            sb.Append("GroupDesc=@GroupDesc,");
            sb.Append("ParentCode=@ParentCode,");
            sb.Append("Status=@Status,");
            sb.Append("CompanyId=@CompanyId,");
            sb.Append("UpdateFlag=@UpdateFlag");
            sb.Append(" where GroupCode=@GroupCode ");
            SqlParameter[] parameters = {
					       new SqlParameter("@GroupName", SqlDbType.NVarChar,30),
					       new SqlParameter("@GroupDesc", SqlDbType.NVarChar,50),
					       new SqlParameter("@ParentCode", SqlDbType.VarChar,30),
					       new SqlParameter("@Status", SqlDbType.SmallInt,2),
					       new SqlParameter("@CompanyId", SqlDbType.Int,4),
					       new SqlParameter("@UpdateFlag", SqlDbType.Int,4),
					       new SqlParameter("@GroupCode", SqlDbType.VarChar,30)};
            parameters[0].Value = model.GroupName;
            parameters[1].Value = model.GroupDesc;
            parameters[2].Value = model.ParentCode;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.CompanyId;
            parameters[5].Value = model.UpdateFlag;
            parameters[6].Value = model.GroupCode;

            int rows = SqlHelper.DBHelper.ExecuteNonQuery(SqlHelper.DBHelper.OnlyWrite, CommandType.Text, sb.ToString(), parameters);
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
        public bool Delete(string groupCode)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from [Infa]..[T_DTU_Group] ");
            sb.Append(" where GroupCode=@GroupCode ");
            SqlParameter[] parameters = {
					       new SqlParameter("@GroupCode", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = groupCode;

            int rows = SqlHelper.DBHelper.ExecuteNonQuery(SqlHelper.DBHelper.OnlyWrite, CommandType.Text, sb.ToString(), parameters);
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
        public T_DTU_Group GetModel(string groupCode)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select top 1 GroupCode,GroupName,GroupDesc,ParentCode,Status,CompanyId,UpdateFlag from [Infa]..[T_DTU_Group] ");
            sb.Append("where GroupCode=@GroupCode ");
            SqlParameter[] parameters = {
					       new SqlParameter("@GroupCode", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = groupCode;
            T_DTU_Group model = null;
            using (IDataReader dr = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyRead, CommandType.Text, sb.ToString(), parameters))
            {
                if (dr.Read())
                {
                    model = IDataT_DTU_GroupReader(dr);
                }
            }
            return model;
        }

        /// <summary>
        /// T_DTU_Group 数据读取
        /// </summary>
        private T_DTU_Group IDataT_DTU_GroupReader(IDataReader dr)
        {
            T_DTU_Group model = new T_DTU_Group();
            try
            {
                model.GroupCode = (dr["GroupCode"] is DBNull) ? string.Empty : dr["GroupCode"].ToString();
                model.GroupName = (dr["GroupName"] is DBNull) ? string.Empty : dr["GroupName"].ToString();
                model.GroupDesc = (dr["GroupDesc"] is DBNull) ? string.Empty : dr["GroupDesc"].ToString();
                model.ParentCode = (dr["ParentCode"] is DBNull) ? string.Empty : dr["ParentCode"].ToString();
                model.Status = (dr["Status"] is DBNull) ? 0 : Convert.ToInt32(dr["Status"].ToString());
                model.CompanyId = (dr["CompanyId"] is DBNull) ? 0 : Convert.ToInt32(dr["CompanyId"].ToString());
                model.UpdateFlag = (dr["UpdateFlag"] is DBNull) ? 0 : Convert.ToInt32(dr["UpdateFlag"].ToString());
            }
            catch
            {
                return null;
            }
            return model;
        }

        /// <summary>
        /// 根据分组编码查询
        /// </summary>
        public T_DTU_GroupEx GetGroupByCode(string groupCode)
        {
            T_DTU_GroupEx group = new T_DTU_GroupEx();
            StringBuilder sb = new StringBuilder();
            sb.Append("select a.[GroupCode] ,a.[GroupName],a.[GroupDesc],a.[ParentCode] ,a.[Status],a.[CompanyId],a.[UpdateFlag],b.GroupName as ParentName ");
            sb.Append("from [Infa]..[T_DTU_Group] as a left join [Infa]..[T_DTU_Group] as b on a.ParentCode=b.GroupCode where a.GroupCode=@GroupCode and a.Status=1 ");
            SqlParameter[] parameters = { 
                           new SqlParameter("@GroupCode",groupCode)
                                        };
            using (SqlDataReader reader = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyRead, System.Data.CommandType.Text, sb.ToString(), parameters))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        var model = IDataT_DTU_GroupExReader(reader);
                        group = model;
                    }
                }
            }
            return group;
        }

        //判断指定分组下是否含有站点
        public bool IsGroupHasSite(string groupCode)
        {
            bool result = false;
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from [Infa]..[T_DTU] where GroupCode=@GroupCode");
            SqlParameter[] parameters = { 
                           new SqlParameter("@GroupCode",groupCode)             
                                        };
            int count = SqlHelper.DBHelper.ExecuteNonQuery(SqlHelper.DBHelper.OnlyRead, CommandType.Text, sb.ToString(), parameters);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
