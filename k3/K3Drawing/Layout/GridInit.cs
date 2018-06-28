using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace K3Drawing.Layout
{
    class GridInit
    {
        public static Grid Init(Grid GMain)
        {
            for (int i = 0; i < 50; i++)
            {
                GMain.RowDefinitions.Add(new RowDefinition()); //创建行
                GMain.RowDefinitions[i].Height = new GridLength();
            }
            for (int i = 0; i < 38; i++)
            {
                GMain.ColumnDefinitions.Add(new ColumnDefinition());//创建列
                GMain.ColumnDefinitions[i].Width = new GridLength(14, GridUnitType.Pixel);
                //GMain.ColumnDefinitions[i].Width = new GridLength();
            }
            GMain.Children.Add(TextBL("期\n号", 0, 0, 2, 0));
            GMain.Children.Add(TextBL("奖号", 0, 1, 0, 3));
            GMain.Children.Add(TextBL("组选分布图", 0, 4, 0, 6));
            GMain.Children.Add(TextBL("和值", 0, 10, 0, 15));
            GMain.Children.Add(TextBL("大小", 0, 26, 0, 2));
            GMain.Children.Add(TextBL("单双", 0, 28, 0, 2));
            GMain.Children.Add(TextBL("跨度", 0, 30, 0, 6));
            for (int i = 0; i < 3; i++)
            {
                GMain.Children.Add(TextBL((i+1).ToString(), 1, i + 1, 0, 0));
            }
            for (int i = 0; i < 6; i++)
            {
                GMain.Children.Add(TextBL((i + 1).ToString(), 1, i + 4, 0, 0));
            }
            for (int i = 0; i < 16; i++)
            {
                GMain.Children.Add(TextBL((i + 3).ToString(), 1, i + 10, 0, 0));
            }

            GMain.Children.Add(TextBL("大", 1,26, 0, 0));
            GMain.Children.Add(TextBL("小", 1, 27, 0, 0));
            GMain.Children.Add(TextBL("单", 1, 28, 0, 0));
            GMain.Children.Add(TextBL("双", 1, 29, 0, 0));
            for (int i = 0; i < 6; i++)
            {
                GMain.Children.Add(TextBL((i).ToString(), 1, i + 30, 0, 0));
            }
            return GMain;
        }

        public static TextBlock TextBL(string text,int row,int col,int rowspan=0,int colspan=0)
        {
            TextBlock tblname = new TextBlock()
            {
                Text = text,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 15,
                //Background=Brushes.Black,
                //Foreground = Brushes.Red
            };            
            tblname.SetValue(Grid.RowProperty, row);
            tblname.SetValue(Grid.ColumnProperty, col);
            if (rowspan != 0) { tblname.SetValue(Grid.RowSpanProperty, rowspan); }
            if (colspan != 0) { tblname.SetValue(Grid.ColumnSpanProperty, colspan); }
            //GMain.Children.Add(jhTBL);
            return tblname;
        }
        public static TextBlock TextBL(string text,int fontsize, int row, int col, int rowspan = 0, int colspan = 0)
        {
            TextBlock tblname = new TextBlock()
            {
                
                Text = text,
                FontSize = fontsize,
                //Background=Brushes.Black,
                //Foreground = Brushes.Red,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            tblname.SetValue(Grid.RowProperty, row);
            tblname.SetValue(Grid.ColumnProperty, col);
            if (rowspan != 0) { tblname.SetValue(Grid.RowSpanProperty, rowspan); }
            if (colspan != 0) { tblname.SetValue(Grid.ColumnSpanProperty, colspan); }
            //GMain.Children.Add(jhTBL);
            return tblname;
        }
        public static TextBlock TextYellowBL(string text, int fontsize, int row, int col, int rowspan = 0, int colspan = 0)
        {
            TextBlock tblname = new TextBlock()
            {

                Text = text,
                FontSize = fontsize,
                Background=Brushes.Yellow,
                //Foreground = Brushes.Red,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            tblname.SetValue(Grid.RowProperty, row);
            tblname.SetValue(Grid.ColumnProperty, col);
            if (rowspan != 0) { tblname.SetValue(Grid.RowSpanProperty, rowspan); }
            if (colspan != 0) { tblname.SetValue(Grid.ColumnSpanProperty, colspan); }
            //GMain.Children.Add(jhTBL);
            return tblname;
        }
        public static TextBlock TextRedBL(string text, int row, int col, int rowspan = 0, int colspan = 0)
        {
            TextBlock tblname = new TextBlock()
            {

                Text = text,
                FontSize = 15,
                //Background=Brushes.Black,
                Foreground = Brushes.Red,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            tblname.SetValue(Grid.RowProperty, row);
            tblname.SetValue(Grid.ColumnProperty, col);
            if (rowspan != 0) { tblname.SetValue(Grid.RowSpanProperty, rowspan); }
            if (colspan != 0) { tblname.SetValue(Grid.ColumnSpanProperty, colspan); }
            //GMain.Children.Add(jhTBL);
            return tblname;
        }
        public static TextBlock TextBlueBL(string text, int row, int col, int rowspan = 0, int colspan = 0)
        {
            TextBlock tblname = new TextBlock()
            {

                Text = text,
                FontSize = 15,
                //FontFamily = new FontFamily("楷体"),
                //Background=Brushes.Black,
                Foreground = Brushes.Blue,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            tblname.SetValue(Grid.RowProperty, row);
            tblname.SetValue(Grid.ColumnProperty, col);
            if (rowspan != 0) { tblname.SetValue(Grid.RowSpanProperty, rowspan); }
            if (colspan != 0) { tblname.SetValue(Grid.ColumnSpanProperty, colspan); }
            //GMain.Children.Add(jhTBL);
            return tblname;
        }
        public static TextBlock TextGreenBL(string text, int row, int col, int rowspan = 0, int colspan = 0)
        {
            TextBlock tblname = new TextBlock()
            {

                Text = text,
                FontSize = 15,
                //Background=Brushes.Black,
                Foreground = Brushes.DeepSkyBlue,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            tblname.SetValue(Grid.RowProperty, row);
            tblname.SetValue(Grid.ColumnProperty, col);
            if (rowspan != 0) { tblname.SetValue(Grid.RowSpanProperty, rowspan); }
            if (colspan != 0) { tblname.SetValue(Grid.ColumnSpanProperty, colspan); }
            //GMain.Children.Add(jhTBL);
            return tblname;
        }

    }
}
