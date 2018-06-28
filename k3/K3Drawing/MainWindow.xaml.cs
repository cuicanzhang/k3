using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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

namespace K3Drawing
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainWindow_Loaded();
        }
        private void MainWindow_Loaded()
        {
            dispData();
        }

        private void dispData()
        {
            Layout.GridInit.Init(GMain);
            GMain.ShowGridLines=true;
            string url = "http://data.zhcw.com/k3/index.php?act=kstb&provinceCode=22";
            string jsonUrl = "http://data.zhcw.com/port/client_json.php?transactionType=10130307";
            CookieContainer cc = Http.HttpService.GetCookie(url);
            JObject init_result = JsonConvert.DeserializeObject(Http.HttpService.GetHtml(jsonUrl, cc)) as JObject;
            int i = 41;
            foreach (var v in init_result["list"])
            {
                int hz = 0;
                //MessageBox.Show(v["issue"].ToString().Substring(7, 2));
                var qh = int.Parse(v["issue"].ToString().Substring(7, 2));
                GMain.Children.Add(Layout.GridInit.TextBL(qh.ToString().PadLeft(2, '0'), i, 0, 0, 0));
                var jh= v["awardNum"].ToString().Replace(",", "");
                for (int j = 0; j < 3; j++)
                {
                    //MessageBox.Show(jh.Substring(j, 1));
                    GMain.Children.Add(Layout.GridInit.TextBL(jh.Substring(j,1), i, j+1, 0, 0));
                    for(int k = 0; k < 6; k++)
                    {
                        if (jh.Substring(j, 1) == (k+1).ToString()) { GMain.Children.Add(Layout.GridInit.TextBL(jh.Substring(j, 1), i, k+4, 0, 0)); }
                    }
                    hz += int.Parse(jh.Substring(j, 1));
                }
                for(int j = 0; j < 15; j++)
                {
                    if (hz == j){GMain.Children.Add(Layout.GridInit.TextBL(hz.ToString(), i, j + 7, 0, 0));}
                    if (hz >= 10){GMain.Children.Add(Layout.GridInit.TextBL("大", i, 26, 0, 0));}
                        else{GMain.Children.Add(Layout.GridInit.TextBL("小", i, 27, 0, 0));}
                    if (hz % 2 != 0){GMain.Children.Add(Layout.GridInit.TextBL("单", i, 28, 0, 0));}
                        else { GMain.Children.Add(Layout.GridInit.TextBL("双", i, 29, 0, 0)); }
                }
                for(int j = 0; j < 6; j++)
                {
                    if (int.Parse(jh.Substring(2, 1)) - int.Parse(jh.Substring(0, 1)) == j)
                    {
                        GMain.Children.Add(Layout.GridInit.TextBL(j.ToString(), i, j+30, 0, 0));
                    }
                }
                
                

                if (i > 2){i--;}else { break; }
            }

        }
    }
}
