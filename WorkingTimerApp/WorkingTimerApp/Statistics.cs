namespace WorkingTimerApp
{
    public class Statistics
    {
        private readonly List<TimeSpan> time = new List<TimeSpan>();
        public TimeSpan ShortestWorkingDay
        {
            get
            {
                return this.time.Min();
            }
        }

        public TimeSpan LongestWorkingDay
        {
            get
            {
                return this.time.Max();
            }
        }

        public TimeSpan TotalTime { get; private set; }

        public int NumberOfDays { get; private set; }

        public TimeSpan AverageWorkingTime
        {
            get
            {
                return this.TotalTime.Divide(this.NumberOfDays);
            }
        }

        public Statistics()
        {
            this.TotalTime = TimeSpan.Zero;
        }

        public void AddTime(TimeSpan time)
        {
            this.time.Add(time);
            this.NumberOfDays++;
            this.TotalTime += time;
        }
    }
}
