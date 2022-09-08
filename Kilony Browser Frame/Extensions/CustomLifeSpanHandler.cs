using CefSharp;
namespace Kilony_Browser_Frame.Extensions
{
    public class CustomLifeSpanHandler : ILifeSpanHandler
    {
        public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            return true;
        }

        public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
        }

        public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {            
        }

        // Load new URL (when clicking a link with target=_blank) in the same frame
        public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {

            browser.MainFrame.LoadUrl(targetUrl);//Добавление вкладок. Реализация вкладки в отдельный метод.
            newBrowser = null;
            return true;
        }
    }
}