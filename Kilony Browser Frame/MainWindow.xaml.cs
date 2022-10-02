using System.Windows;
using System.Windows.Controls;

namespace Kilony_Browser_Frame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainPageWindow = this;
            Settings = new Pages.SettingsPage();
            Content = MainPage = new Pages.WebPage();
        }
        public static MainWindow MainPageWindow;
        public static Pages.SettingsPage Settings;
        public static Page MainPage;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите сохранить историю перед закрытием приложения?", "История", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Settings.SaveHistory_Click(sender, new RoutedEventArgs());
            }
            else if (result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
