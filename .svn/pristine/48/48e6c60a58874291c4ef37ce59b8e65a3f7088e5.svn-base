using Com.Winfotian.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Com.Winfotian.DB.Provider
{
    //用户--用户角色
    public class UserUserRoleProvider
    {

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserId, string RoleCode)
        {
            int sum = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from [Infa]..[T_User_UserRole]");
                strSql.Append(" where UserId=@UserId and RoleCode=@RoleCode ");
                SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.VarChar,50),
					new SqlParameter("@RoleCode", SqlDbType.VarChar,50)};
                parameters[0].Value = UserId;
                parameters[1].Value = RoleCode;

                using (var reader = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyRead, CommandType.Text, strSql.ToString(), parameters))
                {
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            sum = Convert.ToInt32(reader[0].ToString());
                        }
                    }
                }
            }
            catch 
            { }
            if (sum == 0)
            { return true; }
            else
            { return false; }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(T_User_UserRole model)
        {
            bool rslt = false;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into [Infa]..[T_User_UserRole](");
                strSql.Append("UserId,RoleCode,Status)");
                strSql.Append(" values (");
                strSql.Append("@UserId,@RoleCode,@Status)");
                SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.VarChar,30),
					new SqlParameter("@RoleCode", SqlDbType.VarChar,30),
					new SqlParameter("@Status", SqlDbType.SmallInt,2)};
                parameters[0].Value = model.UserId;
                parameters[1].Value = model.RoleCode;
                parameters[2].Value = model.Status;
                int num = SqlHelper.DBHelper.ExecuteNonQuery(SqlHelper.DBHelper.OnlyWrite, CommandType.Text, strSql.ToString(), parameters);
                if (num == 1)
                { rslt = true; }

            }
            catch { }
            return rslt;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(T_User_UserRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Infa]..[T_User_UserRole] set ");
            strSql.Append("Status=@Status");
            strSql.Append(" where UserId=@UserId and RoleCode=@RoleCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@UserId", SqlDbType.VarChar,30),
					new SqlParameter("@RoleCode", SqlDbType.VarChar,30)};
            parameters[0].Value = model.Status;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.RoleCode;

            int rows = SqlHelper.DBHelper.ExecuteNonQuery(SqlHelper.DBHelper.OnlyWrite, CommandType.Text, strSql.ToString(), parameters);
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
        public bool Delete(string UserId, string RoleCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [Infa]..[T_User_UserRole] ");
            strSql.Append(" where UserId=@UserId and RoleCode=@RoleCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.VarChar,50),
					new SqlParameter("@RoleCode", SqlDbType.VarChar,50)};
            parameters[0].Value = UserId;
            parameters[1].Value = RoleCode;

            int rows = SqlHelper.DBHelper.ExecuteNonQuery(SqlHelper.DBHelper.OnlyWrite, CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetRoleByUserId(string UserId)
        {
            string rslt = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleCode from [Infa]..[T_User_UserRole] where UserId=@UserId ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", UserId)};
            using (IDataReader dr = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyRead, CommandType.Text, strSql.ToString(), parameters))
            {
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        rslt = dr["RoleCode"].ToString();
                        break;
                    }
                }
            }
            return rslt;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public T_User_UserRole GetModel(string UserId, string RoleCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserId,RoleCode,Status from [Infa]..[T_User_UserRole] ");
            strSql.Append(" where UserId=@UserId and RoleCode=@RoleCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.VarChar,50),
					new SqlParameter("@RoleCode", SqlDbType.VarChar,50)};
            parameters[0].Value = UserId;
            parameters[1].Value = RoleCode;

            T_User_UserRole model = null;
            using (IDataReader dr = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyRead, CommandType.Text, strSql.ToString(), parameters))
            {
                if (dr.Read())
                {
                    model = IDataT_User_UserRoleReader(dr);
                }
            }
            return model;
        }



        /// <summary>
        /// T_User_UserRole 数据读取
        /// </summary>
        private T_User_UserRole IDataT_User_UserRoleReader(IDataReader dr)
        {
            T_User_UserRole model = new T_User_UserRole();
            try
            {
                model.UserId = (dr["UserId"] is DBNull) ? string.Empty : dr["UserId"].ToString();
                model.RoleCode = (dr["RoleCode"] is DBNull) ? string.Empty : dr["RoleCode"].ToString();
                model.Status = (dr["Status"] is DBNull) ? 0 : Convert.ToInt32(dr["Status"].ToString());
            }
            catch 
            {
                //WebLog.WSLogger.Error(ex.Message);//Please add references(log4net.dll)
                return null;
            }
            return model;
        }
    }
}
