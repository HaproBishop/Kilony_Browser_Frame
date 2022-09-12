using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusTracking
{
    public static class DownloadTracking
    {
        static int _downloadStatus = -1;
        public static long CurrentSize = 0;
        public static long FullSize = 0;
        public static int DownloadStatus
        {
            get => _downloadStatus; set
            {
                if (value != 0)
                    _downloadStatus = value;
                else if (value > 100) _downloadStatus = 100;
                else
                {
                    IsDownload = false;
                    Clear();
                }
            }
        }
        public static string FileName;
        public static bool IsDownload = false;
        public static long CurrentSpeed { get; set; }       
        public static void Clear()
        {
            CurrentSize = 0;
            FullSize = 0;
            DownloadStatus = -1;
            FileName = "";
        }
    }
}
