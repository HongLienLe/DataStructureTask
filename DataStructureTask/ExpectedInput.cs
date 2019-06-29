using System;
namespace DataStructureTask
{
    public class ExpectedInput
    {
        public string command;
        public int ParameterCount;
        public bool needsIndex;
        public bool needsTimeStamp;

        public ExpectedInput(string command, int parameterCount, bool needsIndex, bool needsTimeStamp)
        {
            this.command = command;
            this.ParameterCount = parameterCount;
            this.needsIndex = needsIndex;
            this.needsTimeStamp = needsTimeStamp;
        }

    }
}
