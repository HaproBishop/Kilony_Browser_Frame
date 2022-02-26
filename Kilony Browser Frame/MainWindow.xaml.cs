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
        }

        private void Linker_Click(object sender, RoutedEventArgs e)
        {
            Main.Address = Link.Text;
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Main.GetBrowser().GoBack();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Main.GetBrowser().GoForward();            
        }

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            Main.Address = "www.yandex.ru";
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Main.GetBrowser().Reload();
        }
    }
}
