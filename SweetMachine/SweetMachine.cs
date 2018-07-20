using System.Collections.Generic;
using SweetMachine.State;

namespace SweetMachine
{
    public class SweetMachine
    {
        private readonly ICandies _cadies;
        private IMachineState _state = new WorkingState();
        private readonly MoneyBank _moneyBank = new MoneyBank(0);
        public decimal QuantityOfMOney => _moneyBank.Money;

        public SweetMachine(IEnumerable<ICandy> candies)
        {
            _cadies = new Candies(candies);
        }
        public void InsertMoney(decimal money) =>
            _state.InsertMoney(() => _moneyBank.Add(money));

        public decimal ReturnMoney() => _moneyBank.GiveMeAll();   

        public void SimulateError() =>
            _state = new IsNotWorkingState();

        public bool IsWorking() => _state.IsWorking;

        public ICandy GiveMeCandy(int countOfCandies = 1) =>
            _cadies.GiveMe(countOfCandies)
                   .Charge(price => _moneyBank.Subtract(price));
    }
}