/*
    This is the Progress Bar Class

    Will show a graphical display when identifying computers
*/

using System;

namespace Final_Project {

    public class ProgressBar {

        public ProgressBar progressBar { get; set; }

        // shows a progress bar
        public static void ShowProgressBar(int currentProgress, int itemTotal) {

            int barLength = itemTotal;
            int position = 1;
            float progressChunk = itemTotal - 1;

            if (barLength > 50) {
                barLength = 50;
                progressChunk = barLength - 1;
            }

            float onechunk = progressChunk / itemTotal;

            Console.CursorLeft = 0;
            Console.CursorTop = 1;
            ConsoleView.SetColors(ConsoleColor.Yellow);
            Console.Write("-");
            Console.CursorLeft = Convert.ToInt32(progressChunk) + 1;
            Console.Write("-");

            ConsoleView.SetColors(ConsoleColor.Green);
            for (int i = 0; i < onechunk * currentProgress; i++) {
                Console.CursorLeft = position++;
                Console.Write("|");
            }

            for (int i = position; i <= progressChunk; i++) {
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            Console.CursorLeft = Convert.ToInt32(progressChunk) + 4;
            ConsoleView.ResetColor();
            Console.Write((currentProgress + 1).ToString() + " of " + itemTotal.ToString());
            Console.Write(" ( ");
            ConsoleView.SetColors(ConsoleColor.Yellow);
            Console.Write(((double) (currentProgress + 1) / (double) itemTotal).ToString("P2"));
            ConsoleView.ResetColor();
            Console.Write(" ) ");
        }
    }
}
