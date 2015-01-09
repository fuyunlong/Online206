using Com.Winfotian.Common;
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
    public partial class WinSyncService : ServiceBase
    {
        public static string PublicIp = WinManager.GetPublicIP();//当前IP地址
        public WinSyncService()
        {
            InitializeComponent();
        }
        System.Timers.Timer timer = null;
        protected override void OnStart(string[] args)
        {
            LogBLL.WriteOperatorLog(PublicIp, "", "同步服务已启动", 1);
            timer = new System.Timers.Timer(1000 * 60 * 60);//设置定时器，1小时执行一次
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                LogBLL.WriteOperatorLog(PublicIp, "", "同步服务开始执行", 1);
                new SyncMng().SyncData();
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), "", ex);
            }
        }

        protected override void OnStop()
        {
            
            LogBLL.WriteOperatorLog(PublicIp, "", "同步服务已停止", 1);
            timer.Stop();
        }
    }
}
