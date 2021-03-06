﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Com.Winfotian.DB.SqlHelper;
using Com.Winfotian.Model;

namespace Com.Winfotian.DB.Provider
{
    class BusinessSystemProvider
    {


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(T_BusinessSystem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [Infa]..[T_BusinessSystem](");
            strSql.Append("BusinessSystemID,BusinessSystemName,BusinessSystemDescribe,BusType)");
            strSql.Append(" values (");
            strSql.Append("@BusinessSystemID,@BusinessSystemName,@BusinessSystemDescribe,@BusType)");
            SqlParameter[] parameters = {
					new SqlParameter("@BusinessSystemID", SqlDbType.VarChar,30),
					new SqlParameter("@BusinessSystemName", SqlDbType.VarChar,50),
					new SqlParameter("@BusinessSystemDescribe", SqlDbType.VarChar,150),
					new SqlParameter("@BusType", SqlDbType.VarChar,10)};
            parameters[0].Value = model.BusinessSystemID;
            parameters[1].Value = model.BusinessSystemName;
            parameters[2].Value = model.BusinessSystemDescribe;
            parameters[3].Value = model.BusType;

            DBHelper.ExecuteNonQuery(DBHelper.OnlyWrite, CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(T_BusinessSystem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Infa]..[T_BusinessSystem] set ");
            strSql.Append("BusinessSystemName=@BusinessSystemName,");
            strSql.Append("BusinessSystemDescribe=@BusinessSystemDescribe,");
            strSql.Append("BusType=@BusType");
            strSql.Append(" where BusinessSystemID=@BusinessSystemID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BusinessSystemName", SqlDbType.VarChar,50),
					new SqlParameter("@BusinessSystemDescribe", SqlDbType.VarChar,150),
					new SqlParameter("@BusType", SqlDbType.VarChar,10),
					new SqlParameter("@BusinessSystemID", SqlDbType.VarChar,30)};
            parameters[0].Value = model.BusinessSystemName;
            parameters[1].Value = model.BusinessSystemDescribe;
            parameters[2].Value = model.BusType;
            parameters[3].Value = model.BusinessSystemID;

            int rows = DBHelper.ExecuteNonQuery(DBHelper.OnlyWrite, CommandType.Text, strSql.ToString(), parameters);
            if(rows > 0)
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
        public bool Delete(string BusinessSystemID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [Infa]..[T_BusinessSystem] ");
            strSql.Append(" where BusinessSystemID=@BusinessSystemID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BusinessSystemID", SqlDbType.VarChar,50)};
            parameters[0].Value = BusinessSystemID;

            int rows = DBHelper.ExecuteNonQuery(DBHelper.OnlyWrite, CommandType.Text, strSql.ToString(), parameters);
            if(rows > 0)
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
        public T_BusinessSystem GetModel(string BusinessSystemID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BusinessSystemID,BusinessSystemName,BusinessSystemDescribe,BusType from [Infa]..[T_BusinessSystem] ");
            strSql.Append(" where BusinessSystemID=@BusinessSystemID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BusinessSystemID", SqlDbType.VarChar,50)};
            parameters[0].Value = BusinessSystemID;

            T_BusinessSystem model = null;
            using(IDataReader dr = DBHelper.ExecuteReader(DBHelper.OnlyRead, CommandType.Text, strSql.ToString(), parameters))
            {
                if(dr.Read())
                {
                    model = IDataT_BusinessSystemReader(dr);
                }
            }
            return model;
        }


        /// <summary>
        /// T_BusinessSystem 数据读取
        /// </summary>
        private T_BusinessSystem IDataT_BusinessSystemReader(IDataReader dr)
        {
            T_BusinessSystem model = new T_BusinessSystem();
            try
            {
                model.BusinessSystemID = (dr["BusinessSystemID"] is DBNull) ? string.Empty : dr["BusinessSystemID"].ToString();
                model.BusinessSystemName = (dr["BusinessSystemName"] is DBNull) ? string.Empty : dr["BusinessSystemName"].ToString();
                model.BusinessSystemDescribe = (dr["BusinessSystemDescribe"] is DBNull) ? string.Empty : dr["BusinessSystemDescribe"].ToString();
                model.BusType = (dr["BusType"] is DBNull) ? string.Empty : dr["BusType"].ToString();
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
