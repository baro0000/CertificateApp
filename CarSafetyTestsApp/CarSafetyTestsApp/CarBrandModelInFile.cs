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
