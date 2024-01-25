namespace CarSafetyTestsApp
{
    public class Statistics
    {
        public float Max { get; private set; }
        public float Min { get; private set; }
        public float Sum { get; private set; }
        public float Count { get; private set; }
        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }
        public char AverageAsLetter
        {
            get
            {
                switch (this.Average)
                {
                    case var grade when grade >= 9.0f:
                        return 'A';
                    case var grade when grade >= 8.0f:
                        return 'B';
                    case var grade when grade >= 7.0f:
                        return 'C';
                    case var grade when grade >= 6.0f:
                        return 'D';
                    case var grade when grade >= 5.0f:
                        return 'E';
                    case var grade when grade < 5.0f:
                        return 'F';
                    default:
                        return 'F';
                }
            }
        }
        public int PassedOrFailed { get; private set; }

        public Statistics()
        {
            this.Max = float.MinValue;
            this.Min = float.MaxValue;
            this.Sum = 0;
            this.Count = 0;
            this.PassedOrFailed = 0;
        }

        public Statistics(int empty)
        {
            this.Max = 0;
            this.Min = 0;
            this.Sum = 0;
            this.Count = 0;
            this.PassedOrFailed = 0;
        }

        public void AddGrade(float grade)
        {
            this.Sum += grade;
            this.Count++;

            if (grade > this.Max)
            {
                this.Max = grade;
            }
            if (grade < this.Min)
            {
                this.Min = grade;
            }
            TestPassValidator();
        }

        private void TestPassValidator()
        {
            if (this.Count >= 5 && this.Min >= 2.0f && this.Average >= 5.0f)
            {
                this.PassedOrFailed = 1;
            }
        }

        public void PrintStatistics()
        {
            string PassOrFail = PassedOrFailed == 1 ? "Zaliczony" : "Niezaliczony";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Średnia ocena z {this.Count} testów wynosi: {this.Average:F2}. Oznaczenie literowe: {this.AverageAsLetter}");
            Console.WriteLine($"Najwyższa uzyskana ocena to: {this.Max}");
            Console.WriteLine($"Najniższa uzyskana ocena to: {this.Min}");
            Console.WriteLine($"Certyfikat: {PassOrFail}");
            Console.ResetColor();
        }
    }
}
