using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace BTSearch
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            myFrame.Width = Window.Current.Bounds.Width;

            SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
            myFrame.Navigate(typeof(DouBan));

            Window.Current.SizeChanged += Current_SizeChanged;

        }

        private void Current_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            myFrame.Width = e.Size.Width;
        }

        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            myFrame.Navigate(typeof(DouBan));
            HideBarBack();
            lbi_home.IsSelected = true;
        }

        private void btn_ham_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }

        private void lb_menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var temp_select_index = lb_menu.SelectedIndex;
            lb_setting.SelectedIndex = -1;
            //lb_menu.SelectedIndex = temp_select_index;

            if (lbi_home.IsSelected)
            {
                myFrame.Navigate(typeof(DouBan));
                lbi_home.IsSelected = true;
                HideBarBack();
            }
            
        }

        private void lb_setting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var temp_select_index = lb_setting.SelectedIndex;
            lb_menu.SelectedIndex = -1;
            //lb_setting.SelectedIndex = temp_select_index;

            if (lbi_about.IsSelected)
            {
                ShowMessageBox();
            }
        }


        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txt_word.Text))
            {
                NotifyPopup notifyPopup = new NotifyPopup(" 搜 点 啥 ? ");
                notifyPopup.Show();
            }else
                Search();
        }

        private void Search()
        {
            if (!string.IsNullOrWhiteSpace(txt_word.Text))
            {
                myFrame.Navigate(typeof(Search));
                ShowBarBack();
            }
        }


        private async void ShowMessageBox()
        {
            var dialog = new ContentDialog()
            {
                Title = "关于",
                Content = "本软件中所有的数据皆来自互联网，本人不承担任何法律责任。",
                PrimaryButtonText = "确定",
                FullSizeDesired = false,
            };

            dialog.PrimaryButtonClick += (_s, _e) => { };
            await dialog.ShowAsync();
        }


        /// <summary>
        /// 显示标题栏后退按钮
        /// </summary>
        private void ShowBarBack()
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        /// <summary>
        /// 隐藏标题栏后退按钮
        /// </summary>
        private void HideBarBack()
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void cb_source_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }

        
    }
}
