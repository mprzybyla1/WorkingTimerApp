namespace WorkingTimerApp.Tests
{
    class SickLeaveTimeInFileTests
    {
        [Test]
        public void TimeTests()
        {
            // arrange
            var sickLeaveTime = new SickLeaveTimeInFile("L4");

            // act
            sickLeaveTime.AddTime("04:00");
            sickLeaveTime.AddTime("02:00");

            var result = sickLeaveTime.GetStatistics();
            string format = "hh\\:mm";

            // assert
            Assert.That(result.TotalTime.ToString(format), Is.EqualTo("06:00"));
        }
    }
}
