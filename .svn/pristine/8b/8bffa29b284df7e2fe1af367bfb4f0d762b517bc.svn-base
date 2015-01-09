using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Com.Winfotian.MngTool
{
    public class ProgressBarHelper : IDisposable
    {
        private delegate void CloseFormDelegate();
        private FrmProgressBar frmProgressBar;
        private delegate void ShowMsgDelegate(string msg);
        private Thread upgradeThread = null;
        bool sFlog = true;
        /// <summary>
        /// 
        /// </summary>
        ~ProgressBarHelper()
        {
            Dispose(false);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public ProgressBarHelper()
        {
            frmProgressBar = new FrmProgressBar();
        }
        /// <summary>
        /// 弹出进度条窗口
        /// </summary>
        /// <param name="msg">进度条上显示的文字信息</param>
        public void PopProgressBar(string msg)
        {
            try
            {
                if (frmProgressBar == null)
                {
                    frmProgressBar = new FrmProgressBar();
                }
                frmProgressBar.ShowMessage = msg;
                if (sFlog == true)
                {
                    sFlog = false;
                    upgradeThread = new Thread(new ThreadStart(ProgressShow));
                    upgradeThread.Start();
                }
            }
            catch (ThreadAbortException Err)
            {
                MessageBox.Show(Err.Message);
            }
        }
        /// <summary>
        /// 弹出窗口的具体实现方法由另外一个线程去调用避免与主线程冲突
        /// </summary>
        private void ProgressShow()
        {
            try
            {
                if (frmProgressBar != null && !frmProgressBar.IsDisposed)
                {
                    if (frmProgressBar.InvokeRequired)
                        frmProgressBar.Invoke(new CloseFormDelegate(ProgressShow));
                    else
                    {
                        frmProgressBar.ShowDialog();
                    }
                }
            }
            catch (System.Threading.ThreadAbortException Err)
            {
                MessageBox.Show(Err.Message);
            }
        }
        /// <summary>
        /// 关闭等待窗体
        /// </summary>
        public void CloseProgressBar()
        {
            if (frmProgressBar == null)
                return;
            //同步到主线程上
            if (frmProgressBar.InvokeRequired)
                frmProgressBar.Invoke(new CloseFormDelegate(DoCloseProgressBar));
            else
                DoCloseProgressBar();
        }
        /// <summary>
        /// 关闭进度
        /// </summary>
        private void DoCloseProgressBar()
        {
            try
            {
                if (!frmProgressBar.IsDisposed)
                {
                    if (frmProgressBar.Created)
                    {
                        sFlog = true;
                        frmProgressBar.Close();
                    }
                }
                Dispose(false);
            }
            catch (ThreadAbortException Err)
            {
                MessageBox.Show(Err.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Msg"></param>
        public void ShowDialogInfo(string Msg)
        {
            if (frmProgressBar.InvokeRequired)
            {
                ShowMsgDelegate del = new ShowMsgDelegate(ShowDialogInfo);
                frmProgressBar.Invoke(del, Msg);
            }
            else
            {
                frmProgressBar.ShowDiaglogInfo(Msg);
            }
        }

        #region IDisposable 成员
        private bool alreadyDisposed = false;

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }
        protected virtual void Dispose(bool isDisposing)
        {
            // Don't dispose more than once.
            if (alreadyDisposed)
                return;
            if (isDisposing)
            {
                // TODO: free managed resources here.
            }

            // TODO: free unmanaged resources here.
            upgradeThread = null;
            frmProgressBar.Dispose();
            frmProgressBar = null;
            // Set disposed flag:
            alreadyDisposed = true;
        }
        #endregion
    }
}
