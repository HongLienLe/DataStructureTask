using System;
using System.Linq;
using System.Collections.Generic;

namespace DataStructureTask
{
    public class ExecuteUserInput : IExecuteUserInput
    {
        IReadUserEntry readUserEntry;
        IHistory history;

        public ExecuteUserInput(IReadUserEntry readUserEntry,IHistory history)
        {
            this.readUserEntry = readUserEntry;
            this.history = history;

        }


        public void callCommand(IReadUserEntry userEntry)
        {
            string command = userEntry.Command;
            int id = userEntry.Index;
            int timeStamp = userEntry.TimeStamp;
            string data = userEntry.Data;

            switch (command)
            {
                case "CREATE":
                    history.Create(id, timeStamp,data);
                    break;
                case "UPDATE":
                    history.Update(id, timeStamp, data);
                    break;
                case "GET":
                    history.Get(id, timeStamp);
                    break;
                case "DELETE":

                    if (timeStamp.Equals(null))
                    {
                        history.Delete(id);
                    } else
                    {
                        history.Delete(id, timeStamp);
                    }
                    break;
                case "LATEST":
                    history.Update(id, timeStamp, data);
                    break;
            }


        }

    }
}
