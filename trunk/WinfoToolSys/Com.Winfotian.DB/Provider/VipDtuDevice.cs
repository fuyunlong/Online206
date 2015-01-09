using Com.Winfotian.Common;
using Com.Winfotian.DB.SqlHelper;
using Com.Winfotian.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Com.Winfotian.DB.Provider
{
    public class VipDtuDevice
    {

        //增加一条数据
        public bool Add(T_DTU_Device model)
        {
            bool result = false;
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into [Infa]..[T_DTU_Device](");
            sb.Append("DeviceName,Dtuid,DeviceBrand,DeviceSN,ModelCode,DeviceParams,ProduceDate,DeviceSupplier,Memo,UpdateFlag) ");
            sb.Append("values (");
            sb.Append("@DeviceName,@Dtuid,@DeviceBrand,@DeviceSN,@ModelCode,@DeviceParams,@ProduceDate,@DeviceSupplier,@Memo,@UpdateFlag)");
            SqlParameter[] parameters = {
					       new SqlParameter("@DeviceName", model.DeviceName),
					       new SqlParameter("@Dtuid", model.Dtuid),
					       new SqlParameter("@DeviceBrand", model.DeviceBrand),
					       new SqlParameter("@DeviceSN", model.DeviceSN),
					       new SqlParameter("@ModelCode", model.ModelCode),
					       new SqlParameter("@DeviceParams", model.DeviceParams),
					       new SqlParameter("@ProduceDate", model.ProduceDate),
					       new SqlParameter("@DeviceSupplier", model.DeviceSupplier),
					       new SqlParameter("@Memo", model.Memo),
					       new SqlParameter("@UpdateFlag", model.UpdateFlag)
                                         };

            int rows = DBHelper.ExecuteNonQuery(SqlHelper.DBHelper.OnlyWrite, CommandType.Text, sb.ToString(), parameters);
            if (rows > 0)
            {
                result = true;
            }
            return result;
        }

        //更新一条数据
        public bool Update(T_DTU_Device model)
        {
            bool result = false;
            StringBuilder sb = new StringBuilder();
            sb.Append("update [Infa]..[T_DTU_Device] set ");
            sb.Append("DeviceName=@DeviceName,");
            sb.Append("Dtuid=@Dtuid,");
            sb.Append("DeviceBrand=@DeviceBrand,");
            sb.Append("DeviceSN=@DeviceSN,");
            sb.Append("ModelCode=@ModelCode,");
            sb.Append("DeviceParams=@DeviceParams,");
            sb.Append("ProduceDate=@ProduceDate,");
            //sb.Append("DeviceSupplier=@DeviceSupplier,");
            sb.Append("Memo=@Memo,");
            sb.Append("UpdateFlag=@UpdateFlag");
            sb.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					       new SqlParameter("@DeviceName", model.DeviceName),
					       new SqlParameter("@Dtuid", model.Dtuid),
					       new SqlParameter("@DeviceBrand", model.DeviceBrand),
					       new SqlParameter("@DeviceSN", model.DeviceSN),
					       new SqlParameter("@ModelCode", model.ModelCode),
				           new SqlParameter("@DeviceParams", model.DeviceParams),
				           new SqlParameter("@ProduceDate", model.ProduceDate),
                           //new SqlParameter("@DeviceSupplier", model.DeviceSupplier),
			        	   new SqlParameter("@Memo", model.Memo),
				           new SqlParameter("@UpdateFlag", model.UpdateFlag),
				           new SqlParameter("@Id", model.Id)
                                        };

            int rows = DBHelper.ExecuteNonQuery(DBHelper.OnlyWrite, CommandType.Text, sb.ToString(), parameters);
            if (rows > 0)
            {
                result = true;
            }
            return result;
        }

        //删除一条数据
        public bool Delete(int id)
        {
            bool result = false;
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from [Infa]..[T_DTU_Device] ");
            sb.Append("where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
                                        };
            parameters[0].Value = id;
            int rows = DBHelper.ExecuteNonQuery(DBHelper.OnlyWrite, CommandType.Text, sb.ToString(), parameters);
            if (rows > 0)
            {
                result = true;
            }
            return result;
        }

        //得到一个对象实体
        public T_DTU_Device GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,DeviceName,Dtuid,DeviceBrand,DeviceSN,ModelCode,DeviceParams,ProduceDate,DeviceSupplier,Memo,UpdateFlag from [Infa]..[T_DTU_Device] ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					       new SqlParameter("@Id", SqlDbType.Int,4)
                                        };
            parameters[0].Value = Id;

            T_DTU_Device model = null;
            using (IDataReader dr = DBHelper.ExecuteReader(DBHelper.OnlyRead, CommandType.Text, strSql.ToString(), parameters))
            {
                if (dr.Read())
                {
                    model = IDataT_DTU_DeviceReader(dr);
                }
            }
            return model;
        }

        //根据id查询设备信息
        public T_DTU_Device_Ex GetExModel(int id)
        {
            T_DTU_Device_Ex model = new T_DTU_Device_Ex();
            StringBuilder sb = new StringBuilder();
            sb.Append("select a.*,c.CompanyId ");
            sb.Append("from [Infa]..[T_DTU_Device] as a left join [Infa]..[T_DTU] as b on a.Dtuid=b.Dtuid left join ");
            sb.Append("[Infa]..[T_DTU_Group] as c on b.GroupCode=c.GroupCode where a.Id=@Id");
            SqlParameter[] parameters = {
					       new SqlParameter("@Id", id)
                                         };
            using (SqlDataReader reader = DBHelper.ExecuteReader(DBHelper.OnlyRead, CommandType.Text, sb.ToString(), parameters))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        var device = IDataT_DTU_DeviceReader(reader);
                        model.Id = device.Id;
                        model.DeviceName = device.DeviceName;
                        model.Dtuid = device.Dtuid;
                        model.DeviceBrand = device.DeviceBrand;
                        model.DeviceSN = device.DeviceSN;
                        model.ModelCode = device.ModelCode;
                        model.DeviceParams = device.DeviceParams;
                        model.ProduceDate = device.ProduceDate;
                        model.DeviceSupplier = device.DeviceSupplier;
                        model.Memo = device.Memo;
                        model.UpdateFlag = device.UpdateFlag;
                        model.CompanyId = reader["CompanyId"].ToString();
                        model.Date = (reader["ProduceDate"] is DBNull) ? DateTime.MinValue.ToString("yyyy-MM-dd") : Convert.ToDateTime(reader["ProduceDate"].ToString()).ToString("yyyy-MM-dd");
                    }
                }
            }
            return model;
        }

        //T_DTU_Device 数据读取
        private T_DTU_Device IDataT_DTU_DeviceReader(IDataReader dr)
        {
            T_DTU_Device model = new T_DTU_Device();
            try
            {
                model.Id = (dr["Id"] is DBNull) ? 0 : Convert.ToInt32(dr["Id"].ToString());
                model.DeviceName = (dr["DeviceName"] is DBNull) ? string.Empty : dr["DeviceName"].ToString();
                model.Dtuid = (dr["Dtuid"] is DBNull) ? string.Empty : dr["Dtuid"].ToString();
                model.DeviceBrand = (dr["DeviceBrand"] is DBNull) ? string.Empty : dr["DeviceBrand"].ToString();
                model.DeviceSN = (dr["DeviceSN"] is DBNull) ? string.Empty : dr["DeviceSN"].ToString();
                model.ModelCode = (dr["ModelCode"] is DBNull) ? string.Empty : dr["ModelCode"].ToString();
                model.DeviceParams = (dr["DeviceParams"] is DBNull) ? string.Empty : dr["DeviceParams"].ToString();
                model.ProduceDate = (dr["ProduceDate"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(dr["ProduceDate"].ToString());
                model.DeviceSupplier = (dr["DeviceSupplier"] is DBNull) ? string.Empty : dr["DeviceSupplier"].ToString();
                model.Memo = (dr["Memo"] is DBNull) ? string.Empty : dr["Memo"].ToString();
                model.UpdateFlag = (dr["UpdateFlag"] is DBNull) ? 0 : Convert.ToInt32(dr["UpdateFlag"].ToString());
            }
            catch
            {
                return null;
            }
            return model;
        }

        //根据站点Id查询重要设备信息
        public List<T_DTU_Device> GetVipDeviceList(string dtuid)
        {
            List<T_DTU_Device> list = new List<T_DTU_Device>();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM [Infa]..[T_DTU_Device] where Dtuid=@Dtuid");
            SqlParameter[] parameters ={
                                new SqlParameter("@Dtuid",dtuid)
                                        };
            using (var reader = DBHelper.ExecuteReader(DBHelper.OnlyRead, CommandType.Text, sb.ToString(), parameters))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        var model = IDataT_DTU_DeviceReader(reader);
                        if (model != null)
                        {
                            list.Add(model);
                        }
                    }
                }
            }
            return list;
        }

        //根据公司Id查询站点信息
        public Dictionary<string, string> GetDTUListByCompanyId(string companyId)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            StringBuilder sb = new StringBuilder();
            sb.Append("select a.* from [Infa]..[T_DTU] as a ");
            sb.Append("left join [Infa]..[T_DTU_Group] as b on a.GroupCode=b.GroupCode ");
            sb.Append(" where b.CompanyId=@CompanyId");
            SqlParameter[] parameters = { 
                           new SqlParameter("@CompanyId",companyId)            
                                        };
            using (SqlDataReader reader = SqlHelper.DBHelper.ExecuteReader(SqlHelper.DBHelper.OnlyRead, CommandType.Text, sb.ToString(), parameters))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        var model = IDataT_DTUReader(reader);
                        if(model!=null)
                        dic.Add(model.Dtuid, model.DtuidName);
                    }
                }
            }
            return dic;
        }

        //T_DTU 数据读取
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
