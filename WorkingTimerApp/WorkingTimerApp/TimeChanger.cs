namespace WorkingTimerApp
{
    public class TimeChanger
    {
        public static string TimeFormatter(string time)
        {
            string[] parts;
            string hours = "0";
            string minutes = "0";
            string timeRecord = "0";

            if (time.Length != 0)
            {
                if (time.Contains(':'))
                {
                    parts = time.Split(':');
                    hours = parts[0];
                    minutes = parts[1];
                }
                timeRecord = hours.PadLeft(2, '0') + ":" + minutes.PadRight(2, '0');
            }
            return timeRecord;
        }
    }
}
