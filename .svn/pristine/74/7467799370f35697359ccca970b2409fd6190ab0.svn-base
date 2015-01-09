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
    /// <summary>
    /// 压力等级
    /// </summary>
    public class DTUPressureLevelProvider
    {

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(T_DTU_PressureLevel model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into [Infa]..[T_DTU_PressureLevel](");
            sb.Append("PressureName,PressureDesc,Status,UpdateFlag)");
            sb.Append(" values (");
            sb.Append("@PressureName,@PressureDesc,@Status,@UpdateFlag)");
            SqlParameter[] parameters = {
					       new SqlParameter("@PressureName", SqlDbType.VarChar,30),
					       new SqlParameter("@PressureDesc", SqlDbType.NVarChar,30),
					       new SqlParameter("@Status", SqlDbType.SmallInt,2),
				           new SqlParameter("@UpdateFlag", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.PressureName;
            parameters[1].Value = model.PressureDesc;
            parameters[2].Value = model.Status;
            parameters[3].Value = model.UpdateFlag;

            int rows = DBHelper.ExecuteNonQuery(DBHelper.OnlyWrite, CommandType.Text, sb.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(T_DTU_PressureLevel model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update [Infa]..[T_DTU_PressureLevel] set ");
            sb.Append("PressureName=@PressureName,");
            sb.Append("PressureDesc=@PressureDesc,");
            sb.Append("Status=@Status,");
            sb.Append("UpdateFlag=@UpdateFlag");
            sb.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					       new SqlParameter("@PressureName", SqlDbType.VarChar,30),
					       new SqlParameter("@PressureDesc", SqlDbType.NVarChar,30),
					       new SqlParameter("@Status", SqlDbType.SmallInt,2),
					       new SqlParameter("@UpdateFlag", SqlDbType.Int,4),
					       new SqlParameter("@Id", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.PressureName;
            parameters[1].Value = model.PressureDesc;
            parameters[2].Value = model.Status;
            parameters[3].Value = model.UpdateFlag;
            parameters[4].Value = model.Id;

            int rows = DBHelper.ExecuteNonQuery(DBHelper.OnlyWrite, CommandType.Text, sb.ToString(), parameters);
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
        public bool Delete(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from [Infa]..[T_DTU_PressureLevel] ");
            sb.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					       new SqlParameter("@Id", SqlDbType.Int,4)
                                        };
            parameters[0].Value = id;
            int rows = DBHelper.ExecuteNonQuery(DBHelper.OnlyWrite, CommandType.Text, sb.ToString(), parameters);
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
        public T_DTU_PressureLevel GetModel(string id)
        {
            T_DTU_PressureLevel model = new T_DTU_PressureLevel();
            StringBuilder sb = new StringBuilder();
            sb.Append("select top 1 Id,PressureName,PressureDesc,Status,UpdateFlag from [Infa]..[T_DTU_PressureLevel]");
            sb.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					       new SqlParameter("@Id", SqlDbType.Int,4)
                                        };
            parameters[0].Value = id;
            using (IDataReader dr = DBHelper.ExecuteReader(DBHelper.OnlyRead, CommandType.Text, sb.ToString(), parameters))
            {
                if (dr.Read())
                {
                    model = IDataT_DTU_PressureLevelReader(dr);
                }
            }
            return model;
        }

        /// <summary>
        /// T_DTU_PressureLevel 数据读取
        /// </summary>
        private T_DTU_PressureLevel IDataT_DTU_PressureLevelReader(IDataReader dr)
        {
            T_DTU_PressureLevel model = new T_DTU_PressureLevel();
            try
            {
                model.Id = (dr["Id"] is DBNull) ? 0 : Convert.ToInt32(dr["Id"].ToString());
                model.PressureName = (dr["PressureName"] is DBNull) ? string.Empty : dr["PressureName"].ToString();
                model.PressureDesc = (dr["PressureDesc"] is DBNull) ? string.Empty : dr["PressureDesc"].ToString();
                model.Status = (dr["Status"] is DBNull) ? 0 : Convert.ToInt32(dr["Status"].ToString());
                model.UpdateFlag = (dr["UpdateFlag"] is DBNull) ? 0 : Convert.ToInt32(dr["UpdateFlag"].ToString());
            }
            catch
            {
                return null;
            }
            return model;
        }

        /// <summary>
        /// 获取压力等级列表
        /// </summary>
        public List<T_DTU_PressureLevel> GetPressureLevelList(string levelName)
        {
            List<T_DTU_PressureLevel> list = new List<T_DTU_PressureLevel>();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from [Infa]..[T_DTU_PressureLevel]");
            if (!string.IsNullOrEmpty(levelName))
            {
                sb.Append(" where PressureName like @PressureName");
            }
            SqlParameter[] parameters = { 
                           new SqlParameter("@PressureName","%"+levelName+"%")
                                        };
            using (IDataReader reader = DBHelper.ExecuteReader(DBHelper.OnlyRead, CommandType.Text, sb.ToString(), parameters))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        list.Add(IDataT_DTU_PressureLevelReader(reader));
                    }
                }
            }
            return list;
        }
    }
}
