using System.Globalization;

namespace WorkingTimerApp
{
    public class SickLeaveTimeInFile : TimerBase
    {
        public SickLeaveTimeInFile(string category)
            : base(category)
        {
            fileName = "_medicalLeaveTimes.txt";
        }
    }
}