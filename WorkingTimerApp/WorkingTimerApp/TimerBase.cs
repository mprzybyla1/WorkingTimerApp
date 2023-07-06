using System.IO.Enumeration;

namespace WorkingTimerApp
{
    public abstract class TimerBase : ITimer
    {
        public delegate void TimeAddedDelegate(object sender, EventArgs args);

        public event TimeAddedDelegate TimeAdded;

        public TimerBase(string category)
        {
            this.Category = category;
        }

        public string Category { get; private set; }

        public string fileName;

        public void AddTime(string time)
        {
            string format = "hh\\:mm";
            time = TimeChanger.TimeFormatter(time);

            if (TimeSpan.TryParseExact(time, format, null, out TimeSpan result))
            {
                using (var writer = File.AppendText($"{fileName}"))
                {
                    writer.WriteLine(time);
                }
                if (TimeAdded != null)
                {
                    TimeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Invalid time value");
            }
        }

        public Statistics GetStatistics()
        {
            var timesFromFile = this.ReadTimesFromFile();
            var statistics = new Statistics();

            foreach (var time in timesFromFile)
            {
                statistics.AddTime(time);
            }
            return statistics;
        }

        private List<TimeSpan> ReadTimesFromFile()
        {
            var timesFromFile = new List<TimeSpan>();
            if (File.Exists($"{fileName}"))
            {
                using (var reader = File.OpenText($"{fileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var time = TimeSpan.Parse(line);
                        timesFromFile.Add(time);
                        line = reader.ReadLine();
                    }
                }
            }
            return timesFromFile;
        }

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