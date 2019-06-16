using System;
namespace DataStructureTask
{
    public interface IReadUserEntry
    {
        ReadUserEntry SetProperties();
        string Command { get; set; }
        int Index { get; set; }
        int TimeStamp { get; set; }
        string Data { get; set; }
    }
}
