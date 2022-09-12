using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusTracking
{
    public static class DownloadTracking
    {
        static long _currentSpeed = 0;
        public static long CurrentSize = 0;
        public static long FullSize = 0;
        public static long DownloadStatus = 0;
        public static string FileName;
        public static bool IsDownload = false;
        public static long CurrentSpeed
        {
            get => _currentSpeed; set
            {
                if (value != 0)
                    _currentSpeed = value;
                else IsDownload = false;
            }
        }
        public static void Clear()
        {
            CurrentSize = 0;
            FullSize = 0;
            DownloadStatus = 0;
            FileName = "";
        }
    }
}
