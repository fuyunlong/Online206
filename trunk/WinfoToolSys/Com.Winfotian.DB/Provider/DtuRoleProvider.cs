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
    public class DtuRoleProvider
    {


        public List<T_User_Role> GetRoleList(string RoleName)
        {
            List<T_User_Role> list = new List<T_User_Role>();
            try
            {
                StringBuilder SqlStr = new StringBuilder();
                SqlStr.Append("select * from [Infa]..[T_User_Role]");
                SqlStr.Append(" where Status=1");
                if (!string.IsNullOrWhiteSpace(RoleName) && RoleName.Length > 0)
                {
                    LogBLL.WriteOperatorLog(WinManager.GetPublicIP(), "", "参数不为空" + RoleName, 1);
                    SqlStr.Append(" and RoleName like @RoleName ");
                }
                SqlParameter[] pars = {
                                      new SqlParameter("@RoleName",RoleName+"%")
                                      };
                using (var dr = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyRead, CommandType.Text, SqlStr.ToString(), pars))
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            var model = IDataT_User_RoleReader(dr);
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


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(T_User_Role model)
        {
            int rslt = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into [Infa]..[T_User_Role](");
                strSql.Append("RoleCode,RoleName,RoleDesc,Status,UpdateFlag)");
                strSql.Append(" values (");
                strSql.Append("@RoleCode,@RoleName,@RoleDesc,@Status,@UpdateFlag)");
                SqlParameter[] parameters = {
					new SqlParameter("@RoleCode", SqlDbType.VarChar,30),
					new SqlParameter("@RoleName", SqlDbType.VarChar,50),
					new SqlParameter("@RoleDesc", SqlDbType.VarChar,50),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@UpdateFlag", SqlDbType.Int,4)};
                parameters[0].Value = model.RoleCode;
                parameters[1].Value = model.RoleName;
                parameters[2].Value = model.RoleDesc;
                parameters[3].Value = model.Status;
                parameters[4].Value = model.UpdateFlag;
                rslt = SqlHelper.DBHelper.ExecuteNonQuery(SqlHelper.DBHelper.OnlyWrite, CommandType.Text, strSql.ToString(), parameters);
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), "", ex);
            }
            return rslt;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(T_User_Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Infa]..[T_User_Role] set ");
            strSql.Append("RoleName=@RoleName,");
            strSql.Append("RoleDesc=@RoleDesc,");
            strSql.Append("Status=@Status,");
            strSql.Append("UpdateFlag=@UpdateFlag");
            strSql.Append(" where RoleCode=@RoleCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.VarChar,50),
					new SqlParameter("@RoleDesc", SqlDbType.VarChar,50),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@UpdateFlag", SqlDbType.Int,4),
					new SqlParameter("@RoleCode", SqlDbType.VarChar,30)};
            parameters[0].Value = model.RoleName;
            parameters[1].Value = model.RoleDesc;
            parameters[2].Value = model.Status;
            parameters[3].Value = model.UpdateFlag;
            parameters[4].Value = model.RoleCode;

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

        public bool DeleteRoleUser(string RoleCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  [Infa]..[T_User_UserRole] where RoleCode=@RoleCode ");
            SqlParameter[] parameters = { 
                                        new SqlParameter("@RoleCode",RoleCode)};
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
        public bool Delete(string RoleCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [Infa]..[T_User_Role] ");
            strSql.Append(" where RoleCode=@RoleCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleCode", SqlDbType.VarChar,50)};
            parameters[0].Value = RoleCode;

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
        public T_User_Role GetModel(string RoleCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RoleCode,RoleName,RoleDesc,Status,UpdateFlag from [Infa]..[T_User_Role] ");
            strSql.Append(" where RoleCode=@RoleCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleCode", SqlDbType.VarChar,50)};
            parameters[0].Value = RoleCode;

            T_User_Role model = null;
            using (IDataReader dr = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyRead, CommandType.Text, strSql.ToString(), parameters))
            {
                if (dr.Read())
                {
                    model = IDataT_User_RoleReader(dr);
                }
            }
            return model;
        }



        /// <summary>
        /// T_User_Role 数据读取
        /// </summary>
        private T_User_Role IDataT_User_RoleReader(IDataReader dr)
        {
            T_User_Role model = new T_User_Role();
            try
            {
                model.RoleCode = (dr["RoleCode"] is DBNull) ? string.Empty : dr["RoleCode"].ToString();
                model.RoleName = (dr["RoleName"] is DBNull) ? string.Empty : dr["RoleName"].ToString();
                model.RoleDesc = (dr["RoleDesc"] is DBNull) ? string.Empty : dr["RoleDesc"].ToString();
                model.Status = (dr["Status"] is DBNull) ? 0 : Convert.ToInt32(dr["Status"].ToString());
                model.UpdateFlag = (dr["UpdateFlag"] is DBNull) ? 0 : Convert.ToInt32(dr["UpdateFlag"].ToString());
            }
            catch 
            {

                return null;
            }
            return model;
        }
    }
}
