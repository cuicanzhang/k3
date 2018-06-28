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
            //GMain.ShowGridLines=true;
            
            string url = "http://data.zhcw.com/k3/index.php?act=kstb&provinceCode=22";
            string jsonUrl = "http://data.zhcw.com/port/client_json.php?transactionType=10130307";
            CookieContainer cc = Http.HttpService.GetCookie(url);
            JObject init_result = JsonConvert.DeserializeObject(Http.HttpService.GetHtml(jsonUrl, cc)) as JObject;
            int i = 41;
            foreach (var v in init_result["list"])
            {
                //MessageBox.Show(v["issue"].ToString().Substring(7, 2));
                var qh = int.Parse(v["issue"].ToString().Substring(7, 2));
                GMain.Children.Add(Layout.GridInit.TextBL(qh.ToString().PadLeft(2, '0'),12, i, 0, 0, 0));
                var jh= v["awardNum"].ToString().Replace(",", "");
                
                //MessageBox.Show(jh.Substring(j, 1));
                if(checkColor(jh.Substring(0, 1), jh.Substring(1, 1), jh.Substring(2, 1))==3)
                {
                    GMain.Children.Add(Layout.GridInit.TextBlueBL(jh.Substring(0, 1), i, 1, 0, 0));
                    GMain.Children.Add(Layout.GridInit.TextBlueBL(jh.Substring(1, 1), i, 2, 0, 0));
                    GMain.Children.Add(Layout.GridInit.TextBlueBL(jh.Substring(2, 1), i, 3, 0, 0));
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 6; k++)
                        {
                            if (jh.Substring(j, 1) == (k + 1).ToString()) { GMain.Children.Add(Layout.GridInit.TextBlueBL(jh.Substring(j, 1), i, k + 4, 0, 0)); }
                        }
                    }
                    for (int j = 0; j < 15; j++)
                    {
                        if (hz(jh) == j) { GMain.Children.Add(Layout.GridInit.TextBlueBL(hz(jh).ToString(), i, j + 7, 0, 0)); }
                        if (hz(jh) >= 10) { GMain.Children.Add(Layout.GridInit.TextBlueBL("大",  i, 26, 0, 0)); }
                        else { GMain.Children.Add(Layout.GridInit.TextBlueBL("小", i, 27, 0, 0)); }
                        if (hz(jh) % 2 != 0) { GMain.Children.Add(Layout.GridInit.TextBL("单", i, 28, 0, 0)); }
                        else { GMain.Children.Add(Layout.GridInit.TextBlueBL("双",  i, 29, 0, 0)); }
                    }
                    for (int j = 0; j < 6; j++)
                    {
                        if (int.Parse(jh.Substring(2, 1)) - int.Parse(jh.Substring(0, 1)) == j)
                        {
                            GMain.Children.Add(Layout.GridInit.TextBlueBL(j.ToString(), i, j + 30, 0, 0));
                        }
                    }
                } else if (checkColor(jh.Substring(0, 1), jh.Substring(1, 1), jh.Substring(2, 1)) == 2)
                {
                    GMain.Children.Add(Layout.GridInit.TextRedBL(jh.Substring(0, 1), i, 1, 0, 0));
                    GMain.Children.Add(Layout.GridInit.TextRedBL(jh.Substring(1, 1), i, 2, 0, 0));
                    GMain.Children.Add(Layout.GridInit.TextRedBL(jh.Substring(2, 1), i, 3, 0, 0));
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 6; k++)
                        {
                            if (jh.Substring(j, 1) == (k + 1).ToString()) { GMain.Children.Add(Layout.GridInit.TextRedBL(jh.Substring(j, 1), i, k + 4, 0, 0)); }
                        }
                    }
                    for (int j = 0; j < 15; j++)
                    {
                        if (hz(jh) == j) { GMain.Children.Add(Layout.GridInit.TextRedBL(hz(jh).ToString(), i, j + 7, 0, 0)); }
                        if (hz(jh) >= 10) { GMain.Children.Add(Layout.GridInit.TextRedBL("大", i, 26, 0, 0)); }
                        else { GMain.Children.Add(Layout.GridInit.TextRedBL("小", i, 27, 0, 0)); }
                        if (hz(jh) % 2 != 0) { GMain.Children.Add(Layout.GridInit.TextRedBL("单", i, 28, 0, 0)); }
                        else { GMain.Children.Add(Layout.GridInit.TextRedBL("双", i, 29, 0, 0)); }
                    }
                    for (int j = 0; j < 6; j++)
                    {
                        if (int.Parse(jh.Substring(2, 1)) - int.Parse(jh.Substring(0, 1)) == j)
                        {
                            GMain.Children.Add(Layout.GridInit.TextRedBL(j.ToString(), i, j + 30, 0, 0));
                        }
                    }

                }
                else if (checkColor(jh.Substring(0, 1), jh.Substring(1, 1), jh.Substring(2, 1)) == 1)
                {
                    GMain.Children.Add(Layout.GridInit.TextGreenBL(jh.Substring(0, 1), i, 1, 0, 0));
                    GMain.Children.Add(Layout.GridInit.TextGreenBL(jh.Substring(1, 1), i, 2, 0, 0));
                    GMain.Children.Add(Layout.GridInit.TextGreenBL(jh.Substring(2, 1), i, 3, 0, 0));
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 6; k++)
                        {
                            if (jh.Substring(j, 1) == (k + 1).ToString()) { GMain.Children.Add(Layout.GridInit.TextGreenBL(jh.Substring(j, 1), i, k + 4, 0, 0)); }
                        }
                    }
                    for (int j = 0; j < 15; j++)
                    {
                        if (hz(jh) == j) { GMain.Children.Add(Layout.GridInit.TextGreenBL(hz(jh).ToString(), i, j + 7, 0, 0)); }
                        if (hz(jh) >= 10) { GMain.Children.Add(Layout.GridInit.TextGreenBL("大", i, 26, 0, 0)); }
                        else { GMain.Children.Add(Layout.GridInit.TextGreenBL("小", i, 27, 0, 0)); }
                        if (hz(jh) % 2 != 0) { GMain.Children.Add(Layout.GridInit.TextGreenBL("单", i, 28, 0, 0)); }
                        else { GMain.Children.Add(Layout.GridInit.TextGreenBL("双", i, 29, 0, 0)); }
                    }
                    for (int j = 0; j < 6; j++)
                    {
                        if (int.Parse(jh.Substring(2, 1)) - int.Parse(jh.Substring(0, 1)) == j)
                        {
                            GMain.Children.Add(Layout.GridInit.TextGreenBL(j.ToString(), i, j + 30, 0, 0));
                        }
                    }
                }
                else if (checkColor(jh.Substring(0, 1), jh.Substring(1, 1), jh.Substring(2, 1)) ==0)
                {
                    GMain.Children.Add(Layout.GridInit.TextBL(jh.Substring(0, 1), i, 1, 0, 0));
                    GMain.Children.Add(Layout.GridInit.TextBL(jh.Substring(1, 1), i, 2, 0, 0));
                    GMain.Children.Add(Layout.GridInit.TextBL(jh.Substring(2, 1), i, 3, 0, 0));
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 6; k++)
                        {
                            if (jh.Substring(j, 1) == (k + 1).ToString()) { GMain.Children.Add(Layout.GridInit.TextBL(jh.Substring(j, 1), i, k + 4, 0, 0)); }
                        }
                    }
                    for (int j = 0; j < 15; j++)
                    {
                        if (hz(jh) == j) { GMain.Children.Add(Layout.GridInit.TextBL(hz(jh).ToString(), i, j + 7, 0, 0)); }
                        if (hz(jh) >= 10) { GMain.Children.Add(Layout.GridInit.TextBL("大", i, 26, 0, 0)); }
                        else { GMain.Children.Add(Layout.GridInit.TextBL("小", i, 27, 0, 0)); }
                        if (hz(jh) % 2 != 0) { GMain.Children.Add(Layout.GridInit.TextBL("单", i, 28, 0, 0)); }
                        else { GMain.Children.Add(Layout.GridInit.TextBL("双", i, 29, 0, 0)); }
                    }
                    for (int j = 0; j < 6; j++)
                    {
                        if (int.Parse(jh.Substring(2, 1)) - int.Parse(jh.Substring(0, 1)) == j)
                        {
                            GMain.Children.Add(Layout.GridInit.TextBL(j.ToString(), i, j + 30, 0, 0));
                        }
                    }
                }
                
                if (i > 2){i--;}else { break; }
            }
        }
        private int checkColor(string a,string b,string c)
        {
            int i = 0;
            if (a == b && a == c && a == c) { i = 3; }
            else if ((a == b && b != c)|| (a != b && b == c)|| (a== c && b != c)){ i = 2; }
            else if (int.Parse(b) - int.Parse(a) == 1 && int.Parse(c) - int.Parse(b) == 1) { i = 1; }
            return i;
        }
        private int hz(string a)
        {
            int res = 0;
            for (int i = 0; i < a.Length; i++)
            {
                res += int.Parse(a.Substring(i, 1));
            }
            return res;
        }
    }
}
