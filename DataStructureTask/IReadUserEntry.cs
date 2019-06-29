using System;
using System.Collections.Generic;

namespace DataStructureTask
{
    public interface IReadUserEntry
    {
        string ProcessInput(string userInput);
        bool Quit { get; set; }
    }
}
