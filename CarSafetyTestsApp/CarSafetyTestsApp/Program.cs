using CarSafetyTestsApp;

Console.WriteLine("Witaj w programie Car Safety Tests. By zakończyć wprowadź \"q\".");


var carPrototype = new CarBrandModelInFile("Mercedes-Benz", "Mercedesstraße 1, 21079 Hamburg, Niemcy", "VISION EQXX v. 3.15");
carPrototype.NewGradeAdded += ConfirmAddedGrade;
void ConfirmAddedGrade(object sender, EventArgs args)
{
    Console.WriteLine("Grade succesfully added.");
}



while (true)
{
    Console.WriteLine("Wprowadź ocenę:");
    var input = Console.ReadLine();

    if (input.Equals("q") || input.Equals("Q"))
    {
        break;
    }

    try
    {
        carPrototype.AddGrade(input);
    }
    catch (Exception ex)
    {
        printRedMessage($"Problem occured! {ex.Message}");
    }
}

try
{
    Statistics statsCarPrototype = carPrototype.GetStatistics();
    statsCarPrototype.PrintStatistics();
}
catch (Exception ex)
{
    printRedMessage(ex.Message);
}



static void printRedMessage(string message)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ResetColor();
}