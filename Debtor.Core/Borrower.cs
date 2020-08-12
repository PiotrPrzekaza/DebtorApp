namespace Debtor.Core
{
    public class Borrower
    {
        public string Name { get; set; }
        public decimal CashAmount { get; set; }
        public override string ToString()
        {
            return Name + ";" + CashAmount.ToString();
        }
    }
}
