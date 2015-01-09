using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Com.Winfotian.Model;

namespace Com.Winfotian.DB.Provider
{
    public class UserSettingProvider
    {
        //根据用户配置名称查询配置信息
        public List<T_User_Config> GetListByName(string configName)
        {
            List<T_User_Config> list = new List<T_User_Config>();
            StringBuilder sb = new StringBuilder();
            sb.Append("select CCode,ConfigName,ConfigDesc,SoftInterval,IsAlert,IsRpt,Status,PopCode,UpdateFlag from [Infa]..[T_User_Config] where Status=1 ");
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(configName))
            {
                sb.Append("and ConfigName like @ConfigName");
                parameters.Add(new SqlParameter("@ConfigName", "%" + configName + "%"));
            }
            using (SqlDataReader reader = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyRead, CommandType.Text, sb.ToString(), parameters.ToArray()))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        var model = IDataReaderT_User_Config(reader);
                        if (model != null)
                        {
                            list.Add(new T_User_Config
                            {
                                CCode = model.CCode,
                                ConfigName = model.ConfigName,
                                ConfigDesc = model.ConfigDesc,
                                SoftInterval = model.SoftInterval,
                                IsAlert = model.IsAlert,
                                IsRpt = model.IsRpt,
                                Status = model.Status,
                                PopCode = model.PopCode,
                                UpdateFlag = model.UpdateFlag,
                            });
                        }
                    }
                }
            }
            return list;
        }

        public List<T_User_Config> GetList()
        {
            List<T_User_Config> list = new List<T_User_Config>();
            StringBuilder sb = new StringBuilder();
            sb.Append("select CCode,ConfigName,ConfigDesc,SoftInterval,IsAlert,IsRpt,Status,PopCode,UpdateFlag from [Infa]..[T_User_Config] where Status=1 ");
            using (SqlDataReader reader = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyRead, CommandType.Text, sb.ToString(), null))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        var model = IDataReaderT_User_Config(reader);
                        if (model != null)
                        {
                            list.Add(new T_User_Config
                            {
                                CCode = model.CCode,
                                ConfigName = model.ConfigName,
                                ConfigDesc = model.ConfigDesc,
                                SoftInterval = model.SoftInterval,
                                IsAlert = model.IsAlert,
                                IsRpt = model.IsRpt,
                                Status = model.Status,
                                PopCode = model.PopCode,
                                UpdateFlag = model.UpdateFlag,
                            });
                        }
                    }
                }
            }
            return list;
        }

        //根据分组编码查询
        public T_User_Config GetConfigByCode(string cCode)
        {
            T_User_Config config = new T_User_Config();
            StringBuilder sb = new StringBuilder();
            sb.Append("select CCode,ConfigName,ConfigDesc,SoftInterval,IsAlert,IsRpt,Status,PopCode,UpdateFlag from [Infa]..[T_User_Config] where Status=1 and CCode=@CCode");
            SqlParameter[] parameters = { 
                           new SqlParameter("@CCode",cCode)
                                  };
            using (SqlDataReader reader = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyRead, CommandType.Text, sb.ToString(), parameters))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        var model = IDataReaderT_User_Config(reader);
                        if (model != null)
                        {
                            config.CCode = model.CCode;
                            config.ConfigName = model.ConfigName;
                            config.ConfigDesc = model.ConfigDesc;
                            config.SoftInterval = model.SoftInterval;
                            config.IsAlert = model.IsAlert;
                            config.IsRpt = model.IsRpt;
                            config.Status = model.Status;
                            config.PopCode = model.PopCode;
                            config.UpdateFlag = model.UpdateFlag;
                        }
                    }
                }
            }
            return config;
        }

        //T_User_Config数据读取
        private T_User_Config IDataReaderT_User_Config(IDataReader dr)
        {
            T_User_Config model = new T_User_Config();
            try
            {
                model.CCode = (dr["CCode"] is DBNull) ? string.Empty : dr["CCode"].ToString();
                model.ConfigName = (dr["ConfigName"] is DBNull) ? string.Empty : dr["ConfigName"].ToString();
                model.ConfigDesc = (dr["ConfigDesc"] is DBNull) ? string.Empty : dr["ConfigDesc"].ToString();
                model.SoftInterval = (dr["SoftInterval"] is DBNull) ? 0 : Convert.ToInt32(dr["SoftInterval"]);
                model.IsAlert = (dr["IsAlert"] is DBNull) ? 0 : Convert.ToInt32(dr["IsAlert"]);
                model.IsRpt = (dr["IsRpt"] is DBNull) ? 0 : Convert.ToInt32(dr["IsRpt"]);
                model.Status = (dr["Status"] is DBNull) ? 0 : Convert.ToInt32(dr["Status"]);
                model.PopCode = (dr["PopCode"] is DBNull) ? string.Empty : dr["PopCode"].ToString();
                model.UpdateFlag = (dr["UpdateFlag"] is DBNull) ? 0 : Convert.ToInt32(dr["UpdateFlag"]);
            }
            catch
            {
                return null;
            }
            return model;
        }

        //添加配置
        public bool AddConfig(T_User_Config model)
        {
            bool result = false;
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into [Infa]..[T_User_Config] (CCode,ConfigName,ConfigDesc,SoftInterval,IsAlert,IsRpt,Status,PopCode,UpdateFlag) ");
            sb.Append("values(@CCode,@ConfigName,@ConfigDesc,@SoftInterval,@IsAlert,@IsRpt,@Status,@PopCode,@UpdateFlag)");
            SqlParameter[] parameters = { 
                           new SqlParameter("@CCode",model.CCode),
                           new SqlParameter("@ConfigName",model.ConfigName),
                           new SqlParameter("@ConfigDesc",model.ConfigDesc),
                           new SqlParameter("@SoftInterval",model.SoftInterval),
                           new SqlParameter("@IsAlert",model.IsAlert),
                           new SqlParameter("@IsRpt",model.IsRpt),
                           new SqlParameter("@Status",model.Status),
                           new SqlParameter("@PopCode",model.PopCode),
                           new SqlParameter("@UpdateFlag",model.UpdateFlag)
                                  };
            int count = SqlHelper.DBHelper.ExecuteNonQuery(SqlHelper.DBHelper.OnlyWrite, CommandType.Text, sb.ToString(), parameters);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        //修改配置
        public bool UpdateConfig(T_User_Config model)
        {
            bool result = false;
            StringBuilder sb = new StringBuilder();
            sb.Append("update [Infa]..[T_User_Config] set ");
            sb.Append("ConfigName=@ConfigName,ConfigDesc=@ConfigDesc,SoftInterval=@SoftInterval,IsAlert=@IsAlert,IsRpt=@IsRpt,PopCode=@PopCode where CCode=@CCode");
            SqlParameter[] parameters = {                          
                           new SqlParameter("@ConfigName",model.ConfigName),
                           new SqlParameter("@ConfigDesc",model.ConfigDesc),
                           new SqlParameter("@SoftInterval",model.SoftInterval),
                           new SqlParameter("@IsAlert",model.IsAlert),
                           new SqlParameter("@IsRpt",model.IsRpt),
                           new SqlParameter("@PopCode",model.PopCode),
                           new SqlParameter("@CCode",model.CCode)
                                  };
            int count = SqlHelper.DBHelper.ExecuteNonQuery(SqlHelper.DBHelper.OnlyWrite, CommandType.Text, sb.ToString(), parameters);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        //删除配置
        public bool DeleteConfig(string cCode)
        {
            bool result = false;
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from [Infa]..[T_User_Config] where CCode=@CCode");
            SqlParameter[] parameters = { 
                           new SqlParameter("@CCode",cCode),
                                  };
            int count = SqlHelper.DBHelper.ExecuteNonQuery(SqlHelper.DBHelper.OnlyWrite, CommandType.Text, sb.ToString(), parameters);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
