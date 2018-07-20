using System;
using System.Collections.Generic;
using System.Linq;

namespace SweetMachine
{
    class PackOfCandies : CandyBase
    {
        private readonly IEnumerable<ICandy> _candies;

        public PackOfCandies(IEnumerable<ICandy> candies)
        {
            _candies = candies;
        }

        public override decimal Price => _candies.ToList()
            .Sum(x => x.Price);

        public override ICandy Charge(Action<decimal> change)
        {
            change(Price);
            return this;
        }
    }
}