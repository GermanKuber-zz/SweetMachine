using System;
using System.Collections.Generic;
using System.Linq;

namespace SweetMachine
{
    public class Candies : ICandies
    {
        private readonly Queue<ICandy> _candies = new Queue<ICandy>();

        public Candies(IEnumerable<ICandy> candies)
        {
            if (candies == null)
                throw new ArgumentNullException(nameof(candies));

            candies.ToList().ForEach(x => _candies.Enqueue(x));
        }

        public ICandy GiveMe(int countOfCandies = 1) => new PackOfCandies(Enumerable.Range(0, countOfCandies)
                                        .ToList()
                                        .Select(x =>
                                        {
                                            if (_candies.TryDequeue(out var candy))
                                                return candy;
                                            return new NothingCandy();
                                        })
                                        .ToList());


        public void Add(ICandy candy)
        {
            _candies.Enqueue(candy);
        }
    }
}