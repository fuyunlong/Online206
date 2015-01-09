using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Com.Winfotian.Model;

namespace Com.Winfotian.DB.Provider
{
    public class HeartRecordProvider
    {
        /// <summary>
        /// 查询所有站点信息
        /// </summary>
        public List<T_DTU> GetDTUList()
        {
            List<T_DTU> list = new List<T_DTU>();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from [Infa]..[T_DTU]");
            using (SqlDataReader reader = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyRead, CommandType.Text, sb.ToString()))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        var model = IDataT_DTUReader(reader);
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// T_DTU 数据读取
        /// </summary>
        private T_DTU IDataT_DTUReader(IDataReader dr)
        {
            T_DTU model = new T_DTU();
            try
            {
                model.Dtuid = (dr["Dtuid"] is DBNull) ? string.Empty : dr["Dtuid"].ToString();
                model.DtuidName = (dr["DtuidName"] is DBNull) ? string.Empty : dr["DtuidName"].ToString();
                model.Skidbrand = (dr["Skidbrand"] is DBNull) ? string.Empty : dr["Skidbrand"].ToString();
                model.Supplier = (dr["Supplier"] is DBNull) ? string.Empty : dr["Supplier"].ToString();
                model.FlowBrand = (dr["FlowBrand"] is DBNull) ? string.Empty : dr["FlowBrand"].ToString();
                model.FlowType = (dr["FlowType"] is DBNull) ? string.Empty : dr["FlowType"].ToString();
                model.PressureLevel = (dr["PressureLevel"] is DBNull) ? string.Empty : dr["PressureLevel"].ToString();
                model.DtuidLocation = (dr["DtuidLocation"] is DBNull) ? string.Empty : dr["DtuidLocation"].ToString();
                model.RegDate = (dr["RegDate"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(dr["RegDate"].ToString());
                model.RunDate = (dr["RunDate"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(dr["RunDate"].ToString());
                model.Longitude = (dr["Longitude"] is DBNull) ? 0 : Convert.ToDecimal(dr["Longitude"].ToString());
                model.Latitude = (dr["Latitude"] is DBNull) ? 0 : Convert.ToDecimal(dr["Latitude"].ToString());
                model.DayFrom = (dr["DayFrom"] is DBNull) ? 0 : Convert.ToInt32(dr["DayFrom"].ToString());
                model.MonthFrom = (dr["MonthFrom"] is DBNull) ? 0 : Convert.ToInt32(dr["MonthFrom"].ToString());
                model.LgPwd = (dr["LgPwd"] is DBNull) ? string.Empty : dr["LgPwd"].ToString();
                model.PhoneNum = (dr["PhoneNum"] is DBNull) ? string.Empty : dr["PhoneNum"].ToString();
                model.DataInterval = (dr["DataInterval"] is DBNull) ? 0 : Convert.ToInt32(dr["DataInterval"].ToString());
                model.UpLoadInterval = (dr["UpLoadInterval"] is DBNull) ? 0 : Convert.ToInt32(dr["UpLoadInterval"].ToString());
                model.Status = (dr["Status"] is DBNull) ? 0 : Convert.ToInt32(dr["Status"].ToString());
                model.GroupCode = (dr["GroupCode"] is DBNull) ? string.Empty : dr["GroupCode"].ToString();
                model.ConfigCode = (dr["ConfigCode"] is DBNull) ? string.Empty : dr["ConfigCode"].ToString();
                model.ProtocolVersion = (dr["ProtocolVersion"] is DBNull) ? string.Empty : dr["ProtocolVersion"].ToString();
                model.OrderId = (dr["OrderId"] is DBNull) ? 0 : Convert.ToInt32(dr["OrderId"].ToString());
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
