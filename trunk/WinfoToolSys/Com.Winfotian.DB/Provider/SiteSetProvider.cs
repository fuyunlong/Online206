﻿using Com.Winfotian.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Com.Winfotian.DB.Provider
{
    //站点配置
    public class SiteSetProvider
    {

 

        /// 增加一条数据
        public void Add(T_DTU_Config model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [Infa]..[T_DTU_Config](");
            strSql.Append("ConfigCode,ConfigName,ConfigDesc,FlowNum,AINum,DINum,IsAlert,IsCreate,Status,UpdateFlag,BoardInfo,CType)");
            strSql.Append(" values (");
            strSql.Append("@ConfigCode,@ConfigName,@ConfigDesc,@FlowNum,@AINum,@DINum,@IsAlert,@IsCreate,@Status,@UpdateFlag,@BoardInfo,@CType)");
            SqlParameter[] parameters = {
					new SqlParameter("@ConfigCode", SqlDbType.VarChar,30),
					new SqlParameter("@ConfigName", SqlDbType.VarChar,50),
					new SqlParameter("@ConfigDesc", SqlDbType.VarChar,100),
					new SqlParameter("@FlowNum", SqlDbType.SmallInt,2),
					new SqlParameter("@AINum", SqlDbType.SmallInt,2),
					new SqlParameter("@DINum", SqlDbType.SmallInt,2),
					new SqlParameter("@IsAlert", SqlDbType.SmallInt,2),
					new SqlParameter("@IsCreate", SqlDbType.SmallInt,2),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@UpdateFlag", SqlDbType.Int,4),
					new SqlParameter("@BoardInfo", SqlDbType.VarChar,400),
					new SqlParameter("@CType", SqlDbType.SmallInt,2)};
            parameters[0].Value = model.ConfigCode;
            parameters[1].Value = model.ConfigName;
            parameters[2].Value = model.ConfigDesc;
            parameters[3].Value = model.FlowNum;
            parameters[4].Value = model.AINum;
            parameters[5].Value = model.DINum;
            parameters[6].Value = model.IsAlert;
            parameters[7].Value = model.IsCreate;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.UpdateFlag;
            parameters[10].Value = model.BoardInfo;
            parameters[11].Value = model.CType;

            SqlHelper.DBHelper.ExecuteNonQuery(SqlHelper.DBHelper.OnlyWrite, CommandType.Text, strSql.ToString(), parameters);
        }
     
 
        /// 更新一条数据
        public bool Update(T_DTU_Config model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Infa]..[T_DTU_Config] set ");
            strSql.Append("ConfigName=@ConfigName,");
            strSql.Append("ConfigDesc=@ConfigDesc,");
            strSql.Append("FlowNum=@FlowNum,");
            strSql.Append("AINum=@AINum,");
            strSql.Append("DINum=@DINum,");
            strSql.Append("IsAlert=@IsAlert,");
            strSql.Append("IsCreate=@IsCreate,");
            strSql.Append("Status=@Status,");
            strSql.Append("UpdateFlag=@UpdateFlag,");
            strSql.Append("BoardInfo=@BoardInfo,");
            strSql.Append("CType=@CType");
            strSql.Append(" where ConfigCode=@ConfigCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ConfigName", SqlDbType.VarChar,50),
					new SqlParameter("@ConfigDesc", SqlDbType.VarChar,100),
					new SqlParameter("@FlowNum", SqlDbType.SmallInt,2),
					new SqlParameter("@AINum", SqlDbType.SmallInt,2),
					new SqlParameter("@DINum", SqlDbType.SmallInt,2),
					new SqlParameter("@IsAlert", SqlDbType.SmallInt,2),
					new SqlParameter("@IsCreate", SqlDbType.SmallInt,2),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@UpdateFlag", SqlDbType.Int,4),
					new SqlParameter("@BoardInfo", SqlDbType.VarChar,400),
					new SqlParameter("@CType", SqlDbType.SmallInt,2),
					new SqlParameter("@ConfigCode", SqlDbType.VarChar,30)};
            parameters[0].Value = model.ConfigName;
            parameters[1].Value = model.ConfigDesc;
            parameters[2].Value = model.FlowNum;
            parameters[3].Value = model.AINum;
            parameters[4].Value = model.DINum;
            parameters[5].Value = model.IsAlert;
            parameters[6].Value = model.IsCreate;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.UpdateFlag;
            parameters[9].Value = model.BoardInfo;
            parameters[10].Value = model.CType;
            parameters[11].Value = model.ConfigCode;

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

        /// 删除一条数据
        public bool Delete(string ConfigCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [Infa]..[T_DTU_Config] ");
            strSql.Append(" where ConfigCode=@ConfigCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ConfigCode", SqlDbType.VarChar,50)};
            parameters[0].Value = ConfigCode;

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


        /// 得到一个对象实体
        public T_DTU_Config GetModel(string ConfigCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ConfigCode,ConfigName,ConfigDesc,FlowNum,AINum,DINum,IsAlert,IsCreate,Status,UpdateFlag,BoardInfo,CType from [Infa]..[T_DTU_Config] ");
            strSql.Append(" where ConfigCode=@ConfigCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ConfigCode", SqlDbType.VarChar,50)};
            parameters[0].Value = ConfigCode;

            T_DTU_Config model = null;
            using (IDataReader dr = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyRead, CommandType.Text, strSql.ToString(), parameters))
            {
                if (dr.Read())
                {
                    model = IDataT_DTU_ConfigReader(dr);
                }
            }
            return model;
        }

      
        /// T_DTU_Config 数据读取
        private T_DTU_Config IDataT_DTU_ConfigReader(IDataReader dr)
        {
            T_DTU_Config model = new T_DTU_Config();
            try
            {
                model.ConfigCode = (dr["ConfigCode"] is DBNull) ? string.Empty : dr["ConfigCode"].ToString();
                model.ConfigName = (dr["ConfigName"] is DBNull) ? string.Empty : dr["ConfigName"].ToString();
                model.ConfigDesc = (dr["ConfigDesc"] is DBNull) ? string.Empty : dr["ConfigDesc"].ToString();
                model.FlowNum = (dr["FlowNum"] is DBNull) ? 0 : Convert.ToInt32(dr["FlowNum"].ToString());
                model.AINum = (dr["AINum"] is DBNull) ? 0 : Convert.ToInt32(dr["AINum"].ToString());
                model.DINum = (dr["DINum"] is DBNull) ? 0 : Convert.ToInt32(dr["DINum"].ToString());
                model.IsAlert = (dr["IsAlert"] is DBNull) ? 0 : Convert.ToInt32(dr["IsAlert"].ToString());
                model.IsCreate = (dr["IsCreate"] is DBNull) ? 0 : Convert.ToInt32(dr["IsCreate"].ToString());
                model.Status = (dr["Status"] is DBNull) ? 0 : Convert.ToInt32(dr["Status"].ToString());
                model.UpdateFlag = (dr["UpdateFlag"] is DBNull) ? 0 : Convert.ToInt32(dr["UpdateFlag"].ToString());
                model.BoardInfo = (dr["BoardInfo"] is DBNull) ? string.Empty : dr["BoardInfo"].ToString();
                model.CType = (dr["CType"] is DBNull) ? 0 : Convert.ToInt32(dr["CType"].ToString());
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