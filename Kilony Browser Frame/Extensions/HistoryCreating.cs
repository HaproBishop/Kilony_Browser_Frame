using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Kilony_Browser_Frame.Extensions
{/// <summary>
/// Позволяет создать историю дня (экземплярами можно реализовать несколько дней)
/// </summary>
    public class HistoryCreating
    {                
        DateTime _dateTime;
        public Expander DayExpander;
        public DateTime Date { get => _dateTime.Date; set => _dateTime = value; }//Задается один раз
        public HistoryCreating()
        {
            _dateTime = DateTime.Now;
        }        
        public void AddNewSite(string title, string link)
        {
            if (DateTime.Now.Date != Date) throw new Exception("Наступил следующий день, невозможно добавить сайт в список");
            ((ListView)DayExpander.Content).Items.Add(new NewRow(title, link));           
        }
        public Expander CreateFormDayHistory()
        {
            GridView table = new GridView();
            table.Columns.Add(new GridViewColumn
            {
                Header = "Заголовок сайта",
                Width = 250,
                DisplayMemberBinding = new Binding(path: "Title")
            }
            );
            table.Columns.Add(new GridViewColumn
            {
                Header = "Ссылка",
                Width = 395,
                DisplayMemberBinding = new Binding(path: "Link")
            }
            ) ;
            table.Columns.Add(new GridViewColumn
            {
                Header = "Время",
                Width = 140,
                DisplayMemberBinding = new Binding(path: "Time")
            }
            );
            ListView view = new ListView
            {
                View = table
            };
            Expander expander = new Expander
            {
                Header = Date,
                Content = view,
                IsExpanded = false
            };
            return DayExpander = expander;
        }
    }
    public struct NewRow
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Time { get; set; }
        public NewRow(string title, string link)
        {
            Title = title;
            Link = link;
            Time = (DateTime.Now.TimeOfDay.Hours + ":" + DateTime.Now.TimeOfDay.Minutes).ToString();
        }
    }
}
