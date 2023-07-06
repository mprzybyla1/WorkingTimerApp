namespace WorkingTimerApp
{
    public class PaidLeaveTimeInFile : TimerBase
    {
        public PaidLeaveTimeInFile(string category)
            : base(category)
        {
            fileName = "_paidLeaveTimes.txt";
        }
    }
}