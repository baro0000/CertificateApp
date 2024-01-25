namespace CarSafetyTestsApp.Tests
{
    public class StatisticsTests
    {
        [Test]
        public void WhenThreeGradesAdded_CorrectResultReturned()
        {
            //Arrange
            var grades = new[] { 5.0f, 2.0f, 2.0f };
            Statistics stats = new Statistics();

            //Act
            foreach (var grade in grades)
            {
                stats.AddGrade(grade);
            }

            //Assertion
            Assert.AreEqual(3.0f, stats.Average);
            Assert.AreEqual(2.0f, stats.Min);
            Assert.AreEqual(5.0f, stats.Max);
        }
        [Test]
        public void WhenGradesAverageCalculated_CorrectLetterReturned()
        {
            //Arrange
            List<char> results = new List<char>();

            //Act
            for (float i = 4; i < 10; i++)
            {
                Statistics statistic = new Statistics();
                for (int j = 0; j < 3; j++)
                {
                    statistic.AddGrade(i);
                    Console.WriteLine(i);
                }
                results.Add(statistic.AverageAsLetter);
            }

            //Assertion
            Assert.AreEqual('F', results[0]);
            Assert.AreEqual('E', results[1]);
            Assert.AreEqual('D', results[2]);
            Assert.AreEqual('C', results[3]);
            Assert.AreEqual('B', results[4]);
            Assert.AreEqual('A', results[5]);
        }
        [Test]
        public void WhenMeetRequirements_PassOrFailedSetTo1()
        {
            //Requirements: At least 5 grades, Average higher or equal to 5.0, all grades higher than 2.0
            //Arrange
            var grades = new[] { 5.0f, 5.0f, 10.0f, 8.0f, 9.0f };
            Statistics stats = new Statistics();

            //Act
            foreach (var grade in grades)
            {
                stats.AddGrade(grade);
            }

            //Assertion
            Assert.AreEqual(1, stats.PassedOrFailed);
            Assert.GreaterOrEqual(stats.Min, 2.0f);
            Assert.GreaterOrEqual(stats.Average, 5.0f);
            Assert.GreaterOrEqual(stats.Count, 5);
        }
        [Test]
        public void WhenLessThan5Grades_PassOrFailedSetTo0()
        {
            //Requirements: At least 5 grades, Average higher or equal to 5.0, all grades higher than 2.0
            //Arrange
            var grades = new[] { 5.0f, 5.0f, 10.0f };
            Statistics stats = new Statistics();

            //Act
            foreach (var grade in grades)
            {
                stats.AddGrade(grade);
            }

            //Assertion
            Assert.AreEqual(0, stats.PassedOrFailed);
        }
        [Test]
        public void WhenAverageLessThan5_PassOrFailedSetTo0()
        {
            //Requirements: At least 5 grades, Average higher or equal to 5.0, all grades higher than 2.0
            //Arrange
            var grades = new[] { 5.0f, 5.0f, 5.0f, 5.0f, 2.0f };
            Statistics stats = new Statistics();

            //Act
            foreach (var grade in grades)
            {
                stats.AddGrade(grade);
            }

            //Assertion
            Assert.AreEqual(0, stats.PassedOrFailed);
        }
        [Test]
        public void WhenOneGradeLowerThan2_PassOrFailedSetTo0()
        {
            //Requirements: At least 5 grades, Average higher or equal to 5.0, all grades higher than 2.0
            //Arrange
            var grades = new[] { 5.0f, 7.0f, 8.0f, 9.0f, 1.0f };
            Statistics stats = new Statistics();

            //Act
            foreach (var grade in grades)
            {
                stats.AddGrade(grade);
            }

            //Assertion
            Assert.AreEqual(0, stats.PassedOrFailed);
        }
    }
}