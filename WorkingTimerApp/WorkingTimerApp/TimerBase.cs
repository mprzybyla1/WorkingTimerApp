namespace WorkingTimerApp
{
    public abstract class TimerBase : ITimer
    {
        public delegate void TimeAddedDelegate(object sender, EventArgs args);

        public abstract event TimeAddedDelegate TimeAdded;

        public TimerBase(string category)
        {
            this.Category = category;
        }

        public string Category { get; private set; }

        public abstract void AddTime(string time);

        public abstract Statistics GetStatistics();

        public void ShowSummaryStatistics()
        {
            var statistics = GetStatistics();
            if (statistics != null)
            {
                Console.WriteLine($"--> Minimum number of hours per day: {statistics.ShortestWorkingDay}");
                Console.WriteLine($"--> Maximum number of hours per day: {statistics.LongestWorkingDay}");
                Console.WriteLine($"--> Summary number of hours: {statistics.TotalTime}");
                Console.WriteLine($"--> Average number of hours: {statistics.AverageWorkingTime}");
                Console.WriteLine();
            }
        }

        public void ShowPartialStatistics()
        {
            var statistics = GetStatistics();
            if (statistics != null)
            {
                Console.WriteLine($"--> Summary number of hours: {statistics.TotalTime}");
                Console.WriteLine();
            }
        }
    }
}