namespace StatusTracking
{
    public static class DownloadTracking
    {
        static int _downloadStatus = 0;
        public static long CurrentSize = 0;
        public static long FullSize = 0;
        public static int DownloadStatus
        {
            get => _downloadStatus; set
            {
                if (value > 100) _downloadStatus = 100;
                else if (value < 0)
                {
                    _downloadStatus = 1;
                }
                else _downloadStatus = value;
            }
        }
        public static string FileName;
        public static bool IsDownload = false;
        public static long CurrentSpeed { get; set; }
        public static void Clear()
        {
            CurrentSize = 0;
            FullSize = 0;
            DownloadStatus = 0;
            CurrentSpeed = 0;
        }
    }
}
