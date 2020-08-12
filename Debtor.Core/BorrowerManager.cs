using System.Collections.Generic;

namespace Debtor.Core
{
    public class BorrowerManager
    {
        private List<Borrower> Borrowers { get; set; }

        public void AddBorrower(string name, decimal amount)
        {
            var borrower = new Borrower
            {
                Name = name,
                CashAmount = amount
            };

            Borrowers.Add(borrower);
        }

        public void DeleteBorrower(string name)
        {
            foreach(var borrower in Borrowers)
            {
                if (borrower.Name == name)
                {
                    Borrowers.Remove(borrower);
                    return;
                }
            }
        }
        public List<string> ListBorrowers()
        {
            var borrowersListOfStrings = new List<string>();
            var indexOfBorrowersList = 1;

            foreach( var borrower in Borrowers)
            {
                var borrowerString = indexOfBorrowersList + ". " + borrower.Name + " - " + borrower.CashAmount + " PLN !";
                indexOfBorrowersList++;
                borrowersListOfStrings.Add(borrowerString);
            }


            return borrowersListOfStrings;
        }
    }
}
