using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace BTSearch
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class DouBan : Page
    {

        public DouBan()
        {
            this.InitializeComponent();
            this.Loaded += DouBan_Loaded;
        }

        private void DouBan_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            sp_status.Visibility = Visibility.Collapsed;
            pb_loading.Visibility = Visibility.Visible;
            myScrollViewer.Visibility = Visibility.Collapsed;
            Models.DouBan data = await Data.DataDouBan.GetWebData();
            if (data != null)
            {
                if (data.subjects != null)
                {
                    if(data.subjects.Count >0)
                    {
                        DouBanGridView.ItemsSource = data.subjects;
                        pb_loading.Visibility = Visibility.Collapsed;
                        myScrollViewer.Visibility = Visibility.Visible;
                        tb_status.Text = "";
                        sp_status.Visibility = Visibility.Collapsed;
                    }else
                    {
                        pb_loading.Visibility = Visibility.Collapsed;
                        myScrollViewer.Visibility = Visibility.Collapsed;
                        sp_status.Visibility = Visibility.Visible;
                        tb_status.Text = "没有相关数据";
                    }
                }else
                {
                    pb_loading.Visibility = Visibility.Collapsed;
                    myScrollViewer.Visibility = Visibility.Collapsed;
                    sp_status.Visibility = Visibility.Visible;
                    tb_status.Text = "数据解析有误";
                }
            }else
            {
                pb_loading.Visibility = Visibility.Collapsed;
                myScrollViewer.Visibility = Visibility.Collapsed;
                sp_status.Visibility = Visibility.Visible;
                tb_status.Text = "数据拉取失败";
            }            
        }

        private void DouBanGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var douban = (Models.DouBanSubject)e.ClickedItem;
            var tb = (TextBox)Frame.FindName("txt_word");
            tb.Text = douban.title;
            Frame.Navigate(typeof(Search), douban.title);
        }
        

        private void btn_reload_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }


        //文本长按弹出按钮
        //private void CopyGameTitle_Click(object sender, RoutedEventArgs e)
        //{
        //    var fe = sender as FrameworkElement;
        //    var game = (Models.Game)fe.DataContext;
        //    DataPackage dp = new DataPackage();
        //    dp.SetText(game.title);
        //    Clipboard.SetContent(dp);
        //    NotifyPopup notifyPopup = new NotifyPopup(" 游戏名称已复制 ");
        //    notifyPopup.Show();
        //}

        //private void GameTitle_RightTapped(object sender, RightTappedRoutedEventArgs e)
        //{
        //    var fe = sender as FrameworkElement;
        //    var menu = Flyout.GetAttachedFlyout(fe);
        //    menu.ShowAt(fe);
        //}

    }
}
