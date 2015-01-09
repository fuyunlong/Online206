using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Winfotian.Common;
using Com.Winfotian.DB.SqlHelper;
using Com.Winfotian.Model;


namespace Com.Winfotian.DB
{
    public class ConfigProvider
    {
        public List<T_Company_Config> GetConfigList(string ConfigId)
        {
            List<T_Company_Config> list = new List<T_Company_Config>();
            try
            {
                StringBuilder Str = new StringBuilder();
                Str.Append("select * from  [Infa]..[T_Company_Config] where Status=1 ");
                if(ConfigId != "null" && ConfigId.Length > 0)
                {
                    Str.Append(" and ConfigId=@ConfigId");
                }
                SqlParameter[] pars = { 
                                      new SqlParameter("@ConfigId",ConfigId)
                                      };
                using(SqlDataReader reader = DBHelper.ExecuteReader(DBHelper.OnlyRead, CommandType.Text, Str.ToString(), pars))
                {
                    if(reader != null)
                    {
                        while(reader.Read())
                        {
                            list.Add(new T_Company_Config
                            {
                                ConfigId = Convert.ToInt32(reader["ConfigId"].ToString()),
                                ConfigName = reader["ConfigName"].ToString(),
                                IP = reader["IP"].ToString(),
                                Port = Convert.ToInt32(reader["Port"].ToString()),
                                ConfigDesc = reader["ConfigDesc"].ToString()
                            });
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), "", ex);
            }
            return list;
        }

        public List<int> GetCompanyConfig(string CompanyId)
        {
            List<int> list = new List<int>();
            try
            {
                StringBuilder Str = new StringBuilder();
                Str.Append("select ConfigId from  [Infa]..[T_Company_CmpConfig] where Status=1 and CompanyId=@CompanyId");
                SqlParameter[] pars = {
                                          new SqlParameter("@CompanyId",CompanyId)
                                      };
                using(SqlDataReader reader = DBHelper.ExecuteReader(DBHelper.OnlyRead, CommandType.Text, Str.ToString(), pars))
                {
                    if(reader != null)
                    {
                        while(reader.Read())
                        {
                            list.Add(Convert.ToInt32(reader["ConfigId"].ToString())
                            );
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), "", ex);
            }
            return list;
        }
    }
}
