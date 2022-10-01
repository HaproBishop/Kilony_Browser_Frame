using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kilony_Browser_Frame.Extensions
{
    public class SettingsController
    {       
        public int Engine;    
        public string StartLink;
        public static void SaveHistory(StackPanel stackPanel)
        {
            string writtingName = DateTime.Now.ToString().Replace(".", "_").Replace(":","-");
            SaveFileDialog save = new SaveFileDialog
            {
                Title = "Сохранение текущей истории",
                DefaultExt = "txt",
                Filter = "Текстовый файл(*.txt) | *.txt | Все файлы(*.*) | *.* ",
                FileName = writtingName
            };
            if (save.ShowDialog() == true)
            {
                StreamWriter writer = new StreamWriter(save.FileName);
                for (int i = 0; i < stackPanel.Children.Count; i++)
                {
                    try
                    {
                        writer.WriteLine(((Expander)((ListViewItem)stackPanel.Children[i]).Content).Header);
                        ListView currentHistoryList = (ListView)((Expander)((ListViewItem)stackPanel.Children[i]).Content).Content;
                        for (int j = 0; j < currentHistoryList.Items.Count; j++)
                        {
                            NewRow row = (NewRow)currentHistoryList.Items[j];
                            writer.Write(row.Title + " | ");
                            writer.Write(row.Link + " | ");
                            writer.WriteLine(row.Time);
                        }
                    }
                    catch { }
                }
                writer.Close();
            }
        }
        public void SaveMainSettings()
        {
            StreamWriter writer = new StreamWriter("KilonySettings.txt");
            writer.WriteLine(Engine);
            writer.WriteLine(StartLink);
            writer.Close();
        }
        public void SaveMainSettings(int engine, string startLink)
        {
            StreamWriter writer = new StreamWriter("KilonySettings.txt");
            writer.WriteLine(Engine = engine);
            writer.WriteLine(StartLink = startLink);
            writer.Close();
        }
        public void LoadMainSettings()
        {
            try
            {
                StreamReader reader = new StreamReader("KilonySettings.txt");
                Engine = Convert.ToInt32(reader.ReadLine());
                StartLink = reader.ReadLine();
                writer.Close();
            }
            catch 
            {
                Engine = 0;
                StartLink = "https://yandex.ru";
            }
        }
    }
}
