namespace CarSafetyTestsApp
{
    public interface ICarBrand
    {
        string BrandName { get; }
        string Factory { get; }
        string PrototypeName { get; }

        void AddGrade(float grade);
        void AddGrade(int grade);
        void AddGrade(string grade);
        void AddGrade(char grade);
        Statistics GetStatistics();
    }
}
