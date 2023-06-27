namespace WorkingTimerApp
{
    public class Statistics
    {
        private readonly List<TimeSpan> time = new List<TimeSpan>();
        public TimeSpan ShortestWorkingDay
        {
            get
            {
                if (time.Count != 0)
                {
                    return this.time.Min();
                }
                else
                {
                    return TimeSpan.Zero;
                }
            }
        }
        public TimeSpan LongestWorkingDay
        {
            get
            {
                if (time.Count != 0)
                {
                    return this.time.Max();
                }
                else
                {
                    return TimeSpan.Zero;
                }
            }
        }

        public TimeSpan TotalTime { get; private set; }

        public int NumberOfDays { get; private set; }

        public TimeSpan AverageWorkingTime
        {
            get
            {
                if (time.Count != 0)
                {
                    return this.TotalTime.Divide(this.NumberOfDays);
                }
                else
                {
                    return TimeSpan.Zero;
                }
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