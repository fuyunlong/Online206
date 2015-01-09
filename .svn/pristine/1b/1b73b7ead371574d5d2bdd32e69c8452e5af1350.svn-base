using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Com.Winfotian.MngTool
{
    public partial class FrmDTULongiLati : FrmBase
    {
        public FrmDTULongiLati()
        {
            InitializeComponent();
            panel1.Visible = true;
        }

        private void FrmDTULongiLati_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://gas.scadacn.com/Map.html");
            //webBrowser1.Navigate(Application.StartupPath+"/Map.html");
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            HtmlDocument doc = this.webBrowser1.Document;
            var eleX = doc.All["mapX"];
            var eleY = doc.All["mapY"];
            double longi = 0;
            double lati = 0;
            if (!double.TryParse(eleX.GetAttribute("value"), out longi))
            {
                MessageBox.Show("经度必须为有效数字");
                return;
            }
            if (!double.TryParse(eleY.GetAttribute("value"), out lati))
            {
                MessageBox.Show("纬度必须为有效数字");
                return;
            }
            if (this.Owner.GetType().Name == "FrmDTU")
            {
                FrmDTU.SetLongiLati(longi.ToString("0.000000"), lati.ToString("0.000000"));
            }
            else if (this.Owner.GetType().Name == "FrmOdorDTU")
            {
                FrmOdorDTU.SetLongiLati(longi.ToString("0.000000"), lati.ToString("0.000000"));
            }
            this.Close();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            panel1.Visible = false;
        }
    }
}
