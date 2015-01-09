using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Com.Winfotian.DB.SqlHelper;
using Com.Winfotian.Model;

namespace Com.Winfotian.DB
{
    public class DtuInfoProvider
    {


        /// 增加一条数据
        public void Add(DTU_Info model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [Infa]..[DTU_Info](");
            strSql.Append("OrderId,Dtuid,DtuidName,GroupName,FlowNum,AINum,DINum,Skidbrand,Supplier,FlowBrand,FlowType,PressureLevel,DtuidLocation,RegDate,RunDate,Longitude,Latitude,DayFrom,IsAlert,GroupCode,ParentCode,LgPwd)");
            strSql.Append(" values (");
            strSql.Append("@OrderId,@Dtuid,@DtuidName,@GroupName,@FlowNum,@AINum,@DINum,@Skidbrand,@Supplier,@FlowBrand,@FlowType,@PressureLevel,@DtuidLocation,@RegDate,@RunDate,@Longitude,@Latitude,@DayFrom,@IsAlert,@GroupCode,@ParentCode,@LgPwd)");
            SqlParameter[] parameters = {
  					new SqlParameter("@OrderId", SqlDbType.Int,4),
					new SqlParameter("@Dtuid", SqlDbType.VarChar,8),
					new SqlParameter("@DtuidName", SqlDbType.NVarChar,30),
					new SqlParameter("@GroupName", SqlDbType.NVarChar,30),
					new SqlParameter("@FlowNum", SqlDbType.SmallInt,2),
					new SqlParameter("@AINum", SqlDbType.SmallInt,2),
					new SqlParameter("@DINum", SqlDbType.SmallInt,2),
					new SqlParameter("@Skidbrand", SqlDbType.NVarChar,50),
					new SqlParameter("@Supplier", SqlDbType.NVarChar,50),
					new SqlParameter("@FlowBrand", SqlDbType.NVarChar,50),
					new SqlParameter("@FlowType", SqlDbType.VarChar,50),
					new SqlParameter("@PressureLevel", SqlDbType.VarChar,30),
					new SqlParameter("@DtuidLocation", SqlDbType.NVarChar,50),
					new SqlParameter("@RegDate", SqlDbType.DateTime),
					new SqlParameter("@RunDate", SqlDbType.DateTime),
					new SqlParameter("@Longitude", SqlDbType.Float,8),
					new SqlParameter("@Latitude", SqlDbType.Float,8),
					new SqlParameter("@DayFrom", SqlDbType.SmallInt,2),
					new SqlParameter("@IsAlert", SqlDbType.SmallInt,2),
					new SqlParameter("@GroupCode", SqlDbType.VarChar,30),
					new SqlParameter("@ParentCode", SqlDbType.VarChar,30),
					new SqlParameter("@LgPwd", SqlDbType.VarChar,20)};
            parameters[0].Value = model.OrderId;
            parameters[1].Value = model.Dtuid;
            parameters[2].Value = model.DtuidName;
            parameters[3].Value = model.GroupName;
            parameters[4].Value = model.FlowNum;
            parameters[5].Value = model.AINum;
            parameters[6].Value = model.DINum;
            parameters[7].Value = model.Skidbrand;
            parameters[8].Value = model.Supplier;
            parameters[9].Value = model.FlowBrand;
            parameters[10].Value = model.FlowType;
            parameters[11].Value = model.PressureLevel;
            parameters[12].Value = model.DtuidLocation;
            parameters[13].Value = model.RegDate;
            parameters[14].Value = model.RunDate;
            parameters[15].Value = model.Longitude;
            parameters[16].Value = model.Latitude;
            parameters[17].Value = model.DayFrom;
            parameters[18].Value = model.IsAlert;
            parameters[19].Value = model.GroupCode;
            parameters[20].Value = model.ParentCode;
            parameters[21].Value = model.LgPwd;

            DBHelper.ExecuteNonQuery(DBHelper.OnlyWrite, CommandType.Text, strSql.ToString(), parameters);
        }

        /// 更新一条数据
        public bool Update(DTU_Info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Infa]..[DTU_Info] set ");
            strSql.Append("OrderId=@OrderId,");
            strSql.Append("Dtuid=@Dtuid,");
            strSql.Append("DtuidName=@DtuidName,");
            strSql.Append("GroupName=@GroupName,");
            strSql.Append("FlowNum=@FlowNum,");
            strSql.Append("AINum=@AINum,");
            strSql.Append("DINum=@DINum,");
            strSql.Append("Skidbrand=@Skidbrand,");
            strSql.Append("Supplier=@Supplier,");
            strSql.Append("FlowBrand=@FlowBrand,");
            strSql.Append("FlowType=@FlowType,");
            strSql.Append("PressureLevel=@PressureLevel,");
            strSql.Append("DtuidLocation=@DtuidLocation,");
            strSql.Append("RegDate=@RegDate,");
            strSql.Append("RunDate=@RunDate,");
            strSql.Append("Longitude=@Longitude,");
            strSql.Append("Latitude=@Latitude,");
            strSql.Append("DayFrom=@DayFrom,");
            strSql.Append("IsAlert=@IsAlert,");
            strSql.Append("GroupCode=@GroupCode,");
            strSql.Append("ParentCode=@ParentCode,");
            strSql.Append("LgPwd=@LgPwd");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderId", SqlDbType.Int,4),
					new SqlParameter("@Dtuid", SqlDbType.VarChar,8),
					new SqlParameter("@DtuidName", SqlDbType.NVarChar,30),
					new SqlParameter("@GroupName", SqlDbType.NVarChar,30),
					new SqlParameter("@FlowNum", SqlDbType.SmallInt,2),
					new SqlParameter("@AINum", SqlDbType.SmallInt,2),
					new SqlParameter("@DINum", SqlDbType.SmallInt,2),
					new SqlParameter("@Skidbrand", SqlDbType.NVarChar,50),
					new SqlParameter("@Supplier", SqlDbType.NVarChar,50),
					new SqlParameter("@FlowBrand", SqlDbType.NVarChar,50),
					new SqlParameter("@FlowType", SqlDbType.VarChar,50),
					new SqlParameter("@PressureLevel", SqlDbType.VarChar,30),
					new SqlParameter("@DtuidLocation", SqlDbType.NVarChar,50),
					new SqlParameter("@RegDate", SqlDbType.DateTime),
					new SqlParameter("@RunDate", SqlDbType.DateTime),
					new SqlParameter("@Longitude", SqlDbType.Float,8),
					new SqlParameter("@Latitude", SqlDbType.Float,8),
					new SqlParameter("@DayFrom", SqlDbType.SmallInt,2),
					new SqlParameter("@IsAlert", SqlDbType.SmallInt,2),
					new SqlParameter("@GroupCode", SqlDbType.VarChar,30),
					new SqlParameter("@ParentCode", SqlDbType.VarChar,30),
					new SqlParameter("@LgPwd", SqlDbType.VarChar,20)};
            parameters[0].Value = model.OrderId;
            parameters[1].Value = model.Dtuid;
            parameters[2].Value = model.DtuidName;
            parameters[3].Value = model.GroupName;
            parameters[4].Value = model.FlowNum;
            parameters[5].Value = model.AINum;
            parameters[6].Value = model.DINum;
            parameters[7].Value = model.Skidbrand;
            parameters[8].Value = model.Supplier;
            parameters[9].Value = model.FlowBrand;
            parameters[10].Value = model.FlowType;
            parameters[11].Value = model.PressureLevel;
            parameters[12].Value = model.DtuidLocation;
            parameters[13].Value = model.RegDate;
            parameters[14].Value = model.RunDate;
            parameters[15].Value = model.Longitude;
            parameters[16].Value = model.Latitude;
            parameters[17].Value = model.DayFrom;
            parameters[18].Value = model.IsAlert;
            parameters[19].Value = model.GroupCode;
            parameters[20].Value = model.ParentCode;
            parameters[21].Value = model.LgPwd;

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

        /// 删除一条数据 
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [Infa]..[DTU_Info] ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
};

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

        /// 得到一个对象实体
        public DTU_Info GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderId,Dtuid,DtuidName,GroupName,FlowNum,AINum,DINum,Skidbrand,Supplier,FlowBrand,FlowType,PressureLevel,DtuidLocation,RegDate,RunDate,Longitude,Latitude,DayFrom,IsAlert,GroupCode,ParentCode,LgPwd from [Infa]..[DTU_Info] ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
};

            DTU_Info model = null;
            using(IDataReader dr = DBHelper.ExecuteReader(DBHelper.OnlyWrite, CommandType.Text, strSql.ToString(), parameters))
            {
                if(dr.Read())
                {
                    model = IDataDTU_InfoReader(dr);
                }
            }
            return model;
        }

        /// DTU_Info 数据读取 
        private DTU_Info IDataDTU_InfoReader(IDataReader dr)
        {
            DTU_Info model = new DTU_Info();
            try
            {
                model.OrderId = (dr["OrderId"] is DBNull) ? 0 : Convert.ToInt32(dr["OrderId"].ToString());
                model.Dtuid = (dr["Dtuid"] is DBNull) ? string.Empty : dr["Dtuid"].ToString();
                model.DtuidName = (dr["DtuidName"] is DBNull) ? string.Empty : dr["DtuidName"].ToString();
                model.GroupName = (dr["GroupName"] is DBNull) ? string.Empty : dr["GroupName"].ToString();
                model.FlowNum = (dr["FlowNum"] is DBNull) ? 0 : Convert.ToInt32(dr["FlowNum"].ToString());
                model.AINum = (dr["AINum"] is DBNull) ? 0 : Convert.ToInt32(dr["AINum"].ToString());
                model.DINum = (dr["DINum"] is DBNull) ? 0 : Convert.ToInt32(dr["DINum"].ToString());
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
                model.IsAlert = (dr["IsAlert"] is DBNull) ? 0 : Convert.ToInt32(dr["IsAlert"].ToString());
                model.GroupCode = (dr["GroupCode"] is DBNull) ? string.Empty : dr["GroupCode"].ToString();
                model.ParentCode = (dr["ParentCode"] is DBNull) ? string.Empty : dr["ParentCode"].ToString();
                model.LgPwd = (dr["LgPwd"] is DBNull) ? string.Empty : dr["LgPwd"].ToString();
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
