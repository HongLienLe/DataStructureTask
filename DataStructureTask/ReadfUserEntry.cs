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

        public string[] ReadingStringInput(string userInput)
        {
            var splitArray = userInput.ToUpper().Split(' ');
            var cleanArray = splitArray.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            return cleanArray;
        }

        public void ProcessInput(string input)
        {
            var userInput = ReadingStringInput(input);

            if (allCommands.Contains(userInput[0]) && !userInput.Count().Equals(0))
            {
                switch (userInput[0])
                {
                    case "CREATE":
                        if (IsValidInput(userInput,4))
                        {
                            SetProperties(userInput);
                            history.Create(Index, TimeStamp, Data);
                        }

                        break;
                    case "UPDATE":
                        if (IsValidInput(userInput,4))
                        {
                            SetProperties(userInput);
                            history.Update(Index, TimeStamp, Data);
                        }
                        break;
                    case "GET":
                        if (IsValidInput(userInput,3))
                        {
                            SetProperties(userInput);
                            history.Get(Index, TimeStamp);
                        }
                        break;
                    case "LATEST":
                        if (IsValidInput(userInput,2))
                        {
                            SetProperties(userInput);
                            history.Latest(Index);
                        }
                        break;
                    case "DELETE":
                        if (userInput.Count().Equals(3))
                        {
                            if (IsValidInput(userInput, 3)) { 
                            SetProperties(userInput);
                            history.Delete(Index, TimeStamp);
                        }
                        } else if (userInput.Count().Equals(2))
                        {
                            if (IsValidInput(userInput, 2))
                            {
                                SetProperties(userInput);
                                history.Delete(Index);
                            }
                        }
                        break;
                    case "QUIT":
                        Quit += 1;
                        break;
                }
            }
            else
            {
                Console.WriteLine("ERR Command is invalid.");
            }
        }

        public bool IsIndexValid(string[] userInput)
        {
            if (!int.TryParse(userInput[1], out int i))
            {
                Console.WriteLine("ERR Invalid index. Must be a int.");
            }
            return true ;
        }

        public bool IsTimeStampValid(string[] userInput)
        {
            if (!long.TryParse(userInput[2], out long i))
            {

                Console.WriteLine("ERR Invalid TimeStamp. Must be a long.");
            }
            return true;
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
        public bool IsValidInput(string[] userInput, int count)
        {
            bool val = false;

            if (count <= 2)
            {
                val = IsIndexValid(userInput) && userInput.Count().Equals(2);
            }
            else if (count > 2 && count <= 4 )
            {
                val = userInput.Count() == count && IsIndexValid(userInput) && IsTimeStampValid(userInput);
            }

            if (!val)
            {
                Console.WriteLine("ERR Invalid query format.");
            }
            return val;
        }
    }
}

