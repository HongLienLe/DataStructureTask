using System;
using System.Collections.Generic;

namespace DataStructureTask
{
    public interface IObservation
    {
        Observation MakeObservation(int TimeStamp, string Data);


    }
}
