using System;

namespace Final_Project {

    public class ConsoleView {

        public static void SetColors(ConsoleColor foreground) {

            Console.ForegroundColor = foreground;
        }

        public static void ResetColor() {

            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;

        }
    }
}
