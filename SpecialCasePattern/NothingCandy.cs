using System;

namespace SweetMachine
{
    class NothingCandy : ICandy
    {
        public decimal Price { get; } = 0;
        public ICandy Charge(Action<decimal> change) => this;
    }
}