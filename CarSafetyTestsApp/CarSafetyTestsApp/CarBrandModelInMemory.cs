namespace CarSafetyTestsApp
{
    public class CarBrandModelInMemory : CarBrandBase
    {
        private List<float> grades = new List<float>();
        public override event NewGradeAddedDelegate NewGradeAdded;

        public CarBrandModelInMemory(string brandName, string factory, string prototypeName)
            : base(brandName, factory, prototypeName)
        {

        }

        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 10)
            {
                this.grades.Add(grade);
                if (NewGradeAdded != null)
                {
                    NewGradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Grade is out of range. Proper grade must be from 0 to 10.");
            }
        }

        public override Statistics GetStatistics()
        {
            if (grades.Count > 0)
            {
                Statistics stats = new Statistics();
                foreach (var grade in grades)
                {
                    stats.AddGrade(grade);
                }
                return stats;
            }
            else
            {
                throw new Exception("There is no grades in base.");
            }
        }
    }
}
