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

        public abstract void AddGrade(int grade);

        public abstract void AddGrade(string grade);

        public abstract void AddGrade(char grade);

        public abstract Statistics GetStatistics();
    }
}
