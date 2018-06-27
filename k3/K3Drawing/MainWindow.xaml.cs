using System;
using System.Collections.Generic;
using System.Linq;
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

            
            MainMwindow_Load();
        }
        void MainMwindow_Load()
        {
            Layout.GridInit.Init(GMain);
            Label qhLB = new Label
            {
                Content = "11111",
                HorizontalAlignment = HorizontalAlignment.Center,

            };
            qhLB.SetValue(Grid.RowProperty, 0);
            qhLB.SetValue(Grid.ColumnProperty, 3);
            qhLB.SetValue(Grid.RowProperty,3);
            GMain.Children.Add(qhLB);
        }
    }
}
