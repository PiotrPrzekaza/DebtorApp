using Debtor.Core;
using System;

namespace Debtor
{
    public class DebtorApp
    {
        public BorrowerManager BorrowerManager { get; set; } = new BorrowerManager();
        public void IntroductionDebtor()
        {
            Console.WriteLine("Welcome to the Debtor application.The application will help you not forget who owes you money.");
        }
        public void AddBorrower()
        {
            Console.WriteLine("Give the name of your debtor: ");
            var userName = Console.ReadLine();
            Console.WriteLine("Enter the amount of debt(PLN): ");
            var userDebt = Console.ReadLine();
            var userDebtInDecimal = default(decimal);
            
            while (!decimal.TryParse(userDebt , out userDebtInDecimal))
            {
                Console.WriteLine("Incorrect amount!");
                Console.WriteLine("Enter correct amount of debt(PLN): ");
                userDebt = Console.ReadLine();
            }
            BorrowerManager.AddBorrower(userName, userDebtInDecimal);
        }
        public void DeleteBorrower()
        {
            Console.WriteLine("Enter the name of the debtor from whom you want to cancel the debt: ");
            var userName = Console.ReadLine();
            BorrowerManager.DeleteBorrower(userName);
            Console.WriteLine($"Successfully canceled the debt of a debtor named {userName}");
        }
        public void ListAllBorrower()
        {
            Console.WriteLine("Here is a list of your debtors:");
            foreach(var borrower in BorrowerManager.ListBorrowers())
            {
                Console.WriteLine(borrower);
            }
        }
        public void ChoiceYourAction()
        {

        }
    }
}
