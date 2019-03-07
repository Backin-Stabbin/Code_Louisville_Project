using System;

namespace Code_Louisville {
    public class ProgressBar {

        public ProgressBar progressBar { get; set; }
        public static void drawTextProgressBar(int progress, int total) {

            int progressBarLength = total;
            float progressChunk = progressBarLength - 1;

            if (progressBarLength > 50) {
                progressBarLength = 50;
                progressChunk = progressBarLength - 1;
            }

            // Empty Progress Bar
            Console.CursorLeft = 0;
            Console.CursorTop = 1;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("|");
            Console.CursorLeft = Convert.ToInt32(progressChunk) + 1;
            Console.Write("|");
            Console.ResetColor();
            Console.CursorLeft = 1;
            float onechunk = progressChunk / total;

            Console.ForegroundColor = ConsoleColor.Green;

            // Progress section
            int position = 1;
            for (int i = 0; i < onechunk * progress; i++) {
                Console.CursorLeft = position++;
                Console.Write("|");
            }

            // No Progress section
            for (int i = position; i <= progressChunk; i++) {
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            // Progress count description
            Console.CursorLeft = Convert.ToInt32(progressChunk) + 4;
            Console.ResetColor();
            Console.Write((progress + 1).ToString());
            Console.Write(" of ");
            Console.Write(total.ToString());
            Console.ResetColor();
            Console.Write(" ( ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(((double) (progress + 1) / (double) total).ToString("P2"));
            Console.ResetColor();
            Console.Write(" ) ");

        }
    }
}
