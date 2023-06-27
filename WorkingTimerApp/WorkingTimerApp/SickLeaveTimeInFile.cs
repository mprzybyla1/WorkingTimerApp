namespace WorkingTimerApp
{
    public class SickLeaveTimeInFile : TimerBase
    {
        public override event TimeAddedDelegate TimeAdded;

        private const string fileName = "_medicalLeaveTimes.txt";

        public SickLeaveTimeInFile(string category)
            : base(category)
        {
        }

        public override void AddTime(string time)
        {
            string format = "hh\\:mm";
            time = TimeChanger.TimeFormatter(time);

            if (TimeSpan.TryParseExact(time, format, null, out TimeSpan result))
            {
                using (var writer = File.AppendText($"{fileName}"))
                {
                    writer.WriteLine(result);
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

        public override Statistics GetStatistics()
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
    }
}