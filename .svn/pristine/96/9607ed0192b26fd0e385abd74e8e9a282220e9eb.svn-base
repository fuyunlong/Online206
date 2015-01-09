using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Com.Winfotian.Common;

namespace Com.Winfotian.MngTool
{
    public class LogBLL
    {
        /// <summary>
        /// 记录登陆日志
        /// </summary>
        /// <param name="result">1.成功；2失败</param>
        public static void WriteLoginLog(string logFromIP, string userId, string pwd, int result)
        {
            try
            {
                Com.Winfotian.ServiceProxy.LogService.T_Log model = new ServiceProxy.LogService.T_Log();
                model.businessSystem = ToolHelper.ReadINIValue("ServerConfig", "SysCode", "Winfo_Tool001");
                model.logFromIP = logFromIP;
                if (result == 1)
                {
                    model.logInfo = userId + "登录成功";
                }
                else
                {
                    result = 2;
                    model.logInfo = userId + "登录失败，尝试密码：" + Com.Winfotian.Encrypts.DESEncrypt.Decrypt(pwd);
                }
                model.logResult = result;
                model.logTime = DateTime.Now;
                model.userID = userId;
                model.logTpye = 3;
                var rslt = Com.Winfotian.ServiceProxy.LogManagerProxy.AddSysLoginLog(model);
                if (rslt.state != "1")
                {
                    throw new Exception(rslt.reason);
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteExceptionLog(ex);
            }
        }
        /// <summary>
        /// 记录登陆日志
        /// </summary>
        /// <param name="result">1.成功；2失败</param>
        public static void WriteLoginLog(string logFromIP, string userId, string pwd, int result, string Msg)
        {
            try
            {
                Com.Winfotian.ServiceProxy.LogService.T_Log model = new ServiceProxy.LogService.T_Log();
                model.businessSystem = ToolHelper.ReadINIValue("ServerConfig", "SysCode", "Winfo_Tool001");
                model.logFromIP = logFromIP;
                if (result == 1)
                {
                    model.logInfo = userId + "登录成功";
                }
                else
                {
                    result = 2;
                    model.logInfo = userId + "登录失败，尝试密码：" + Com.Winfotian.Encrypts.DESEncrypt.Decrypt(pwd) + "；" + Msg;
                }
                model.logResult = result;
                model.logTime = DateTime.Now;
                model.userID = userId;
                model.logTpye = 3;
                var rslt = Com.Winfotian.ServiceProxy.LogManagerProxy.AddSysLoginLog(model);
                if (rslt.state != "1")
                {
                    throw new Exception(rslt.reason);
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteExceptionLog(ex);
            }
        }
        /// <summary>
        /// 记录异常日志
        /// </summary>
        /// <param name="result"></param>
        public static void WriteExceptionLog(string logFromIP, string userId, Exception ex)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (ex != null)
                {

                    sb.AppendFormat("[OccurPlace]{0};", ex.TargetSite);
                    sb.AppendFormat("[MSG]{0};", ex.Message);
                    sb.AppendFormat("[From]{0};", ex.Source);
                    if (ex.Data.Count > 0)
                    {
                        sb.Append("[Data]");
                        foreach (System.Collections.DictionaryEntry var in ex.Data)
                        {
                            sb.AppendFormat("\t[{0}]:{1};", var.Key, var.Value);
                        }
                    }
                    sb.AppendFormat("[Desc]{0}.", ex.ToString());

                    Com.Winfotian.ServiceProxy.LogService.T_Log model = new ServiceProxy.LogService.T_Log();
                    model.businessSystem = ToolHelper.ReadINIValue("ServerConfig", "SysCode", "Winfo_Tool001");
                    model.logFromIP = logFromIP;
                    model.logResult = 2;
                    model.logInfo = sb.ToString();
                    model.logTime = DateTime.Now;
                    model.userID = userId;
                    var rslt = Com.Winfotian.ServiceProxy.LogManagerProxy.AddSysErrorLog(model);
                    if (rslt.state != "1")
                    {
                        throw new Exception(rslt.reason);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.WriteExceptionLog(e);
            }
        }
        /// <summary>
        /// 记录异常日志
        /// </summary>
        /// <param name="result"></param>
        public static void WriteExceptionLog(string logFromIP, string userId, Exception ex, string ExtendInfo)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (ex != null)
                {

                    sb.AppendFormat("[OccurPlace]{0};", ex.TargetSite);
                    sb.AppendFormat("[MSG]{0};", ex.Message);
                    sb.AppendFormat("[Extend]{0};", ExtendInfo);
                    sb.AppendFormat("[From]{0};", ex.Source);
                    if (ex.Data.Count > 0)
                    {
                        sb.Append("[Data]");
                        foreach (System.Collections.DictionaryEntry var in ex.Data)
                        {
                            sb.AppendFormat("\t[{0}]:{1};", var.Key, var.Value);
                        }
                    }
                    sb.AppendFormat("[Desc]{0}.", ex.ToString());

                    Com.Winfotian.ServiceProxy.LogService.T_Log model = new ServiceProxy.LogService.T_Log();
                    model.businessSystem = ToolHelper.ReadINIValue("ServerConfig", "SysCode", "Winfo_Tool001");
                    model.logFromIP = logFromIP;
                    model.logResult = 2;
                    model.logInfo = sb.ToString();
                    model.logTime = DateTime.Now;
                    model.userID = userId;
                    var rslt = Com.Winfotian.ServiceProxy.LogManagerProxy.AddSysErrorLog(model);
                    if (rslt.state != "1")
                    {
                        throw new Exception(rslt.reason);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.WriteExceptionLog(e);
            }
        }
        /// <summary>
        /// 记录操作日志
        /// </summary>
        /// <param name="result">1.成功；2失败</param>
        public static void WriteOperatorLog(string logFromIP, string userId, string OldInfo, string NewInfo, int result)
        {
            try
            {
                Com.Winfotian.ServiceProxy.LogService.T_Log model = new ServiceProxy.LogService.T_Log();
                model.businessSystem = ToolHelper.ReadINIValue("ServerConfig", "SysCode", "Winfo_Tool001");
                model.logFromIP = logFromIP;
                model.logResult = result;
                model.logInfo = userId + "操作[" + OldInfo + "]更改为:" + NewInfo;
                model.logTime = DateTime.Now;
                model.userID = userId;
                var rslt = Com.Winfotian.ServiceProxy.LogManagerProxy.AddSysOperLog(model);
                if (rslt.state != "1")
                {
                    throw new Exception(rslt.reason);
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteExceptionLog(ex);
            }
        }
        /// <summary>
        /// 记录操作日志
        /// </summary>
        /// <param name="result">1.成功；2失败</param>
        public static void WriteOperatorLog(string logFromIP, string userId, string ModifyInfo, int result)
        {
            try
            {
                Com.Winfotian.ServiceProxy.LogService.T_Log model = new ServiceProxy.LogService.T_Log();
                model.businessSystem = ToolHelper.ReadINIValue("ServerConfig", "SysCode", "Winfo_Tool001");
                model.logFromIP = logFromIP;
                model.logResult = result;
                model.logInfo = ModifyInfo;
                model.logTime = DateTime.Now;
                model.userID = userId;
                var rslt = Com.Winfotian.ServiceProxy.LogManagerProxy.AddSysOperLog(model);
                if (rslt.state != "1")
                {
                    throw new Exception(rslt.reason);
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteExceptionLog(ex);
            }
        }
    }
}