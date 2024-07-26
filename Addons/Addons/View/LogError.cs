using System;
using System.Collections.Generic;
using System.Threading;

namespace Addons.View
{
    public static partial class Logs
    {
        private static int _cursorDefaultPosition = -1;
        private static int _cursorPosition = -1;
        private static int num = 10;
        private static List<string> _logs = new List<string>();
        public static bool ViewLogs = true;

        private static void UpdateCursorPosition()
        {
            _cursorPosition = Console.CursorTop;
        }

        public static void Loading(string title, string message, Status status, int currentPosition, int totalProcesses)
        {
            if (_cursorDefaultPosition == -1) _cursorDefaultPosition = Console.CursorTop;
            if (currentPosition == 0) currentPosition++;
            if (status == Status.Complete) _logs.Add(message);

            ResetCursorToDefaultPosition();

            int positionPercentage = (40 * currentPosition) / totalProcesses;
            int percentage = (positionPercentage * 100) / 40;

            PrintLoadingTitle(title);
            PrintProgressBar(positionPercentage);

            if (ViewLogs)
            {
                PrintLogs();

                if (status == Status.Running) Process(message, status);
            }

            if (currentPosition == totalProcesses && status == Status.Complete)
            {
                ResetLoading();
            }
        }

        private static void ResetCursorToDefaultPosition()
        {
            Console.CursorTop = _cursorDefaultPosition;
            Console.CursorLeft = 0;
        }

        private static void PrintLoadingTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"[ {title} ]");
            Console.ResetColor();
        }

        private static void PrintProgressBar(int positionPercentage)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new string('|', positionPercentage) + new string(' ', 40 - positionPercentage));
            Console.ResetColor();
            Console.WriteLine("]");
        }

        private static void PrintLogs()
        {
            foreach (var log in _logs)
            {
                Process(log, Status.Complete);
            }
        }

        private static void ResetLoading()
        {
            Console.CursorTop = _logs.Count + num;

            num =+ _logs.Count;

            _cursorDefaultPosition = -1;
            _cursorPosition = -1;

            if(ViewLogs) Thread.Sleep(1000);
            Console.Clear();
            _logs.Clear();
            
        }

        public static void Process(string message, Status status)
        {
            if (_cursorPosition == -1) UpdateCursorPosition();

            Console.CursorTop = _cursorPosition;
            Console.CursorLeft = 0;

            string timestamp = $"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}]";
            string statusMessage = $"{message} - {status.GetString()}";
            string output = $"{timestamp} {statusMessage}";

            if (ViewLogs)
            {
                PrintProcessMessage(timestamp, message, status);
                PrintProcessStatus(status, output.Length);
            }

            if (status == Status.Complete || status == Status.Failed)
            {
                ResetProcess();
            }
        }

        private static void PrintProcessMessage(string timestamp, string message, Status status)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(timestamp);
            Console.ResetColor();
            Console.Write($" {message} - ");
        }

        private static void PrintProcessStatus(Status status, int outputLength)
        {
            switch (status)
            {
                case Status.Running:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Status.Complete:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Status.Failed:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }

            Console.Write(status.GetString().PadRight(100 - outputLength));
            if (status == Status.Complete || status == Status.Failed) Console.WriteLine();
            Console.ResetColor();
        }

        private static void ResetProcess()
        {
            Console.CursorLeft = 0;
            _cursorPosition = -1;
        }

        public enum Status
        {
            Running,
            Complete,
            Failed
        }

        public static string GetString(this Status status)
        {
            return status switch
            {
                Status.Running => "[ Running ]",
                Status.Complete => "[ Complete ]",
                Status.Failed => "[ Failed ]",
                _ => string.Empty
            };
        }
    }
}
