namespace SweetMachine
{
    public class MoneyBank
    {
        public decimal Money { get; private set; }

        public MoneyBank(decimal money)
        {
            Money = money;
        }

        public void Add(decimal money) => Money += money;
        public void Subtract(decimal money) => Money -= money;

        public decimal GiveMeAll()
        {
            var tmp = Money;
            Money = 0;
            return tmp;
        }
    }
}