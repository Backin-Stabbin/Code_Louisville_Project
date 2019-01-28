using System;

namespace Treehouse.MediaLibrary {
    class Program {
        static void Main () {
            Movie myMovie = new Movie ("LoTR", 2001);
            Music myMusic = new Music ("Disturbed", "Evolution");

            Console.WriteLine (myMovie.GetDisplayText ());
            myMovie.Loan ("Darran");
            Console.WriteLine (myMovie.GetDisplayText ());
            myMovie.Return();
            Console.WriteLine (myMovie.GetDisplayText ());
        }
    }
}