using System;
using System.Collections.Generic;
using System.Threading;

namespace Addons
{
    internal static partial class Logs
    {
        private static int CalculateProgressPercentage(int completed, int total)
        {
            // Calcula a porcentagem de progresso
            return (int)((double)completed / total * 100);
        }

        internal static void Log(string message, Status status, int completed, int total)
        {
            int progressBarPosition = Console.WindowHeight - 2;
            int progressPercentage = CalculateProgressPercentage(completed, total);

            // Move o cursor para o topo do console para limpar as linhas
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(new string(' ', Console.WindowWidth));
            }

            Console.SetCursorPosition(0, 0);

            // Exibe o log
            Console.WriteLine($"Completed {completed} of {total} processes");
            PrintProcessMessage(message, status);

            // Atualiza a barra de progresso
            UpdateProgressBar(progressPercentage, progressBarPosition);
        }

        private static void UpdateProgressBar(int progressPercentage, int progressBarPosition)
        {
            int position = Console.CursorTop;

            const int progressBarWidth = 50; // Define o tamanho da barra de progresso

            // Normaliza o valor de progresso para a faixa de 0 a 100
            int normalizedProgress = Math.Max(0, Math.Min(100, progressPercentage));

            // Calcula quantos caracteres preencher na barra de progresso
            int filledLength = (normalizedProgress * progressBarWidth) / 100;
            int emptyLength = progressBarWidth - filledLength;

            // Move o cursor para a posição da barra de progresso
            Console.SetCursorPosition(0, progressBarPosition);

            // Escreve a barra de progresso com 50 caracteres de largura
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

            if(status == Status.Complete) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"{status.GetString()}".PadRight(100, ' '));

            if(status == Status.Failed) Console.ReadLine();
        }


        public enum Status
        {
            Complete,
            Failed
        }

        public static string GetString(this Status status)
        {
            return status switch
            {
                Status.Complete => "[ Complete ]",
                Status.Failed => "[ Failed ]",
                _ => string.Empty
            };
        }

    }
}
