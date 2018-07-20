using System;

namespace SweetMachine
{
    public interface ICandy
    {
        decimal Price { get; }
        ICandy Charge(Action<decimal> change);
    }
}