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

namespace MessageBomber
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //获取窗口句柄
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        //设置焦点窗口
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        //侦测热键
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int vKey);

        public MainWindow()
        {
            LierdaCracker.Cracker();
            InitializeComponent();
            timer = new System.Threading.Timer(new System.Threading.TimerCallback(SendText), null, -1, -1);
        }

        /// <summary>
        /// 发送文字
        /// </summary>
        public void SendText(object obj)
        {
            Dispatcher.BeginInvoke(new Action(() => {
                try
                {
                    //获取热键
                    if (GetAsyncKeyState(8) != 0)
                    {
                        //应急终止热键BS（退格键）
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
                    //正式开始模拟输入
                    System.Windows.Forms.SendKeys.SendWait(textBox.Text);
                    System.Windows.Forms.SendKeys.SendWait("{Enter}");
                    executeCount.Text = (int.Parse(executeCount.Text) - 1).ToString();
                    if (int.Parse(executeCount.Text) < 1)
                        stopMethod();
                }
                catch (Exception ex)
                {
                    stopMethod();
                    MessageBox.Show("应用发生了一个非致命的错误：" + ex.Message + "\n\r您可参考说明文档解决问题，或联系开发者后重试。", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }), DispatcherPriority.ApplicationIdle);
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Environment.Exit(0);
        }

        public static System.Threading.Timer timer;
        private void button_Click(object sender, RoutedEventArgs e)
        {
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
                timer.Change(0, int.Parse(timeInterval.Text));
            }
            catch(Exception ex)
            {
                stopMethod();
                MessageBox.Show("应用发生了一个非致命的错误：" + ex.Message + "\n\r您可参考说明文档解决问题，或联系开发者后重试。", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void stopMethod()
        {
            button.Content = "开始";
            timer.Change(-1, 0);
        }
    }
}
