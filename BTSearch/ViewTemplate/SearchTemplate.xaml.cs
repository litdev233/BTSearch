using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace BTSearch
{
    public sealed partial class SearchTemplate : UserControl
    {
        public Models.BTInfo BTInfo { get { return this.DataContext as Models.BTInfo; } }
        public SearchTemplate()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();
        }
        

        private void btn_copy_Click(object sender, RoutedEventArgs e)
        {
            var item = (Models.BTInfo)this.DataContext;
            DataPackage dp = new DataPackage();
            dp.SetText(item.magnet);
            Clipboard.SetContent(dp);
            NotifyPopup notifyPopup = new NotifyPopup(" 磁力链复制成功 ！ ");
            notifyPopup.Show();
        }
    }
}
