using System;

namespace Code_Louisville {

    public class Menu {

        static public string DisplayMenu() {
            Console.WriteLine("Would you like to show computers in all building or just one building?");
            Console.WriteLine();
            Console.WriteLine("1 - Building 1");
            Console.WriteLine("2 - Building 2");
            Console.WriteLine("3 - Building 3");
            Console.WriteLine("4 - Building 4");
            Console.WriteLine("5 - Building 5");
            Console.WriteLine("6 - Building 1");

            var result = Console.ReadLine();
            return result;
        }

    }
}
