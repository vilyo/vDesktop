using Microsoft.Win32;
using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace vDesktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DownloadAndSetWallpaper();
            timerWaitDownload.Interval = 3600000;
            timerWaitDownload.Enabled = true;
            timerWaitDownload.Start();
        }
        
        private void btnDownload_Click(object sender, EventArgs e)
        {            
            DownloadAndSetWallpaper();
        }
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinInt);

        /// <summary>
        /// 下载壁纸
        /// string url = "http://cn.bing.com/hpwp/ffcdbe64c08322d80c4293aa22f8ac07";
        /// string url = "http://cn.bing.com/az/hprichbg/rb/MartianCrater_ZH-CN9867068013_1920x1080.jpg";
        /// </summary>
        public void DownloadAndSetWallpaper()
        {
            string urlStr = "http://cn.bing.com";
            Uri url = new Uri(urlStr);
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            Stream stream = httpResponse.GetResponseStream();
            //获取流
            StreamReader sr = new StreamReader(stream, Encoding.UTF8);
            //读出流到string
            string strBuffer = sr.ReadToEnd();
            stream.Close();
            sr.Close();
            //取得图片的描述
            if (strBuffer.Contains("<a id=\"sh_cp\" class=\"sc_light\""))
            {
                int index = strBuffer.IndexOf("<a id=\"sh_cp\" class=\"sc_light\"");
                int endIndex = strBuffer.IndexOf("aria-label=\"主页图片信息\"");
                string titleText = strBuffer.Substring(index, endIndex - index);
                int titleIndex = titleText.IndexOf("title=");
                string title = titleText.Substring(titleIndex + 6);
                txtTitle.Text = title;
            }
            //解析HTML获取图片链接
            if (strBuffer.Contains("/az/hprichbg/rb/"))
            {
                int index = strBuffer.IndexOf("/az/hprichbg/rb/");
                strBuffer = strBuffer.Remove(0, index);
                int endIndex = strBuffer.IndexOf(",d:'200'");
                strBuffer = strBuffer.Remove(endIndex - 1);
            }
            //下载图片
            string imgUrl = urlStr + strBuffer;
            string fileName = "F:\\图片\\Bing\\WallPapers\\Wallpaper_" + DateTime.Now.ToString("yyyy-MM-dd") + ".jpg";
            if (!File.Exists(fileName))
            {
                WebClient client = new WebClient();
                client.DownloadFile(imgUrl, fileName);
                SystemParametersInfo(20, 1, fileName, 0x1 | 0x2);
            }
        }
        
        /// <summary>
        /// 设置开机自动启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbIsAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsAutoStart.Checked)
            {
                MessageBox.Show("设置开机自动启动", "提示");
                string path = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                rk2.SetValue("vDesktop", path);
                rk2.Close();
                rk.Close();
            }
            else
            {
                MessageBox.Show("取消开机自动启动", "提示");
                string path = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                rk2.DeleteValue("vDesktop", false);
                rk2.Close();
                rk.Close();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = true;
                WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                notifyIcon.Visible = true;
            }
        }        

        //定时自动下载
        private void timerWaitDownload_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //每天凌晨下载
            if(e.SignalTime.Hour == 0)
            {
                DownloadAndSetWallpaper();
            }                 
        }
    }
}
