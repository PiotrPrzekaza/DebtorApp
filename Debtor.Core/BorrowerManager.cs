using System.Collections.Generic;
using System.IO;

namespace Debtor.Core
{
    public class BorrowerManager
    {
        private List<Borrower> Borrowers { get; set; }
        private string FileName { get; set; } = "borrowers.txt";
        public BorrowerManager()
        {
            Borrowers = new List<Borrower>();

            if (!File.Exists(FileName))
            {
                return;
            }

            var fileLines = File.ReadAllLines(FileName);


            foreach(var line in fileLines)
            {
                var lineItems = line.Split(';');

                if(decimal.TryParse(lineItems[1], out var debtInDecimal))
                {
                    AddBorrower(lineItems[0], debtInDecimal);
                }
            }
        }

        public void AddBorrower(string name, decimal amount, bool shouldSaveToFile = true)
        {
            var borrower = new Borrower
            {
                Name = name,
                CashAmount = amount
            };

            Borrowers.Add(borrower);

            if (shouldSaveToFile)
            {
                File.WriteAllLines(FileName, new List<string> { borrower.ToString() });
            }
        }

        public void DeleteBorrower(string name, bool shouldSaveToFile = true)
        {
            foreach(var borrower in Borrowers)
            {
                if (borrower.Name == name)
                {
                    Borrowers.Remove(borrower);
                    break;
                }
            }

            if (shouldSaveToFile)
            {
                var borrowersToSave = new List<string>();

                foreach(var borrower in Borrowers)
                {
                    borrowersToSave.Add(borrower.ToString());
                }


                File.Delete(FileName);
                File.WriteAllLines(FileName, borrowersToSave);
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
