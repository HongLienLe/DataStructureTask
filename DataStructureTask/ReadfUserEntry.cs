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
        public int Quit { get; set; } = 0;
        string[] allCommands = { "GET", "LATEST", "DELETE", "QUIT", "CREATE", "UPDATE" };

        IHistory history;

        public ReadUserEntry(IHistory history)
        {
            this.history = history;
        }


        public string[] ReadingInput(string userInput)
        {
            var splitArray = userInput.ToUpper().Split(' ');

            var removedEmptyArrays = splitArray.Where(x => !string.IsNullOrWhiteSpace(x));
            var trimmedArray = removedEmptyArrays.ToArray();

            return trimmedArray;

             
            
        }

        public void ProcessInput(string input)
        {
           var userInput = ReadingInput(input);

            if (allCommands.Contains(userInput[0]).Equals(true) && !userInput.Count().Equals(0))
            {
                switch (userInput[0])
                {
                    case "CREATE":
                        if(!isValidInput(userInput, 4).Equals(true))
                        {
                            Console.WriteLine("ERR Query is in Invalid Format");

                        } else
                        {
                            SetProperties(userInput);
                            CallCommand(Command);
                        }

                        break;
                    case "UPDATE":
                        if (!isValidInput(userInput, 4).Equals(true))
                        {
                            Console.WriteLine("ERR Query is in Invalid Format");

                        }
                        else
                        {
                            SetProperties(userInput);
                            CallCommand(Command);
                        }
                        break;
                    case "GET":
                        if (!isValidInput(userInput, 3).Equals(true))
                        {
                            Console.WriteLine("ERR Query is in Invalid Format");
                        }
                        else
                        {
                            SetProperties(userInput);
                            CallCommand(Command);
                        }
                        break;
                    case "LATEST":
                        if (!isValidInput(userInput, 2).Equals(true))
                        {
                            Console.WriteLine("ERR Query is in Invalid Format");
                        }
                        else
                        {
                            SetProperties(userInput);
                            CallCommand(Command);
                        }
                        break;
                    case "DELETE":
                        if (!isValidInput(userInput, 3).Equals(true) && !isValidInput(userInput, 2).Equals(true))
                        {
                            Console.WriteLine("ERR Query is in Invalid Format");

                        }
                        else
                        {
                            SetProperties(userInput);
                            CallCommand(Command);
                        }
                        break;
                    case "QUIT":
                        Quit += 1;
                    break;
                }
            }
            else
            {
                Console.WriteLine("ERR Command is invalid");
            }
        }

        public void CallCommand(string command)
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
                    history.Delete(Index, TimeStamp);
                    break;
                case "QUIT":
                    Quit += 1;
                    break;
            }
        }

        public bool checkIfIndexValid(string[] userInput)
        {
            if (userInput.Count() >= 2)
            {
                bool validIntForID = int.TryParse(userInput[1], out int i);

                if (validIntForID.Equals(true))
                {
                    return true;

                }
                Console.WriteLine("ERR Invalid index. Must be a int");
            }
            return false;

            
        }

        public bool checkIfTimeStampValid(string[] userInput)
        {
            if(userInput.Count() >= 3)
            {
                bool validforTimeStamp = long.TryParse(userInput[2], out long i);

                if (validforTimeStamp.Equals(true))
                {
                    return true;

                }
            }
                    Console.WriteLine("ERR Invalid TimeStamp. Must be a long");
                    return false;
        }

        public void SetProperties(string[] userInput)
        {

            int count = userInput.Count();
            switch (count)
            {
                case 1:
                    this.Command = userInput[0];
                    break;
                case 2:
                    this.Command = userInput[0];
                    Int32.TryParse(userInput[1], out int id2);
                    this.Index = id2;
                    break;
                case 3:
                    this.Command = userInput[0];
                    Int32.TryParse(userInput[1], out int id3);
                    this.Index = id3;
                    long.TryParse(userInput[2], out long timeStamp3);
                    this.TimeStamp = timeStamp3;
                    break;
                case 4:
                    this.Command = userInput[0];
                    Int32.TryParse(userInput[1], out int id4);
                    this.Index = id4;
                    long.TryParse(userInput[2], out long timeStamp4);
                    this.TimeStamp = timeStamp4;
                    this.Data = userInput[3];
                    break;
            }
        }
        public bool isValidInput(string[] userInput, int count)
        {
            if (count <= 2)
            {
                return checkIfIndexValid(userInput) && userInput.Count().Equals(2);
            }
            else
            {
                return userInput.Count() == count && checkIfIndexValid(userInput) && checkIfTimeStampValid(userInput);
            }
        }
    }
}
