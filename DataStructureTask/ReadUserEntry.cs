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
        Dictionary<string,int> allCommands = new Dictionary<string, int>{ { "GET",3 } ,{ "LATEST", 2 }, { "DELETE", 2 }, { "QUIT", 1 }, { "CREATE", 4 }, { "UPDATE", 4 } };
        IHistory _history;

        public ReadUserEntry(IHistory history)
        {
            _history = history ?? throw new ArgumentNullException(nameof(history));
        }

        public Dictionary<int,List<Observation>> ProcessInput(string input)
        {
            var userInput = ReadingStringInput(input);
            if (IsValidInput(userInput))
            {
                switch (userInput[0])
                {
                    case "CREATE":
                            _history.Create(Index, TimeStamp, Data);                           
                        break;
                    case "UPDATE":
                            _history.Update(Index, TimeStamp, Data);                        
                        break;
                    case "GET":
                            _history.Get(Index, TimeStamp);                        
                        break;
                    case "LATEST":
                            _history.Latest(Index);                        
                        break;
                    case "DELETE":
                        if (userInput.Count().Equals(3))
                        {
                             _history.Delete(Index, TimeStamp);
                        } else if (userInput.Count().Equals(2))
                        {
                             _history.Delete(Index);
                        }
                        break;
                    case "QUIT":
                        Quit += 1;
                        break;
                }
            }

            return _history.GetHistoryOfObservationData();

        }

        private bool IsValidInput(string[] userInput)
        {
            bool val = false;

            if ((allCommands.ContainsKey(userInput[0]) && allCommands[userInput[0]].Equals(userInput.Count())) || (userInput[0].Equals("DELETE") && userInput.Count().Equals(3)))
            {
                switch (userInput.Count())
                {
                    case 1:
                        val = allCommands.ContainsKey(userInput[0]);
                        break;
                    case 2:
                        val = IsIndexValid(userInput);
                        if (val)
                        {
                            this.Command = userInput[0];
                            Int32.TryParse(userInput[1], out int id4);
                            this.Index = id4;
                        }
                        break;
                    case 3:
                    case 4:
                        val = IsIndexValid(userInput) && IsTimeStampValid(userInput);
                        if (val)
                        {
                            this.Command = userInput[0];
                            Int32.TryParse(userInput[1], out int id4);
                            this.Index = id4;
                            long.TryParse(userInput[2], out long timeStamp4);
                            this.TimeStamp = timeStamp4;
                            if (userInput.Count().Equals(4))
                            {
                                this.Data = userInput[3];
                            }
                        }
                        break;
                }
            }
            if (!val) {
                Console.WriteLine("ERR Invalid query format.");
            }

            return val;
        }

        private bool IsIndexValid(string[] userInput)
        {
            if (!int.TryParse(userInput[1], out int i))
            {
                Console.WriteLine("ERR Invalid index. Must be a int.");
            }
            return true;
        }

        private bool IsTimeStampValid(string[] userInput)
        {
            if (!long.TryParse(userInput[2], out long i))
            {

                Console.WriteLine("ERR Invalid TimeStamp. Must be a long.");
            }
            return true;
        }

        private string[] ReadingStringInput(string userInput)
        {
            var splitArray = userInput.ToUpper().Split(' ');
            var cleanArray = splitArray.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            return cleanArray;
        }
    }
}

