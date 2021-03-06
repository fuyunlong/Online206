﻿using Com.Winfotian.Common;
using Com.Winfotian.DataProvider;
using Com.Winfotian.SyncTool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
namespace WinfoSyncTable
{
    public class SyncMng
    {

        private string PublicIp = WinManager.GetPublicIP(); //获取当前外网IP
        private StringBuilder LogStr = new StringBuilder(); //组织日志记录信息，说明同步结果
        private string SyncConnStr = Com.Winfotian.Encrypts.DESEncrypt.Decrypt(ToolHelper.ReadINIValue("SyncConfig", "SyncConnStr", "")); //同步表
        private string ReSyncConnStr = Com.Winfotian.Encrypts.DESEncrypt.Decrypt(ToolHelper.ReadINIValue("SyncConfig", "ReSyncConnStr", "")); //被同步的表
        private string TableName = ToolHelper.ReadINIValue("SyncConfig", "TableName", "");//表名，模糊名称

        public void SyncData()
        {
            LogStr.Clear();
            if (string.IsNullOrWhiteSpace(SyncConnStr) || string.IsNullOrWhiteSpace(ReSyncConnStr) || string.IsNullOrWhiteSpace(TableName))
            {
                LogStr.Append("同步系统提示：请配置配置正确的连接字符串或者同步表名");
                LogBLL.WriteOperatorLog(PublicIp, "Sync001", LogStr.ToString(), 1);
            }
            else
            {
                List<string> SyncTables = GetSyncTableList();
                foreach (var a in SyncTables)
                {
                    AsyncTableData("[DataCenter]..[" + a + "]", DateTime.Now.AddHours(-2), DateTime.Now);
                }
                if (LogStr.Length > 0)
                {
                    LogBLL.WriteOperatorLog(PublicIp, "", LogStr.ToString(), 1);
                    LogStr.Clear();
                }
            }
        }

        /// <summary>
        /// 获取需要同步的表
        /// </summary>
        /// <returns></returns>
        private List<string> GetSyncTableList()
        {
            List<string> SyncTableList = new List<string>();
            try
            {
                List<string> TableList = GetTableList(SyncConnStr);//同步数据库的表列表(一般数据较多的表)
                List<string> ReTableList = GetTableList(ReSyncConnStr);//被同步的表列表
                List<string> BothTableList = new List<string>();//两个数据库都包含的表
                int count = TableList.Count;
                if (count < ReTableList.Count)
                {
                    count = ReTableList.Count;
                }
                foreach (var a in TableList)
                {
                    foreach (var b in ReTableList)
                    {
                        if (a == b)
                        {
                            BothTableList.Add(a);
                            break;
                        }
                    }
                }

                foreach (var a in BothTableList)
                {
                    if (a.IndexOf(TableName) >= 0)
                    {
                        SyncTableList.Add(a);
                    }
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(PublicIp, "", ex);
            }
            return SyncTableList;
        }

        /// <summary>
        /// 同步表数据，并记录统计结果
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="BeginTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="ConnLocal"></param>
        /// <param name="ConnRemote"></param>
        private void AsyncTableData(string TableName, DateTime BeginTime, DateTime EndTime)
        {
            int SyncCount = 0;
            string Msg = "";
            try
            {
                StringBuilder Sql = new StringBuilder();
                Sql.Append("declare @sql varchar(max)");
                Sql.Append("set @sql='select * from '+@TableName+' where COLLECTTIME between '''+@BeginTime+''' and '''+@EndTime+''' ' exec (@sql) ");
                SqlParameter[] pars = { 
                           new SqlParameter("@BeginTime",BeginTime.ToString()),
                           new SqlParameter("@EndTime",EndTime.ToString()),
                           new SqlParameter("@TableName",TableName)
                                  };
                DataSet DsLocal = SQLHelper.QuerySet(Sql.ToString(), ReSyncConnStr, pars);//被同步的数据库
                DataSet DsRemote = SQLHelper.QuerySet(Sql.ToString(), SyncConnStr, pars);//同步数据库

                Dictionary<string, string> LocalDic = new Dictionary<string, string>();
                Dictionary<string, string> RemoteDic = new Dictionary<string, string>();
                //本地数据表中的数据
                #region
                for (int i = 0; i < DsLocal.Tables[0].Rows.Count; i++)
                {
                    try
                    {
                        if (!LocalDic.ContainsKey(DsLocal.Tables[0].Rows[i]["COLLECTTIME"].ToString()))
                        {
                            StringBuilder sb = new StringBuilder();
                            for (int p = 1; p < DsLocal.Tables[0].Columns.Count; p++)
                            {
                                sb.AppendFormat("'{0}',", DsLocal.Tables[0].Rows[i][p]);
                            }
                            sb.Remove(sb.ToString().Length - 1, 1);
                            LocalDic.Add(DsLocal.Tables[0].Rows[i]["COLLECTTIME"].ToString(), sb.ToString());
                        }
                    }
                    catch
                    { continue; }
                }
                #endregion
                //远程数据表的数据
                #region
                for (int i = 0; i < DsRemote.Tables[0].Rows.Count; i++)
                {
                    try
                    {
                        if (!RemoteDic.ContainsKey(DsRemote.Tables[0].Rows[i]["COLLECTTIME"].ToString()))
                        {
                            StringBuilder sb = new StringBuilder();
                            for (int p = 1; p < DsRemote.Tables[0].Columns.Count; p++)
                            {
                                sb.AppendFormat("'{0}',", DsRemote.Tables[0].Rows[i][p]);
                            }
                            sb.Remove(sb.ToString().Length - 1, 1);
                            RemoteDic.Add(DsRemote.Tables[0].Rows[i]["COLLECTTIME"].ToString(), sb.ToString());
                        }
                    }
                    catch
                    { continue; }
                }
                #endregion
                //移除重复数据
                foreach (var a in  LocalDic)
                {
                    if (RemoteDic.ContainsKey(a.Key))
                    {
                        RemoteDic.Remove(a.Key);
                    }
                }
                if (RemoteDic.Count > 0)
                {
                    StringBuilder SqlStr = new StringBuilder(); 
                    foreach (var a in RemoteDic)
                    {
                        SqlStr.Append("insert into " + TableName + " values(" + a.Value + ") ");
                    }
                    //将要同步的数据插入到远程数据库
                    SyncCount = SQLHelper.ExecuteNonQuery(SqlStr.ToString(), ReSyncConnStr);
                    LogStr.Append("表名:【" + TableName + "】同步数据成功，同步条数:" + SyncCount + "\n\r");
                }
            }
            catch (Exception e)
            {
                Msg = e.Message;
                LogStr.Append("表名:【" + TableName + "】同步数据失败，异常信息" + e.Message + "\n\r");
            }
        }

        /// <summary>
        /// 获取数据库的表列表
        /// </summary>
        /// <param name="Conn"></param>
        /// <returns></returns>
        private List<string> GetTableList(string Conn)
        {
            string Sql = "select name from sys.tables order by name";
            List<string> TableList = new List<string>();
            try
            {
                DataTable dt = SQLHelper.Query(Sql, Conn);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TableList.Add(dt.Rows[i][0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(PublicIp, "", ex);
            }
            return TableList;
        }
    }
}
