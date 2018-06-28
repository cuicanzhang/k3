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
                //MessageBox.Show(v["issue"].ToString().Substring(7, 2));
                var qh = int.Parse(v["issue"].ToString().Substring(7, 2));


                GMain.Children.Add(Layout.GridInit.TextBL(qh.ToString(), i, 0, 0, 0));

                if (i > 2){i--;}else { break; }
            }

        }
    }
}
