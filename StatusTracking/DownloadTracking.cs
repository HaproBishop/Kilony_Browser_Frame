using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusTracking
{
    public static class DownloadTracking
    {
        static long _fullSize = -1;
        static long _currentSize = 0;
        public static long CurrentSize
        {
            get => _currentSize; set
            {
                if (value == _fullSize)
                {
                    IsDownload = false;
                    Clear();
                    ActionTracking.MakeStatus("Загружено");
                }
                else _currentSize = value;
            }
        }
        public static long FullSize { get => _fullSize; set
            {
                if (value == 0)
                {
                    IsDownload = false;
                    Clear();
                    ActionTracking.MakeStatus("Отменено");
                }
            }
        }
        public static int DownloadStatus = 0;
        public static string FileName;
        public static bool IsDownload = false;
        public static long CurrentSpeed = 0;                
        public static void Clear()
        {
            CurrentSize = -1;
            FullSize = -1;
            DownloadStatus = 0;
            FileName = "";
        }
    }
}
