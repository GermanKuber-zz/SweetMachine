using System;

namespace SweetMachine.State
{
    public class WorkingState : IMachineState
    {
        public bool IsWorking { get; } = true;

        public void InsertMoney(Action callback)
        {
            callback();
        }
    }
}