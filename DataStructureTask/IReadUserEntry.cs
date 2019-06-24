using System;
using System.Collections.Generic;

namespace DataStructureTask
{
    public interface IReadUserEntry
    {
        Dictionary<int, List<Observation>> ProcessInput(string userInput);
        int Quit { get; set; }
    }
}
