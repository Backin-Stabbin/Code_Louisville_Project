using System;

namespace Treehouse.MediaLibrary {

    class Movie : MediaType {
        public readonly string Name;
        public readonly int Year;

        public Movie (string name, int year) : base() {
            Name = name;
            Year = year;
        }

        public string GetDisplayText(){
            string myText = Name + " " + Year + " " + Loanee + " " + OnLoan;
            return myText;
        }

    }
}