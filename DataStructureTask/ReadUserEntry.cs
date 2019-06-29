using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructureTask
{
    //Read users Input 
    public class ReadUserEntry : IReadUserEntry
    {
        public string userStringInput { get; set; }
        public string Command { get; set; }
        public int Index { get; set; }
        public long TimeStamp { get; set; }
        public string Data { get; set; }
        public bool Quit { get; set; }
        List<ExpectedInput> allCommands = new List<ExpectedInput>(){new ExpectedInput( "GET",3,true,true) ,new ExpectedInput("LATEST", 2,true,false), new ExpectedInput( "DELETE", 2,true,false ), new ExpectedInput( "QUIT", 1,false,false ),  new ExpectedInput( "CREATE", 4,true,true ), new ExpectedInput("UPDATE", 4,true,true ), new ExpectedInput("DELETE", 3,true,true) };
        IHistory _history;

        public ReadUserEntry(IHistory history)
        {
            _history = history ?? throw new ArgumentNullException(nameof(history));
        }

        public string ProcessInput(string input)
        {
            var userInput = ReadingStringInput(input);

            if (IsValidInput(userInput))
            {
                switch (userInput[0])
                {
                    case "CREATE":
                        return _history.Create(Index, TimeStamp, Data);
                    case "UPDATE":
                        return _history.Update(Index, TimeStamp, Data);
                    case "GET":
                        return _history.Get(Index, TimeStamp);
                    case "LATEST":
                        return _history.Latest(Index);
                    case "DELETE":
                        if (userInput.Count().Equals(3))
                        {
                            return _history.Delete(Index, TimeStamp);
                        }
                        return _history.Delete(Index);
                    case "QUIT":
                        Quit = true;
                        return null;
                }

            }

            return "ERR Invalid format";
        }

        public bool IsValidInput(string[] userInput)
        {
            var isValid = allCommands.Any(x =>
            x.command.Contains(userInput[0]) &&
            x.ParameterCount.Equals(userInput.Count()) &&
            x.needsIndex.Equals(IsIndexValid(userInput)) &&
            x.needsTimeStamp.Equals((IsTimeStampValid(userInput))));

            this.Command = userInput[0];
            if (userInput.Count().Equals(4))
            {
                Data = userInput[3];
            }

            return isValid;

        }

        public bool IsIndexValid(string[] userInput)
        {
            bool isValid = false;
            try
            {
                isValid = int.TryParse(userInput[1], out int i);
                if (isValid)
                {
                    Index = i;
                    return isValid;
                }

            }
            catch (Exception)
            {
                return isValid;

            }

            return isValid;

        }

        public bool IsTimeStampValid(string[] userInput)
        {
            bool isValid = false;
            try
            {
                isValid = long.TryParse(userInput[2], out long i);
                if (isValid)
                {
                    TimeStamp = i;
                    return isValid;
                }

            }
            catch (Exception)
            {
                return isValid;
            }

            return isValid;


        }

        private string[] ReadingStringInput(string userInput)
        {
            this.userStringInput = userInput;
            var splitArray = userInput.ToUpper().Split(' ');
            var cleanArray = splitArray.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            return cleanArray;
        }
    }
}

