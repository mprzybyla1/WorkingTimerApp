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

            var workingTime = new TimerBase("WorkingTime", "_workingTimes.txt");
            var sickLeaveTime = new TimerBase("SickLeaveTime", "_medicalLeaveTimes.txt");
            var paidLeaveTime = new TimerBase("PaidLeaveTime", "_paidLeaveTimes.txt");

            workingTime.TimeAdded += WorkerTimeAdded;
            sickLeaveTime.TimeAdded += WorkerTimeAdded;
            paidLeaveTime.TimeAdded += WorkerTimeAdded;

            static void WorkerTimeAdded(object sender, EventArgs args)
            {
                Console.WriteLine("New time added");
            }

            static void AddToCategory(ITimer timer)
            {
                WriteLineColour(ConsoleColor.Yellow, "Add time [hh:mm]");

                WriteLineColour(ConsoleColor.Yellow, "~~~~~~~~~~");

                var input = Console.ReadLine();

                WriteLineColour(ConsoleColor.Yellow, "~~~~~~~~~~");

                try
                {
                    timer.AddTime(input);
                }
                catch (Exception ex)
                {
                    WriteLineColour(ConsoleColor.Red, $"Exception catched: {ex.Message}");
                    Console.WriteLine();
                }
            }

            while (true)
            {
                WriteLineColour(ConsoleColor.Yellow, "--> Press 'w' to type your daily working time\n" +
                                                     "--> Press 's' to type your sick leave time\n" +
                                                     "--> Press 'p' to type your sick leave time\n" +
                                                     "--> Press 'x' to get statistics");

                WriteLineColour(ConsoleColor.Yellow, "\n...");

                var input = Console.ReadLine();

                if (input == "w")
                {
                    AddToCategory(workingTime);
                }
                else if (input == "s")
                {
                    AddToCategory(sickLeaveTime);
                }
                else if (input == "p")
                {
                    AddToCategory(paidLeaveTime);
                }
                else if (input == "x")
                {
                    break;
                }
                else
                {
                    WriteLineColour(ConsoleColor.Red,"Choose the right category");
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