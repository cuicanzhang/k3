using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace K3Drawing.Layout
{
    class GridInit
    {
        public GridInit()
        {

        }
        public void Init(Grid GMain)
        {
            for (int i = 0; i < 20; i++)
            {
                GMain.RowDefinitions.Add(new RowDefinition()); //创建行
                GMain.RowDefinitions[i].Height = new GridLength();

            }
            for (int i = 0; i < 38; i++)
            {
                GMain.ColumnDefinitions.Add(new ColumnDefinition());//创建列
                GMain.ColumnDefinitions[i].Width = new GridLength();

            }
            Label qhLB = new Label
            {
                Content = "期\n号",
                HorizontalAlignment = HorizontalAlignment.Center,

            };
            qhLB.SetValue(Grid.RowProperty, 0);
            qhLB.SetValue(Grid.ColumnProperty, 0);
            qhLB.SetValue(Grid.RowSpanProperty, 2);
            GMain.Children.Add(qhLB);

            Label jhLB = new Label
            {
                Content = "奖号",
                HorizontalAlignment = HorizontalAlignment.Center,

            };
            jhLB.SetValue(Grid.RowProperty, 0);
            jhLB.SetValue(Grid.ColumnProperty, 1);
            jhLB.SetValue(Grid.ColumnSpanProperty, 3);
            GMain.Children.Add(jhLB);

            Label fbLB = new Label
            {
                Content = "组选分布图",
                HorizontalAlignment = HorizontalAlignment.Center,

            };
            fbLB.SetValue(Grid.RowProperty, 0);
            fbLB.SetValue(Grid.ColumnProperty, 4);
            fbLB.SetValue(Grid.ColumnSpanProperty, 6);
            GMain.Children.Add(fbLB);

            Label hzLB = new Label
            {
                Content = "和值",
                HorizontalAlignment = HorizontalAlignment.Center,

            };
            hzLB.SetValue(Grid.RowProperty, 0);
            hzLB.SetValue(Grid.ColumnProperty, 10);
            hzLB.SetValue(Grid.ColumnSpanProperty, 15);
            GMain.Children.Add(hzLB);

            Label dxLB = new Label
            {
                Content = "大小",
                HorizontalAlignment = HorizontalAlignment.Center,

            };
            dxLB.SetValue(Grid.RowProperty, 0);
            dxLB.SetValue(Grid.ColumnProperty, 28);
            dxLB.SetValue(Grid.ColumnSpanProperty, 2);
            GMain.Children.Add(dxLB);

            Label dsLB = new Label
            {
                Content = "单双",
                HorizontalAlignment = HorizontalAlignment.Center,

            };
            dsLB.SetValue(Grid.RowProperty, 0);
            dsLB.SetValue(Grid.ColumnProperty, 30);
            dsLB.SetValue(Grid.ColumnSpanProperty, 2);
            GMain.Children.Add(dsLB);

            Label kdLB = new Label
            {
                Content = "跨度",
                HorizontalAlignment = HorizontalAlignment.Center,

            };
            kdLB.SetValue(Grid.RowProperty, 0);
            kdLB.SetValue(Grid.ColumnProperty, 32);
            kdLB.SetValue(Grid.ColumnSpanProperty, 6);
            GMain.Children.Add(kdLB);
            for (int i = 0; i < 3; i++)
            {
                Label jh123LB = new Label
                {
                    Content = i + 1,

                };
                jh123LB.SetValue(Grid.RowProperty, 1);
                jh123LB.SetValue(Grid.ColumnProperty, i + 1);
                GMain.Children.Add(jh123LB);
            }
            for (int i = 0; i < 6; i++)
            {
                Label fb126LB = new Label
                {
                    Content = i + 1,

                };
                fb126LB.SetValue(Grid.RowProperty, 1);
                fb126LB.SetValue(Grid.ColumnProperty, i + 4);
                GMain.Children.Add(fb126LB);
            }
            for (int i = 0; i < 16; i++)
            {
                Label hz3218LB = new Label
                {
                    Content = i + 3,

                };
                hz3218LB.SetValue(Grid.RowProperty, 1);
                hz3218LB.SetValue(Grid.ColumnProperty, i + 10);
                GMain.Children.Add(hz3218LB);
            }

            Label dxdLB = new Label
            {
                Content = "大",

            };
            dxdLB.SetValue(Grid.RowProperty, 1);
            dxdLB.SetValue(Grid.ColumnProperty, 28);
            GMain.Children.Add(dxdLB);

            Label dxxLB = new Label
            {
                Content = "小",

            };
            dxxLB.SetValue(Grid.RowProperty, 1);
            dxxLB.SetValue(Grid.ColumnProperty, 29);
            GMain.Children.Add(dxxLB);

            Label dsdLB = new Label
            {
                Content = "单",

            };
            dsdLB.SetValue(Grid.RowProperty, 1);
            dsdLB.SetValue(Grid.ColumnProperty, 30);
            GMain.Children.Add(dsdLB);

            Label dssLB = new Label
            {
                Content = "单",

            };
            dssLB.SetValue(Grid.RowProperty, 1);
            dssLB.SetValue(Grid.ColumnProperty, 31);
            GMain.Children.Add(dssLB);

            for (int i = 0; i < 6; i++)
            {
                Label kd025LB = new Label
                {
                    Content = i,

                };
                kd025LB.SetValue(Grid.RowProperty, 1);
                kd025LB.SetValue(Grid.ColumnProperty, i + 32);
                GMain.Children.Add(kd025LB);
            }
        }
    }
}
