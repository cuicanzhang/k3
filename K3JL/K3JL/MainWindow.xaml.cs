using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace K3JL
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            this.Dispatcher.BeginInvoke(new Action(updateTime), null);
            this.Dispatcher.BeginInvoke(new Action(showNum), null);
        }

        private async void showNum()
        {
            string url = "http://www.jlfc.com.cn/View/KS_WinInfo.aspx";
            string html = Html2Text(Http.HttpService.GetHtml(url));
            //string pattern = @"<tdclass=td_play_rewardtd4style=height:28px;>180627013</td>";
            string pattern = @"\d{9}</td><tdclass=td_play_rewardssc_win_codetd4><ulstyle=><imgsrc='PCLotteryImg\.aspx\?termCode=[ 0-9A-Za-z]+==&pID=AToYIrx87kc=";            MatchCollection result = Regex.Matches(html, pattern);
            int i = 0;
            foreach (var str in result)
            {
                string[] sArray = Regex.Split(str.ToString(), "</td><tdclass=td_play_rewardssc_win_codetd4><ulstyle=><imgsrc='", RegexOptions.IgnoreCase);
                        // MessageBox.Show(sArray[0]);
                        //MessageBox.Show(sArray[1]);

                        string qh = sArray[0].ToString();
                        string hm = "http://www.jlfc.com.cn/View/" +sArray[1].ToString();

                string qhlbName = "qh" + i + "LB";
                string hmImgName = "hm" + i + "Img";
                Label qhLB = this.FindName(qhlbName) as Label;
                Image hmImg = this.FindName(hmImgName) as Image;
                //MessageBox.Show(hm0Img.Source.ToString());
                qhLB.Content = qh;
                hmImg.Source = new BitmapImage(new Uri(hm));
                i++;
            }
            while (true)
            {
                await Task.Run(() => Thread.Sleep(3000));
            }
        }

        private async void updateTime()
        {
            while (true)
            {
                await Task.Run(() => Thread.Sleep(900));
                DateTimeLB.Content = DateTime.Now.ToString();
                await Task.Delay(100);
            }
        }




        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch { }
        }
        public static string Html2Text(string htmlStr)
        {
            if (String.IsNullOrEmpty(htmlStr))
            {
                return "";
            }
            //string regEx_style = " < style[^>]*?>[\\s\\S]*?<\\/style>"; //定义style的正则表达式 
            //string regEx_script = "<script[^>]*?>[\\s\\S]*?<\\/script>"; //定义script的正则表达式 
            //string regEx_html = "<[^>]+>"; //定义HTML标签的正则表达式 
            //htmlStr = Regex.Replace(htmlStr, regEx_style, "");//删除css
            //htmlStr = Regex.Replace(htmlStr, regEx_script, "");//删除js
            //htmlStr = Regex.Replace(htmlStr, regEx_html, "");//删除html标记
            htmlStr = Regex.Replace(htmlStr, "\\s*|\t|\r|\n", "");//去除tab、空格、空行
            htmlStr = htmlStr.Replace(" ", "");
            htmlStr = htmlStr.Replace("\"", "");
            htmlStr = htmlStr.Replace(" \"", "");
            htmlStr = htmlStr.Replace("\" ", "");
            return htmlStr.Trim();
        }
    }
}
