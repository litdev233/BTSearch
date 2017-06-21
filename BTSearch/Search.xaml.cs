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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace BTSearch
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Search : Page
    {

        public Search()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            this.Loaded += Search_Loaded;
        }

        private void Search_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var search_key = (string)e.Parameter;
        }

        private async void LoadData()
        {
            var tb_search = (TextBox)Frame.FindName("txt_word");
            var cb_source = (ComboBox)Frame.FindName("cb_source");
            if (string.IsNullOrWhiteSpace(tb_search.Text)) return;
            sp_status.Visibility = Visibility.Collapsed;
            pb_loading.Visibility = Visibility.Visible;
            myScrollViewer.Visibility = Visibility.Collapsed;
            Models.PageList<List<Models.BTInfo>> data = null;
            switch (cb_source.SelectedIndex)
            {
                case 0:
                    data = await Data.DataBTKu.GetData(tb_search.Text);
                    break;
                case 1:
                    data = await Data.DataBTDB.GetData(tb_search.Text);
                    break;
                default:
                    break;
            }
            if (data != null)
            {
                if (data.total > 0)
                {
                    SearchGridView.ItemsSource = data.data;
                    pb_loading.Visibility = Visibility.Collapsed;
                    myScrollViewer.Visibility = Visibility.Visible;
                    tb_status.Text = "";
                    sp_status.Visibility = Visibility.Collapsed;

                }
                else
                {
                    //没有相关数据
                    pb_loading.Visibility = Visibility.Collapsed;
                    SearchGridView.Visibility = Visibility.Collapsed;
                    sp_status.Visibility = Visibility.Visible;
                    tb_status.Text = "没有相关数据";
                }
            }
            else
            {
                pb_loading.Visibility = Visibility.Collapsed;
                myScrollViewer.Visibility = Visibility.Collapsed;
                sp_status.Visibility = Visibility.Visible;
                tb_status.Text = "数据拉取失败";
            }
        }


        private void SearchGridView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btn_reload_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }

}
