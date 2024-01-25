namespace CarSafetyTestsApp.Tests
{
    public class CarBrandModelInFileTests
    {
        [Test]
        public void WhenGradeWritenToFile_CorrectCalculationsAreMadeWhileReading()
        {
            //Arrange
            CarBrandModelInMemory carPrototype = new CarBrandModelInMemory("", "", "");
            float grade1 = 5.0f;
            int grade2 = 7;
            string grade3 = "8";
            char grade4 = 'A';

            //Act
            carPrototype.AddGrade(grade1);
            carPrototype.AddGrade(grade2);
            carPrototype.AddGrade(grade3);
            carPrototype.AddGrade(grade4);
            var stats = carPrototype.GetStatistics();

            //Assert
            Assert.AreEqual(10.0f, stats.Max);
            Assert.AreEqual(5.0f, stats.Min);
            Assert.AreEqual(7.5f, stats.Average);
        }
    }
}
