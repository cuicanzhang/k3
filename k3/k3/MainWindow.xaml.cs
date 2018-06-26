using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Windows.Threading;

namespace k3
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
            this.Dispatcher.BeginInvoke(new Action(InitTimer), null);
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
        private void updateWindow(JObject init_result)
        {
            var qh = int.Parse(init_result["list"][0]["issue"].ToString().Substring(7, 2));
            var qh_next = int.Parse(init_result["issue"].ToString().Substring(7, 2));
            DateTime startTime = Convert.ToDateTime(init_result["startTime"].ToString());
            DateTime endTime = Convert.ToDateTime(init_result["endTime"].ToString());
            nextIssueLB.Content = "距" + init_result["issue"].ToString() + "期开奖剩余：";
            for (int i = 0; i <= 5; i++)
            {
                string qhlbName = "qh" + i + "LB";
                string jhlbName = "jh" + i + "LB";
                string hzlbName = "hz" + i + "LB";
                string typelbName = "type" + i + "LB";

                Label qhLB = this.FindName(qhlbName) as Label;
                Label jhLB = this.FindName(jhlbName) as Label;
                Label hzLB = this.FindName(hzlbName) as Label;
                Label typeLB = this.FindName(typelbName) as Label;
                if (qhLB != null && jhLB != null)
                {
                    qhLB.Content = init_result["list"][i]["issue"].ToString();
                    jhLB.Content = init_result["list"][i]["awardNum"].ToString().Replace(",", "");
                }
                hzLB.Content = (int.Parse(jhLB.Content.ToString().Substring(0, 1)) + int.Parse(jhLB.Content.ToString().Substring(1, 1)) + int.Parse(jhLB.Content.ToString().Substring(2, 1))).ToString();
            }
        }
        private async void InitTimer()
        {
            string url = "http://data.zhcw.com/k3/index.php?act=kstb&provinceCode=22";
            string jsonUrl = "http://data.zhcw.com/port/client_json.php?transactionType=10130307";
            CookieContainer cc = Http.HttpService.GetCookie(url);
            JObject init_result = JsonConvert.DeserializeObject(Http.HttpService.GetHtml(jsonUrl, cc)) as JObject;
            
            bool checkJson = false;
            bool updateFlag = false;
            var qh = int.Parse(init_result["list"][0]["issue"].ToString().Substring(7, 2));
            var qh_next = int.Parse(init_result["issue"].ToString().Substring(7, 2));
            DateTime startTime = Convert.ToDateTime(init_result["startTime"].ToString());
            DateTime endTime = Convert.ToDateTime(init_result["endTime"].ToString());
            nextIssueLB.Content = "距" + init_result["issue"].ToString() + "期开奖剩余：";
            for (int i = 0; i <= 5; i++)
            {
                string qhlbName = "qh" + i + "LB";
                string jhlbName = "jh" + i + "LB";
                string hzlbName = "hz" + i + "LB";
                string typelbName = "type" + i + "LB";

                Label qhLB = this.FindName(qhlbName) as Label;
                Label jhLB = this.FindName(jhlbName) as Label;
                Label hzLB = this.FindName(hzlbName) as Label;
                Label typeLB = this.FindName(typelbName) as Label;
                if (qhLB != null && jhLB != null)
                {
                    qhLB.Content = init_result["list"][i]["issue"].ToString();
                    jhLB.Content = init_result["list"][i]["awardNum"].ToString().Replace(",", "");
                }
                hzLB.Content = (int.Parse(jhLB.Content.ToString().Substring(0, 1)) + int.Parse(jhLB.Content.ToString().Substring(1, 1)) + int.Parse(jhLB.Content.ToString().Substring(2, 1))).ToString();
            }
            while (true)
            {
                //await Task.Run(() => Thread.Sleep(900));
                if (qh_next - qh == 2)
                {
                    if (checkJson)
                    {
                        init_result = JsonConvert.DeserializeObject(Http.HttpService.GetHtml(jsonUrl, cc)) as JObject;
                        checkJson = false;
                        updateFlag = true;
                    }
                    //await Task.Run(() => Thread.Sleep(900));
                    nextIssueLB.Content = "距" + init_result["issue"].ToString() + "期开奖剩余：获取中...";
                    //await Task.Delay(100);
                   
                    qh = int.Parse(init_result["list"][0]["issue"].ToString().Substring(7, 2));
                    qh_next = int.Parse(init_result["issue"].ToString().Substring(7, 2));
                    startTime = Convert.ToDateTime(init_result["startTime"].ToString());
                    endTime = Convert.ToDateTime(init_result["endTime"].ToString());
                    
                    await Task.Run(() => Thread.Sleep(3000));
                    checkJson = true;
                    //await Task.Delay(100);
                                              
                }
                
                TimeSpan subTime = endTime - startTime;
                if (qh_next - qh == 1)
                {
                    if (updateFlag)
                    {
                        updateWindow(init_result);
                        updateFlag = false;
                    }
                    if (DateTime.Compare(startTime, endTime) >=0)
                    {
                        //checkJson = true;
                        nextIssueLB.Content = "距" + init_result["issue"].ToString() + "期开奖剩余：获取中...";
                        await Task.Run(() => Thread.Sleep(3000));
                        init_result = JsonConvert.DeserializeObject(Http.HttpService.GetHtml(jsonUrl, Http.HttpService.GetCookie(url))) as JObject;
                        qh = int.Parse(init_result["list"][0]["issue"].ToString().Substring(7, 2));
                        qh_next = int.Parse(init_result["issue"].ToString().Substring(7, 2));
                        //await Task.Run(() => Thread.Sleep(5000));
                    }
                    //endTime = Convert.ToDateTime(init_result["endTime"].ToString());
                    startTime = Convert.ToDateTime(DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"));
                    subTime = endTime - startTime;
                    await Task.Run(() => Thread.Sleep(900));
                    nextIssueLB.Content = "距" + init_result["issue"].ToString() + "期开奖剩余：" + subTime.Minutes.ToString().PadLeft(2, '0') + ":" + subTime.Seconds.ToString().PadLeft(2, '0');
                    await Task.Delay(100);
                }
                if (qh_next - qh == -86)
                {
                    nextIssueLB.Content = "每天08:20开售";
                    //break;
                    await Task.Run(() => Thread.Sleep(5000));
                    init_result = JsonConvert.DeserializeObject(Http.HttpService.GetHtml(jsonUrl, cc)) as JObject;
                    qh = int.Parse(init_result["list"][0]["issue"].ToString().Substring(7, 2));
                    qh_next = int.Parse(init_result["issue"].ToString().Substring(7, 2));
                    //await Task.Delay(100);
                }


              //  await Task.Delay(100);
            }


        }

    }
}
