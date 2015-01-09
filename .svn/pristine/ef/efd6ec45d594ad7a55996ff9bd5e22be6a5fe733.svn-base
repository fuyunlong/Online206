using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Com.Winfotian.Common;
using Com.Winfotian.DB.SqlHelper;
using Com.Winfotian.Model;

namespace Com.Winfotian.DB.Provider
{
    public class CityInfoProvider
    {
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(T_CityInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [Infa]..[T_CityInfo](");
            strSql.Append("Province,CityName,PhoneCode,PostCode)");
            strSql.Append(" values (");
            strSql.Append("@Province,@CityName,@PhoneCode,@PostCode)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Province", SqlDbType.NVarChar,30),
					new SqlParameter("@CityName", SqlDbType.NVarChar,20),
					new SqlParameter("@PhoneCode", SqlDbType.VarChar,5),
					new SqlParameter("@PostCode", SqlDbType.VarChar,10)};
            parameters[0].Value = model.Province;
            parameters[1].Value = model.CityName;
            parameters[2].Value = model.PhoneCode;
            parameters[3].Value = model.PostCode;

            object obj = DBHelper.ExecuteNonQuery(DBHelper.OnlyWrite, CommandType.Text, strSql.ToString(), parameters);
            if(obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(T_CityInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Infa]..[T_CityInfo] set ");
            strSql.Append("Province=@Province,");
            strSql.Append("CityName=@CityName,");
            strSql.Append("PhoneCode=@PhoneCode,");
            strSql.Append("PostCode=@PostCode");
            strSql.Append(" where CityId=@CityId");
            SqlParameter[] parameters = {
					new SqlParameter("@Province", SqlDbType.NVarChar,30),
					new SqlParameter("@CityName", SqlDbType.NVarChar,20),
					new SqlParameter("@PhoneCode", SqlDbType.VarChar,5),
					new SqlParameter("@PostCode", SqlDbType.VarChar,10),
					new SqlParameter("@CityId", SqlDbType.Int,4)};
            parameters[0].Value = model.Province;
            parameters[1].Value = model.CityName;
            parameters[2].Value = model.PhoneCode;
            parameters[3].Value = model.PostCode;
            parameters[4].Value = model.CityId;

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
        public bool Delete(int CityId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [Infa]..[T_CityInfo] ");
            strSql.Append(" where CityId=@CityId");
            SqlParameter[] parameters = {
					new SqlParameter("@CityId", SqlDbType.Int,4)
};
            parameters[0].Value = CityId;

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
        public T_CityInfo GetModel(int CityId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CityId,Province,CityName,PhoneCode,PostCode from [Infa]..[T_CityInfo] ");
            strSql.Append(" where CityId=@CityId");
            SqlParameter[] parameters = {
					new SqlParameter("@CityId", SqlDbType.Int,4)
};
            parameters[0].Value = CityId;

            T_CityInfo model = null;
            using(IDataReader dr = DBHelper.ExecuteReader(DBHelper.OnlyRead, CommandType.Text, strSql.ToString(), parameters))
            {
                if(dr.Read())
                {
                    model = IDataT_CityInfoReader(dr);
                }
            }
            return model;
        }


        /// <summary>
        /// T_CityInfo 数据读取
        /// </summary>
        private T_CityInfo IDataT_CityInfoReader(IDataReader dr)
        {
            T_CityInfo model = new T_CityInfo();
            try
            {
                model.CityId = (dr["CityId"] is DBNull) ? 0 : Convert.ToInt32(dr["CityId"].ToString());
                model.Province = (dr["Province"] is DBNull) ? string.Empty : dr["Province"].ToString();
                model.CityName = (dr["CityName"] is DBNull) ? string.Empty : dr["CityName"].ToString();
                model.PhoneCode = (dr["PhoneCode"] is DBNull) ? string.Empty : dr["PhoneCode"].ToString();
                model.PostCode = (dr["PostCode"] is DBNull) ? string.Empty : dr["PostCode"].ToString();
            }
            catch 
            {
                //WebLog.WSLogger.Error(ex.Message);//Please add references(log4net.dll)
                return null;
            }
            return model;
        }

        public List<string> GetProvinceList()
        {
            List<string> Provinces = new List<string>();
            try
            {
                StringBuilder Str = new StringBuilder();
                Str.Append("SELECT  distinct Province FROM [Infa]..[T_CityInfo]");
                using(SqlDataReader reader = DBHelper.ExecuteReader(DBHelper.OnlyRead, CommandType.Text, Str.ToString(), null))
                {
                    if(reader != null)
                    {
                        while(reader.Read())
                        {
                            Provinces.Add(reader["Province"] == DBNull.Value ? "" : reader["Province"].ToString());
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), "", ex);

            }
            return Provinces;
        }


        public List<T_CityInfo> GetCityList(string Province)
        {
            List<T_CityInfo> citys = new List<T_CityInfo>();
            try
            {
                StringBuilder Str = new StringBuilder();
                Str.Append("select CityId,CityName from [Infa]..[T_CityInfo]");
                if(Province == "null" || Province.Length == 0)
                {

                }
                else
                {
                    Str.Append(" where Province=@Province ");
                }
                SqlParameter[] pars ={
                                new SqlParameter("@Province",Province)
                                };
                using(SqlDataReader reader = DBHelper.ExecuteReader(DBHelper.OnlyRead, CommandType.Text, Str.ToString(), pars))
                {
                    if(reader != null)
                    {
                        while(reader.Read())
                        {
                            citys.Add(new T_CityInfo
                            {
                                CityId = Convert.ToInt32(reader["CityId"].ToString()),
                                CityName = reader["CityName"].ToString()
                            });
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), "", ex);
            }
            return citys;
        }
        #endregion  Method
    }
}
