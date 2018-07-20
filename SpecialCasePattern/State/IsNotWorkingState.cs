using System;

namespace SweetMachine.State
{
    public class IsNotWorkingState : IMachineState
    {
        public bool IsWorking { get; } = false;

        public void InsertMoney(Action callback) => throw new IsNotWorkingException();
    }
}