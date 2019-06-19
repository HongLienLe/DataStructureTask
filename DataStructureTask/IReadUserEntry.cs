using System;
namespace DataStructureTask
{
    public interface IReadUserEntry
    {
        void ProcessInput(string input);
        string Command { get; set; }
        int Index { get; set; }
        long TimeStamp { get; set; }
        string Data { get; set; }
    }
}
