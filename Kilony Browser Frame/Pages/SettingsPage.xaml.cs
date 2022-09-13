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
    }
}
