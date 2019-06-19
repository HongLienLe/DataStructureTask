using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructureTask
{
    //Read users Input 
    public class ReadUserEntry : IReadUserEntry
    {
        public string Command { get; set; }
        public int Index { get; set; }
        public long TimeStamp { get; set; }
        public string Data { get; set; }
        string[] allCommands = { "GET", "LATEST", "DELETE", "QUIT", "CREATE", "UPDATE" };

        IHistory history;

        public ReadUserEntry(IHistory history)
        {
            this.history = history;
        }


        public string[] ProcessUserInput(string userInput)
        {
            var splitArray = userInput.ToUpper().Split(' ');

            var removedEmptyArrays = splitArray.Where(x => !string.IsNullOrWhiteSpace(x));
            var trimmedArray = removedEmptyArrays.ToArray();
            return trimmedArray;
        }

        public bool CheckIfUserInputValid(string[] userInput)
        {
            bool checkIfCommandExist = allCommands.Contains(userInput[0]);
            int checkIfQueryCount = userInput.Count() - 1;
            int[] exceptedQueryCount = { 3, 2};

            if (checkIfCommandExist.Equals(true))
            {

                if (exceptedQueryCount.Contains(checkIfQueryCount))
                {
                    bool isIndexValid = checkIfIndexValid(userInput);
                    bool isTimeStampValid = checkIfTimeStampValid(userInput);

                    if (isIndexValid == true && isTimeStampValid == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return checkIfIndexValid(userInput);
                }
            }
            else
            {
                Console.WriteLine("ERR Command is invalid");
                return false;
            }
        }

        public void ProcessInput(string input)
        {
            var userInput = ProcessUserInput(input);


            if (CheckIfUserInputValid(userInput).Equals(true))
            {
                switch (userInput.Count())
                {
                    case 4:
                        this.Command = userInput[0];
                        SetIndex(userInput);
                        SetTimeStamp(userInput);
                        SetData(userInput);
                        break;
                    case 3:
                        this.Command = userInput[0];
                        SetIndex(userInput);
                        SetTimeStamp(userInput);
                        break;
                    case 2:
                        this.Command = userInput[0];
                        SetIndex(userInput);
                        break;
                    default:
                        this.Command = userInput[0];
                        break;
                }

            }

        }

        public void ExecuteInput(string command)
        {
            switch (command)
            {
                case "CREATE":
                    history.Create(Index, TimeStamp, Data);
                    break;
                case "UPDATE":
                    history.Update(Index, TimeStamp, Data);
                    break;
                case "GET":
                    history.Get(Index, TimeStamp);
                    break;
                case "LATEST":
                    history.Latest(Index);
                    break;
                case "DELETE":
                    history.Delete(Index);

                    break;
                case "QUIT":
                    break;
            }


        }

        public bool checkIfIndexValid(string[] userInput)
        {
            bool validIntForID = int.TryParse(userInput[1], out int i);

            if (validIntForID.Equals(true))
            {
                    return true;
                
            }
 
            Console.WriteLine("ERR Invalid index. Must be a int");
            return false;
            
        }

        public bool checkIfTimeStampValid(string[] userInput)
        {

            bool validforTimeStamp = long.TryParse(userInput[2], out long i);

                if (validforTimeStamp.Equals(true))
                {
                    return true;

                }

                    Console.WriteLine("ERR Invalid TimeStamp. Must be a long");
                    return false;
        }

        public void SetIndex(string[] userInput)
        {
            Int32.TryParse(userInput[1], out int i);

            this.Index = i;           
        }

        public void SetTimeStamp(string[] userInput)
        {

            long.TryParse(userInput[2], out long timeStamp);

            this.TimeStamp = timeStamp;
        }

        public void SetData(string[] data)
        {
            this.Data = data[3];
        }

    }
}
