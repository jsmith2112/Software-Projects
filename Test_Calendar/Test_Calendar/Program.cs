using System;
using System.Globalization;

class CalendarApp
{
    static void Main()
    {
        // 1. Get user input
        Console.Write("Enter Year (e.g., 2024): ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Enter Month (1-12): ");
        int month = int.Parse(Console.ReadLine());

        // 2. Get the first day of the month and total days
        DateTime firstDay = new DateTime(year, month, 1);
        int totalDays = DateTime.DaysInMonth(year, month);

        // Convert DayOfWeek enum to int (0 for Sunday, 6 for Saturday)
        int startPos = (int)firstDay.DayOfWeek;

        // 3. Print Header
        string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        Console.WriteLine($"\n   {monthName} {year}");
        Console.WriteLine("Su Mo Tu We Th Fr Sa");

        // 4. Print initial spacing for the first week
        for (int i = 0; i < startPos; i++)
        {
            Console.Write("   ");
        }

        // 5. Print the days
        for (int day = 1; day <= totalDays; day++)
        {
            // Format numbers to align correctly
            Console.Write(day.ToString().PadLeft(2) + " ");

            // Start a new line every 7th day (Saturday)
            if ((day + startPos) % 7 == 0)
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine("\n\nPress any key to exit...");
        Console.ReadKey();
    }
}

