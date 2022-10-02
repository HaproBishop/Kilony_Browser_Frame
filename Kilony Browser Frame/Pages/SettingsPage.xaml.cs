using Kilony_Browser_Frame.Extensions;
using System.Windows;
using System.Windows.Controls;

namespace Kilony_Browser_Frame.Pages
{
    /// <summary>
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void BackToWeb_Click(object sender, RoutedEventArgs e)
        {
            EngineSwitcher.SelectedIndex = WebPage.SettingsData.Engine;
            StartLink.Text = WebPage.SettingsData.StartLink;
            MainWindow.MainPageWindow.Content = MainWindow.MainPage;
        }
        public void AddNewDay()
        {
            HistoryList.Children.Add(new ListViewItem
            {
                Content = WebPage.History[WebPage.History.Count - 1].CreateFormDayHistory()
            }
            );
        }

        public void SaveHistory_Click(object sender, RoutedEventArgs e)
        {
            SettingsController.SaveHistory(HistoryList);
        }
        public void SetLoadedSettings()
        {
            EngineSwitcher.SelectedIndex = WebPage.SettingsData.Engine;
            StartLink.Text = WebPage.SettingsData.StartLink;
        }

        private void SaveAndClose_Click(object sender, RoutedEventArgs e)
        {
            WebPage.SettingsData.Engine = EngineSwitcher.SelectedIndex;
            WebPage.SettingsData.StartLink = StartLink.Text;
            WebPage.SettingsData.SaveMainSettings();
            MainWindow.MainPageWindow.Content = MainWindow.MainPage;
        }
    }
}
