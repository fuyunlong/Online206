﻿using Com.Winfotian.Common;
using Com.Winfotian.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Com.Winfotian.DB.Provider
{
    public class UserUserGropProvider
    {

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserId, string GroupCode)
        {
            int num = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Infa]..[T_User_UserGroup]");
            strSql.Append(" where UserId=@UserId and GroupCode=@GroupCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.VarChar,50),
					new SqlParameter("@GroupCode", SqlDbType.VarChar,50)};
            parameters[0].Value = UserId;
            parameters[1].Value = GroupCode;
            using (IDataReader reader = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyRead, CommandType.Text, strSql.ToString(), parameters))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader[0].ToString(), out num);
                    }
                }
            }
            if (num > 0)
            {
                return true;
            }
            else
            { return false; }
        }

        public string GetUserGroupCodeByUserId(string UserId)
        {
            string rslt="";
            StringBuilder SqlStr = new StringBuilder();
            SqlStr.Append("select GroupCode from [Infa]..[T_User_UserGroup] where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", UserId)};
            using (IDataReader dr = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyWrite, CommandType.Text, SqlStr.ToString(), parameters))
            {
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        rslt = dr["GroupCode"].ToString();
                    }
                }
            }
            return rslt;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(T_User_UserGroup model)
        {
            bool rslt = false;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into [Infa]..[T_User_UserGroup](");
                strSql.Append("UserId,GroupCode,Status)");
                strSql.Append(" values (");
                strSql.Append("@UserId,@GroupCode,@Status)");
                SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.VarChar,30),
					new SqlParameter("@GroupCode", SqlDbType.VarChar,30),
					new SqlParameter("@Status", SqlDbType.SmallInt,2)};
                parameters[0].Value = model.UserId;
                parameters[1].Value = model.GroupCode;
                parameters[2].Value = model.Status;
                int num = SqlHelper.DBHelper.ExecuteNonQuery(SqlHelper.DBHelper.OnlyWrite, CommandType.Text, strSql.ToString(), parameters);
                if (num > 0)
                {
                    rslt = true;
                }
            }
            catch 
            { }
            return rslt;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(T_User_UserGroup model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Infa]..[T_User_UserGroup] set ");
            strSql.Append("Status=@Status");
            strSql.Append(" where UserId=@UserId and GroupCode=@GroupCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@UserId", SqlDbType.VarChar,30),
					new SqlParameter("@GroupCode", SqlDbType.VarChar,30)};
            parameters[0].Value = model.Status;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.GroupCode;
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
        public bool Delete(string UserId, string GroupCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [Infa]..[T_User_UserGroup] ");
            strSql.Append(" where UserId=@UserId and GroupCode=@GroupCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.VarChar,50),
					new SqlParameter("@GroupCode", SqlDbType.VarChar,50)};
            parameters[0].Value = UserId;
            parameters[1].Value = GroupCode;

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
        /// 得到一个对象实体
        /// </summary>
        public T_User_UserGroup GetModel(string UserId, string GroupCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserId,GroupCode,Status from [Infa]..[T_User_UserGroup] ");
            strSql.Append(" where UserId=@UserId and GroupCode=@GroupCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.VarChar,50),
					new SqlParameter("@GroupCode", SqlDbType.VarChar,50)};
            parameters[0].Value = UserId;
            parameters[1].Value = GroupCode;

            T_User_UserGroup model = null;
            using (IDataReader dr = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyWrite, CommandType.Text, strSql.ToString(), parameters))
            {
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        model = IDataT_User_UserGroupReader(dr);
                    }
                }
            }
            return model;
        }


        /// <summary>
        /// T_User_UserGroup 数据读取
        /// </summary>
        private T_User_UserGroup IDataT_User_UserGroupReader(IDataReader dr)
        {
            T_User_UserGroup model = new T_User_UserGroup();
            try
            {
                model.UserId = (dr["UserId"] is DBNull) ? string.Empty : dr["UserId"].ToString();
                model.GroupCode = (dr["GroupCode"] is DBNull) ? string.Empty : dr["GroupCode"].ToString();
                model.Status = (dr["Status"] is DBNull) ? 0 : Convert.ToInt32(dr["Status"].ToString());
            }
            catch  
            {

                return null;
            }
            return model;
        }

        public List<T_User_UserGroup> GetUserUserGroupList(string GroupCode)
        {
            List<T_User_UserGroup> list = new List<T_User_UserGroup>();
            try
            {
                StringBuilder SqlStr = new StringBuilder();
                SqlStr.Append("select * from [Infa]..[T_User_UserGroup]");
                if (GroupCode != "0")
                { SqlStr.Append(" where GroupCode=@GroupCode "); }
                SqlParameter[] pars = { 
                                      new SqlParameter("@GroupCode",GroupCode)
                                      };
                using (IDataReader dr = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyWrite, CommandType.Text, SqlStr.ToString(), pars))
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            var model = IDataT_User_UserGroupReader(dr);
                            if (model != null)
                            {
                                list.Add(model);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), "", ex);
            }
            return list;
        }
    }
}