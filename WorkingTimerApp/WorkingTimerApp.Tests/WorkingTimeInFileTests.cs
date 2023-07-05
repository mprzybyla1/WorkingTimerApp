namespace WorkingTimerApp.Tests
{
    public class WorkingTimeInFileTests
    {
        [Test]
        public void TimeTests()
        {
            // arrange
            var workingTime = new TimerBase("Work", "_workingTimes.txt");

            // act
            workingTime.AddTime("04:00");
            workingTime.AddTime("02:00");

            var result = workingTime.GetStatistics();
            string format = "hh\\:mm";

            // assert
            Assert.That(result.AverageWorkingTime.ToString(format), Is.EqualTo("03:00"));
            Assert.That(result.TotalTime.ToString(format), Is.EqualTo("06:00"));
        }
    }
}