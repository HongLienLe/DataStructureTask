using System;
namespace DataStructureTask
{
    public interface IReadUserEntry
    {
        void ProcessInput(string userInput);
        string Command { get; set; }
        int Index { get; set; }
        long TimeStamp { get; set; }
        string Data { get; set; }
        int Quit { get; set; }
    }
}
