using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageBomber
{
    public partial class MainForm : Form
    {
        //获取窗口句柄
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,string lpWindowName);
        //设置焦点窗口
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string time = "2022-12-30 17:45";
            if (DateTime.Parse(time) < DateTime.Now)
            {
                MessageBox.Show("这是信息轰炸器的体验版本，现已失效，请联系开发者获取最新版本后重试。\n\r过期时间：" + time,"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                System.Environment.Exit(0); //强制退出程序
            }
        }

        private void sendText_Tick(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(executionNumber.Text) == 0)
                {
                    stopTimer_Click(null, null);
                    return;
                }
                executionNumber.Text = (int.Parse(executionNumber.Text) - 1).ToString();
            }
            catch 
            {
                //字符串为空或转换数字时出错
            }
            try
            {
                IntPtr handle = FindWindow(null, windowTitle.Text);
                if(windowTitle.Text!="")
                {
                    if(handle == IntPtr.Zero)
                    {
                        //如果窗口不存在
                        stopTimer_Click(null, null);
                        return;
                    }
                    SetForegroundWindow(handle);
                }
                SendKeys.Send(inputText.Text);
                if (pressEnter.Checked == true)
                    SendKeys.Send("{Enter}");
            }
            catch(Exception ex)
            {
                //一般是被杀软拦截，提示拒绝访问
                stopTimer_Click(null, null);
                MessageBox.Show("信息轰炸器发生了一个非致命的错误，操作已经中断。\n\r错误类型：" + ex.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void startTimer_Click(object sender, EventArgs e)
        {
            try
            {
                sendText.Interval = int.Parse(timeInterval.Text);
            }
            catch
            {
                //转换数字时出错
            }
            groupBox.Text = "控制（状态：ON）";
            sendText.Enabled = true;
        }

        private void stopTimer_Click(object sender, EventArgs e)
        {
            groupBox.Text = "控制（状态：OFF）";
            sendText.Enabled = false;
        }

    }
}
