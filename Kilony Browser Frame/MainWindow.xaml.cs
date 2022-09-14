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
using CefSharp.Wpf;

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
    }
}
