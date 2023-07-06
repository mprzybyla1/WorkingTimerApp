using System.Globalization;

namespace WorkingTimerApp
{
    public class WorkingTimeInFile : TimerBase
    {
        public WorkingTimeInFile(string category)
            : base(category)
        {
            fileName = "_workingTimes.txt";
        }
    }
}