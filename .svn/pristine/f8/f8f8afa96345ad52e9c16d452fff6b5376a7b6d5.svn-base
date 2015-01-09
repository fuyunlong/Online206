using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Com.Winfotian.Common;

namespace Com.Winfotian.MngTool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //处理未捕获的异常   
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常   
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常   
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                bool ret;
                System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out ret);
                if (ret)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Frm_Login());
                    mutex.ReleaseMutex();
                }
                else
                {
                    MessageBox.Show(null, "有一个和本程序相同的应用程序已经在运行，请不要同时运行多个本程序。\n\n这个程序即将退出。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();//退出程序   
                }
            }
            catch (Exception ex)
            {
                LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), "sys_tool", ex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), "sys_tool", e.Exception);
            MessageBox.Show("网络故障或异常操作造成，系统出错，请重新登录或联系开发商！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogBLL.WriteExceptionLog(WinManager.GetPublicIP(), "sys_tool", e.ExceptionObject as Exception);
            MessageBox.Show("网络故障或异常操作造成，系统出错，请重新登录或联系开发商！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
