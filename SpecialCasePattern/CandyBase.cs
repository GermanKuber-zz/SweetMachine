using System;

namespace SweetMachine
{
    public abstract class CandyBase : ICandy
    {
        public abstract decimal Price { get; }

        public virtual ICandy Charge(Action<decimal> change)
        {
            change(Price);
            return this;
        }
    }
}