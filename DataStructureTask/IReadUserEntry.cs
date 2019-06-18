using System;
namespace DataStructureTask
{
    public interface IReadUserEntry
    {
        void ExecuteUserInput(string input);
        string Command { get; set; }
        int Index { get; set; }
        long TimeStamp { get; set; }
        string Data { get; set; }
    }
}
