namespace CarSafetyTestsApp
{
    public abstract class CarBrandBase : ICarBrand
    {
        public string BrandName { get; private set; }
        public string Factory { get; private set; }
        public string PrototypeName { get; private set; }
        public delegate void NewGradeAddedDelegate(object sender, EventArgs args);
        public abstract event NewGradeAddedDelegate NewGradeAdded;

        public CarBrandBase(string brandName, string factory, string prototypeName)
        {
            BrandName = brandName;
            Factory = factory;
            PrototypeName = prototypeName;
        }

        public abstract void AddGrade(float grade);

        public void AddGrade(int grade)
        {
            AddGrade((float)grade);
        }

        public void AddGrade(string grade)
        {
            if (float.TryParse(grade, out var gradeInFloat))
            {
                AddGrade(gradeInFloat);
            }
            else
            {
                throw new Exception("Character sequence was provided cannot be converted into a number.");
            }
        }

        public void AddGrade(char grade)
        {
            switch (grade)
            {
                case 'A':
                case 'a':
                    AddGrade(10.0f);
                    break;
                case 'B':
                case 'b':
                    AddGrade(8.0f);
                    break;
                case 'C':
                case 'c':
                    AddGrade(6.0f);
                    break;
                case 'D':
                case 'd':
                    AddGrade(4.0f);
                    break;
                case 'E':
                case 'e':
                    AddGrade(2.0f);
                    break;
                case 'F':
                case 'f':
                    AddGrade(0.0f);
                    break;
                default:
                    throw new Exception("Out of range! Proper letter grade is from A to F.");
            }
        }

        public abstract Statistics GetStatistics();
    }
}
