using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Kilony_Browser_Frame.Extensions;
using StatusTracking;
using System.Diagnostics;

namespace Kilony_Browser_Frame.Pages
{
    /// <summary>
    /// Логика взаимодействия для WebPage.xaml
    /// </summary>
    public partial class WebPage : Page
    {
        public WebPage()
        {
            InitializeComponent();
            Main.LifeSpanHandler = new CustomLifeSpanHandler();
            Main.DownloadHandler = new CustomDownloadHandler();
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (TabCreating.NewTabAddress != null)
                {
                    Tabs.Items.Add(TabCreating.CreateTab(_currentWeb.Title, TabCreating.NewTabAddress));
                    TabCreating.NewTabAddress = null;
                    UpdateTabInfo();
                }
                if (DownloadTracking.IsDownload)
                {                    
                    StatusText.Text = "Загрузка файла: " + DownloadTracking.FileName;
                    PercentStatus.Text = (DownloadTracking.DownloadStatus).ToString() + " %";
                    DownloadSpeed.Text = DownloadTracking.CurrentSpeed.ToString() + " КБ/с";
                    Progress.Value = DownloadTracking.DownloadStatus;
                    return;
                }
                else
                {
                    PercentStatus.Text = "";
                    DownloadSpeed.Text = "";
                    Progress.Value = 0;
                }
                if (ActionTracking.StatusTries != 0)
                {                    
                    ActionTracking.StatusTries--;
                }
                else
                {
                    StatusText.Text = "";
                    Progress.IsIndeterminate = false;
                }
            }
            catch { }
        }
        private void ActionTrigger(string action)
        {
            ActionTracking.MakeStatus(action);
            Progress.IsIndeterminate = true;
            StatusText.Text = ActionTracking.ActionStatus;
        }

        DispatcherTimer timer;
        ChromiumWebBrowser _currentWeb;
        private void Linker_Click(object sender, RoutedEventArgs e)
        {
            _currentWeb.Address = Link.Text;
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            _currentWeb.GetBrowser().GoBack();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            _currentWeb.GetBrowser().GoForward();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            _currentWeb.GetBrowser().Reload();
        }

        private void Link_GotFocus(object sender, RoutedEventArgs e)
        {
            Link.SelectAll();
        }

        private void Gmail_Click(object sender, RoutedEventArgs e)
        {
            Link.Text = "https://gmail.com/";
            HideMenuAndSearch(sender, e);
        }

        private void Google_Click(object sender, RoutedEventArgs e)
        {
            Link.Text = "https://google.com/";
            HideMenuAndSearch(sender, e);
        }
        private void HideMenuAndSearch(object sender, RoutedEventArgs e)
        {
            StartMenu.IsExpanded = false;
            Linker_Click(sender, e);
        }

        private void Youtube_Click(object sender, RoutedEventArgs e)
        {
            Link.Text = "https://youtube.com/";
            HideMenuAndSearch(sender, e);
        }

        private void MailRu_Click(object sender, RoutedEventArgs e)
        {
            Link.Text = "https://mail.ru/";
            HideMenuAndSearch(sender, e);
        }

        private void YandexMail_Click(object sender, RoutedEventArgs e)
        {
            Link.Text = "https://mail.yandex.ru/";
            HideMenuAndSearch(sender, e);
        }

        private void Yandex_Click(object sender, RoutedEventArgs e)
        {
            Link.Text = "https://yandex.ru/";
            HideMenuAndSearch(sender, e);
        }

        private void Rutube_Click(object sender, RoutedEventArgs e)
        {
            Link.Text = "https://rutube.ru/";
            HideMenuAndSearch(sender, e);
        }

        private void VK_Click(object sender, RoutedEventArgs e)
        {
            Link.Text = "https://vk.com/";
            HideMenuAndSearch(sender, e);
        }

        private void Windows11_Click(object sender, RoutedEventArgs e)
        {
            Link.Text = "https://www.microsoft.com/ru-ru/software-download/windows11/";
            HideMenuAndSearch(sender, e);
        }

        private void Main_AddressChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Tabs.SelectedItem != null)
            {
                Link.Text = _currentWeb.Address;
            }
        }

        private void Main_TitleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Tabs.SelectedItem != null)
            {
                string title;
                if (_currentWeb.Title.Count() > 15)
                {
                    int countNeedRemove = _currentWeb.Title.Count() - 15;
                    title = _currentWeb.Title.Remove(_currentWeb.Title.Count() - countNeedRemove, countNeedRemove);
                    title += "...";
                }
                else title = _currentWeb.Title;
                ((TabItem)Tabs.SelectedItem).Header = title;
            }
        }

        private void CreateNewTab_Click(object sender, RoutedEventArgs e)
        {
            Tabs.Items.Add(TabCreating.CreateTab("Новая вкладка", "yandex.ru"));
            UpdateTabInfo();
        }

        private void Tabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tabs.SelectedItem != null)
            {
                _currentWeb = (ChromiumWebBrowser)((TabItem)Tabs.SelectedItem).Content;
                Link.Text = _currentWeb.Address;
            }
        }

        private void CloseCurrentTab_Click(object sender, RoutedEventArgs e)
        {
            if (Main != _currentWeb) Tabs.Items.Remove(Tabs.SelectedItem);
            else MessageBox.Show("Главную вкладку нельзя закрыть!", "Главная вкладка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Программа имеет следующие особенности:\n" +
                "1) Отсутствует возможно проигрывать некоторые видео и смотреть трансляции " +
                "из-за отсутствия лицензированного кодека в CEF, который легко получить нельзя.\n" +
                "", "Справка", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчиком является студент группы ИСП-41 Лопаткин Сергей. \nGitHub.Name = HaproBishop", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void UpdateTabInfo()
        {
            Tabs.SelectedItem = Tabs.Items[Tabs.Items.Count - 1];
            _currentWeb.AddressChanged += Main_AddressChanged;
            _currentWeb.TitleChanged += Main_TitleChanged;
        }

        private void CopyLink_Click(object sender, RoutedEventArgs e)
        {
            Link.SelectAll();
            Link.Copy();
            ActionTrigger("Скопировано");
            
        }
        
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainPageWindow.Content = new SettingsPage();
        }

        private void DownloadList_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", @"C:\Users\" + Environment.UserName + @"\Downloads\");
        }
    }
}
