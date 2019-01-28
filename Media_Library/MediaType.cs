using System;

namespace Treehouse.MediaLibrary {

    class MediaType {
        public string Loanee = null;
        public bool OnLoan = false;

        public void Loan (string loanee) {
            Loanee = loanee;
            OnLoan = true;
        }

        public void Return () {
            Loanee = null;
            OnLoan = false;
        }
    }

}