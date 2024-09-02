using System;
using System.Collections.Generic;
using System.Threading;

namespace Addons
{
    internal static partial class Logs
    {
        private static int CalculateProgressPercentage(int completed, int total) => (int)((double)completed / total * 100);

        internal static void Log(string message, Status status, int completed, int total)
        {
            Console.Clear();
            int progressBarPosition = Console.WindowHeight - 2;
            int progressPercentage = CalculateProgressPercentage(completed, total);

            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(new string(' ', Console.WindowWidth));
            }

            Console.SetCursorPosition(0, 0);

            Console.WriteLine($"Completed {completed} of {total} processes");
            PrintProcessMessage(message, status);

            // Atualiza a barra de progresso
            UpdateProgressBar(progressPercentage, progressBarPosition);
        }

        private static void UpdateProgressBar(int progressPercentage, int progressBarPosition)
        {
            int position = Console.CursorTop;

            const int progressBarWidth = 50; 

            int normalizedProgress = Math.Max(0, Math.Min(100, progressPercentage));

            int filledLength = (normalizedProgress * progressBarWidth) / 100;
            int emptyLength = progressBarWidth - filledLength;

            Console.SetCursorPosition(0, progressBarPosition);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Progress: {normalizedProgress}% ");
            
            Console.ResetColor();
            Console.Write($"[{new string('#', filledLength)}{new string('.', emptyLength)}]");

            Console.SetCursorPosition(0, position);
        }

        private static void PrintProcessMessage( string message, Status status)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(DateTime.Now.ToString("[dd/MM/yy]"));
            Console.ResetColor();
            Console.Write($" {message} - ");

            Console.ForegroundColor = (status == Status.Complete) ? ConsoleColor.Green : ConsoleColor.Red;

            Console.WriteLine($"{status.GetString()}".PadRight(100, ' '));

            if(status == Status.Failed) Console.ReadKey();
        }


        public enum Status
        {
            Complete,
            Failed
        }

        public static string GetString(this Status status) => status switch
            {
                Status.Complete => "[ Complete ]",
                Status.Failed => "[ Failed ]",
                _ => string.Empty
            };

    }
}
