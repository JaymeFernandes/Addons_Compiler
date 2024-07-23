using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addons.View
{
    public static partial class Logs
    {
        static int CursorPosition = -1;

        private static void UpdatePosition()
        {
            CursorPosition = Console.CursorTop;
        }

        public static void Title(string title)
        {
            string texto = $"\n[ {title} ]";

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(texto);
            Console.ResetColor();
        }

        public static void Process(string message, Status status)
        {
            if (CursorPosition == -1) CursorPosition = Console.CursorTop;

            Console.CursorTop = CursorPosition;
            Console.CursorLeft = 0;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[{DateTime.Now.ToString()}]");
            Console.ResetColor();
            Console.Write($" {message} - ");

            switch (status)
            {
                case Status.running:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Status.complete:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Status.failed:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }

            Console.Write($"{status.GetString()}".PadRight(50, ' '));

            Console.ResetColor();

            if (status == Status.complete || status == Status.failed)
            {
                Console.CursorLeft = 0;
                CursorPosition = -1;
            }
        }

        public enum Status
        {
            running,
            complete,
            failed
        }

        public static string GetString(this Status status)
        {
            switch (status)
            {
                case Status.running:
                    return "[ Running ]";
                case Status.complete:
                    return "[ Complete ]\n";
                case Status.failed:
                    return "[ Failed ]\n";
                default:
                    return "";
            }
        }
    }
}
