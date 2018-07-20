namespace SweetMachine
{
    public interface ICandies
    {
        ICandy GiveMe(int countOfCandies = 1);
        void Add(ICandy candy);
    }
}