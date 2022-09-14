using Kilony_Browser_Frame.Extensions;
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

        private void SaveHistory_Click(object sender, RoutedEventArgs e)
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
