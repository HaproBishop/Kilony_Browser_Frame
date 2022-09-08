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
        public TabItem CreateTab(string tabName, string address)
        {
            TabItem newTab = new TabItem
            {
                Header = tabName,
                Content = new ChromiumWebBrowser(address)
            };
            return newTab;
        }
    }
}
