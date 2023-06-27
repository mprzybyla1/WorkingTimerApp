using WorkingTimerApp;

namespace WorkingTimesApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WriteLineColour(ConsoleColor.Green, "-------------------------------\n" +
                                                "| Welcome to WorkingTimerApp! |\n" +
                                                "-------------------------------\n" +
                                                " \n" +
                                                "You can collect here your daily amount of:\n" +
                                                " * Working Time\n" +
                                                " * Sick Leave Time\n" +
                                                " * Paid Leave Time\n" +
                                                "and finally get statistics.");
            WriteLineColour(ConsoleColor.Green, "================================================");

            var workingTime = new WorkingTimeInFile("Working time");
            var sickLeaveTime = new SickLeaveTimeInFile("L4");
            var paidLeaveTime = new PaidLeaveTimeInFile("Holiday");

            workingTime.TimeAdded += WorkerTimeAdded;
            sickLeaveTime.TimeAdded += WorkerTimeAdded;
            paidLeaveTime.TimeAdded += WorkerTimeAdded;

            void WorkerTimeAdded(object sender, EventArgs args)
            {
                Console.WriteLine("New time added");
            }

            while (true)
            {
                WriteLineColour(ConsoleColor.Yellow, "Type your daily working time [hh:mm]:\n" +
                                                     "--> press 's' to type your sick leave time\n");
                WriteLineColour(ConsoleColor.Yellow, "~~~~~~~~~~");

                var input = Console.ReadLine();

                WriteLineColour(ConsoleColor.Yellow, "~~~~~~~~~~");

                if (input == "s")
                {
                    break;
                }
                try
                {
                    workingTime.AddTime(input);
                }
                catch (Exception ex)
                {
                    WriteLineColour(ConsoleColor.Red, $"Exception catched: {ex.Message}");
                    Console.WriteLine();
                }
            }
            try
            {
                workingTime.ShowPartialStatistics();
            }
            catch
            {
                Console.WriteLine();
            }

            WriteLineColour(ConsoleColor.Green, "================================================");

            while (true)
            {
                WriteLineColour(ConsoleColor.Yellow, "Type your sick leave time [hh:mm]:\n" +
                                                     "--> press 'p' to type your paid leave time\n");
                WriteLineColour(ConsoleColor.Yellow, "~~~~~~~~~~");

                var input = Console.ReadLine();

                WriteLineColour(ConsoleColor.Yellow, "~~~~~~~~~~");

                if (input == "p")
                {
                    break;
                }
                try
                {
                    sickLeaveTime.AddTime(input);
                }
                catch (Exception ex)
                {
                    WriteLineColour(ConsoleColor.Red, $"Exception catched: {ex.Message}");
                    Console.WriteLine();
                }
            }

            while (true)
            {
                WriteLineColour(ConsoleColor.Yellow, "Type your paid leave time [hh:mm]:\n" +
                                                     "--> press 'x' to get statistics\n");
                WriteLineColour(ConsoleColor.Yellow, "~~~~~~~~~~");

                var input = Console.ReadLine();

                WriteLineColour(ConsoleColor.Yellow, "~~~~~~~~~~");

                if (input == "x")
                {
                    break;
                }
                try
                {
                    paidLeaveTime.AddTime(input);
                }
                catch (Exception ex)
                {
                    WriteLineColour(ConsoleColor.Red, $"Exception catched: {ex.Message}");
                    Console.WriteLine();
                }
            }

            WriteLineColour(ConsoleColor.Cyan, "================================================");
            WriteLineColour(ConsoleColor.Cyan, "Summary");
            WriteLineColour(ConsoleColor.Cyan, "================================================");
            WriteLineColour(ConsoleColor.Cyan, "Working time statistics:");
            workingTime.ShowSummaryStatistics();
            WriteLineColour(ConsoleColor.Cyan, "Sick leave time:");
            sickLeaveTime.ShowPartialStatistics();
            WriteLineColour(ConsoleColor.Cyan, "Paid leave time:");
            paidLeaveTime.ShowPartialStatistics();
        }

        private static void WriteLineColour(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}