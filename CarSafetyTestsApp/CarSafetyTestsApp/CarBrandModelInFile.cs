namespace CarSafetyTestsApp
{
    public class CarBrandModelInFile : CarBrandBase
    {
        private const string path = "GradesSave.txt";
        public override event NewGradeAddedDelegate NewGradeAdded;

        public CarBrandModelInFile(string brandName, string factory, string prototypeName)
            : base(brandName, factory, prototypeName)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public override void AddGrade(float grade)
        {
            using (var writer = File.AppendText(path))
            {
                if (grade >= 0 && grade <= 10)
                {
                    writer.WriteLine(grade);
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
        }

        public override void AddGrade(int grade)
        {
            AddGrade((float)grade);
        }

        public override void AddGrade(string grade)
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

        public override void AddGrade(char grade)
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
        private List<float> ReadGradesFromFileToList()
        {
            List<float> resultList = new List<float>();
            if (File.Exists(path))
            {
                using (var reader = File.OpenText(path))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        if (float.TryParse(line, out float result))
                        {
                            resultList.Add(result);
                        }
                        line = reader.ReadLine();
                    }
                }
                return resultList;
            }
            else
                throw new Exception("There is no file.");
        }
        public override Statistics GetStatistics()
        {
            var grades = ReadGradesFromFileToList();
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
