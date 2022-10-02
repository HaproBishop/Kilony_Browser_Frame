using CefSharp.Wpf;
using System.Windows.Controls;

namespace Kilony_Browser_Frame.Extensions
{
    public class TabCreating
    {
        public static string NewTabAddress;
        public static TabItem CreateTab(string tabName, string address)
        {
            var web = new ChromiumWebBrowser(address);
            web.DownloadHandler = new CustomDownloadHandler();
            web.LifeSpanHandler = new CustomLifeSpanHandler();
            TabItem newTab = new TabItem
            {
                Header = tabName,
                Content = web
            };
            return newTab;
        }
    }
}
