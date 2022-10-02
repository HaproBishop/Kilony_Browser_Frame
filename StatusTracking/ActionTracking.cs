namespace StatusTracking
{
    public static class ActionTracking
    {
        public static string ActionStatus;
        public static int StatusTries = 0;
        public static void MakeStatus(string action)
        {
            ActionStatus = action;
            StatusTries = 5;
        }
        public static void MakeStatus(string action, int tries)
        {
            ActionStatus = action;
            StatusTries = tries;
        }
        public static void Clear()
        {
            ActionStatus = "";
        }
    }
}
