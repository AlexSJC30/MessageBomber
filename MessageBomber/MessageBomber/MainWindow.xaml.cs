using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Winform = System.Windows.Forms;

namespace MessageBomber
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 调用DLL函数
        //获取窗口句柄
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        //设置焦点窗口
        [DllImport("User32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        //侦测热键
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(int vKey);
        #endregion

        public DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            LierdaCracker.Cracker();
            InitializeComponent();
            timer.Tick += Timer_Tick;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Environment.Exit(0); //非常干净地退出
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                //侦测热键是否按下（空格）
                if (GetAsyncKeyState(32) == 1)
                {
                    stopMethod();
                    return;
                }
                //尝试设置焦点窗口
                IntPtr handle = FindWindow(null, windowTitle.Text);
                if (windowTitle.Text != "")
                {
                    if (handle == IntPtr.Zero)
                    {
                        //如果窗口不存在
                        stopMethod();
                        return;
                    }
                    SetForegroundWindow(handle);
                }
                //如果剩余次数等于零
                if (uint.Parse(executeCount.Text) == 0)
                {
                    stopMethod();
                    return;
                }
                //正式开始模拟输入
                Winform.SendKeys.SendWait(textBox.Text);
                Winform.SendKeys.SendWait("{Enter}");
                executeCount.Text = (uint.Parse(executeCount.Text) - 1).ToString();
            }
            catch (Exception ex)
            {
                stopMethod();
                MessageBox.Show("应用发生了一个非致命的错误：" + ex.Message + "\n\r您可参考说明文档解决问题，或联系开发者后重试。", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //按钮单击事件，开始/停止
            if (button.Content.ToString() == "开始")
                startMethod();
            else
                stopMethod();
        }

        public void startMethod()
        {
            try 
            {
                button.Content = "停止";
                timer.Interval = TimeSpan.FromSeconds(double.Parse(timeInterval.Text));
                timer.Start();
            }          
            catch (Exception ex)
            {
                MessageBox.Show("应用发生了一个非致命的错误：" + ex.Message + "\n\r您可参考说明文档解决问题，或联系开发者后重试。", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void stopMethod()
        {
            button.Content = "开始";
            timer.Stop();
        }

        private void textBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }
    }
}
