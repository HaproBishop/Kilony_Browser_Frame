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

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Main.GetBrowser().Reload();
        }

        private void Link_GotFocus(object sender, RoutedEventArgs e)
        {
            Linker.IsDefault = true;
        }

        private void Link_LostFocus(object sender, RoutedEventArgs e)
        {
            Linker.IsDefault = false;
        }

        private void Gmail_Click(object sender, RoutedEventArgs e)
        {
            Link.Text = "https://gmail.com";
            HideMenuAndSearch(sender, e);
        }

        private void Google_Click(object sender, RoutedEventArgs e)
        {
            Link.Text = "https://google.com";
            HideMenuAndSearch(sender, e);
        }
        private void HideMenuAndSearch(object sender, RoutedEventArgs e)
        {
            StartMenu.IsExpanded = false;
            Linker_Click(sender, e);
        }

        private void Youtube_Click(object sender, RoutedEventArgs e)
        {
            Link.Text = "https://youtube.com";
            HideMenuAndSearch(sender, e);
        }

        private void MailRu_Click(object sender, RoutedEventArgs e)
        {
            Link.Text = "https://mail.ru";
            HideMenuAndSearch(sender, e);
        }

        private void YandexMail_Click(object sender, RoutedEventArgs e)
        {
            Link.Text = "https://mail.yandex.ru";
            HideMenuAndSearch(sender, e);
        }

        private void Yandex_Click(object sender, RoutedEventArgs e)
        {
            Link.Text = "https://yandex.ru";
            HideMenuAndSearch(sender, e);
        }

        private void Rutube_Click(object sender, RoutedEventArgs e)
        {
            Link.Text = "https://rutube.ru";
            HideMenuAndSearch(sender, e);
        }

        private void VK_Click(object sender, RoutedEventArgs e)
        {
            Link.Text = "https://vk.com";
            HideMenuAndSearch(sender, e);
        }

        private void Windows11_Click(object sender, RoutedEventArgs e)
        {
            Link.Text = "https://www.microsoft.com/ru-ru/software-download/windows11";
            HideMenuAndSearch(sender, e);
        }
    }
}
