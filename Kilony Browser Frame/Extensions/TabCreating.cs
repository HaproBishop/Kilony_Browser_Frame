using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CefSharp.Wpf;

namespace Kilony_Browser_Frame.Extensions
{
    public class TabCreating
    {        
        public static TabItem CreateTab(string tabName, string address)
        {
            var web = new ChromiumWebBrowser(address);
            web.DownloadHandler = new CustomDownloadHandler();
            web.LifeSpanHandler = new CustomLifeSpanHandler();
            TabItem newTab = new TabItem
            {
                Header = tabName,
                Content =  web
            };
            return newTab;
        }
    }
}
