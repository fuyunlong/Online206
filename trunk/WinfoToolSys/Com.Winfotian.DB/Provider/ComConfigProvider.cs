﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Winfotian.DB.SqlHelper;
using Com.Winfotian.Model;
 

namespace Com.Winfotian.DB
{
    internal class ComConfigProvider  
    { 
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add( T_Company_CmpConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Infa]..[T_Company_CmpConfig](");
			strSql.Append("CompanyId,ConfigId,Status)");
			strSql.Append(" values (");
			strSql.Append("@CompanyId,@ConfigId,@Status)");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyId", SqlDbType.Int,4),
					new SqlParameter("@ConfigId", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.SmallInt,2)};
			parameters[0].Value = model.CompanyId;
			parameters[1].Value = model.ConfigId;
			parameters[2].Value = model.Status;

			  DBHelper.ExecuteNonQuery(DBHelper.OnlyWrite, CommandType.Text, strSql.ToString(), parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( T_Company_CmpConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Infa]..[T_Company_CmpConfig] set ");
			strSql.Append("CompanyId=@CompanyId,");
			strSql.Append("ConfigId=@ConfigId,");
			strSql.Append("Status=@Status");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyId", SqlDbType.Int,4),
					new SqlParameter("@ConfigId", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.SmallInt,2)};
			parameters[0].Value = model.CompanyId;
			parameters[1].Value = model.ConfigId;
			parameters[2].Value = model.Status;

			int rows= 	  DBHelper.ExecuteNonQuery(DBHelper.OnlyWrite, CommandType.Text, strSql.ToString(), parameters);
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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Infa]..[T_Company_CmpConfig] ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
};

			int rows=	  DBHelper.ExecuteNonQuery(DBHelper.OnlyWrite, CommandType.Text, strSql.ToString(), parameters);
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
		/// T_Company_CmpConfig 数据读取
		/// </summary>
		private  T_Company_CmpConfig IDataT_Company_CmpConfigReader(IDataReader dr)
		{
			 T_Company_CmpConfig model = new  T_Company_CmpConfig();
			try
			{
				model.CompanyId = (dr["CompanyId"] is DBNull)? 0 : Convert.ToInt32(dr["CompanyId"].ToString());
				model.ConfigId = (dr["ConfigId"] is DBNull)? 0 : Convert.ToInt32(dr["ConfigId"].ToString());
				model.Status = (dr["Status"] is DBNull)? 0 : Convert.ToInt32(dr["Status"].ToString());
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
