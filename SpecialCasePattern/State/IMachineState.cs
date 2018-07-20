using System;
using System.Collections.Generic;
using System.Text;

namespace SweetMachine.State
{
    public interface IMachineState
    {
        bool IsWorking { get; }
        void InsertMoney(Action callback);
    }
}
