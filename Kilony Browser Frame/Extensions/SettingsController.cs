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
        public void SaveHistory(StackPanel stackPanel)
        {
            StreamWriter writer = new StreamWriter("KilonyHistory.txt");                
            for (int i = 0; i < stackPanel.Children.Count; i++)
            {
                writer.WriteLine(((Expander)stackPanel.Children[i]).Header);
                ListView currentHistoryList = (ListView)((Expander)stackPanel.Children[i]).Content;
                for (int j = 0; j < currentHistoryList.Items.Count; j++)
                {
                    NewRow row = (NewRow)currentHistoryList.Items[j];
                    writer.WriteLine(row.Title);
                    writer.WriteLine(row.Link);
                    writer.WriteLine(row.Time);
                }
            }
            writer.Close();
        }
    }
}
