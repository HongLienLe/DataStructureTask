using System;
using System.Linq;

namespace DataStructureTask
{
    //Read users Input 
    public class ReadUserEntry : IReadUserEntry
    {

        public string Command { get; set; }
        public int Index { get; set; }
        public int TimeStamp { get; set; }
        public string Data { get; set; }


        public ReadUserEntry SetProperties()
        {
            string[] allCommands = { "GET", "LATEST", "DELETE", "QUIT", "CREATE", "UPDATE" };
            string[] commandsThatDontRequireData = {"GET","LATEST","DELETE","QUIT" };
            string userInput = Console.ReadLine();

            ReadUserEntry userEntry = new ReadUserEntry();
           var input = ReadUserInput(userInput);
            userEntry.Command = CallCommand(input);

            if (!allCommands.Contains(userEntry.Command))
            {
                Console.WriteLine("ERR Command not valid.");
            }

            if (!userEntry.Command.Contains("QUIT"))
            {
                userEntry.Index = ReturnsIndex(input);

                if (!userEntry.Command.Contains("LATEST"))
                {
                    userEntry.TimeStamp = ReturnsTimeStamp(input);
                    if (!commandsThatDontRequireData.Contains(userEntry.Command))
                    {
                        userEntry.Data = ReturnsData(input);
                    }
                }
            }
            return userEntry;
        }


        public string[] ReadUserInput(string userInput)
        {
            var splitArray = userInput.Split();

            var removedEmptyArrays = splitArray.Where(x => !string.IsNullOrWhiteSpace(x));
            var trimmedArray = removedEmptyArrays.ToArray();
            return trimmedArray;
        }

        public string CallCommand (string[] userInput)
        {
                return userInput[0];


           
        }

        public int ReturnsIndex(string[] userInput)
        {
              
            bool canConvert = false;
            int index;

            if (userInput.Count() < 2)
            {
                canConvert = Int32.TryParse(userInput[1], out index);
                
            }else { 
                Console.WriteLine("ERR Invalid index input. Must be an int");
            }
            return 0;

        }
        

        public int ReturnsTimeStamp(string[] userInput)
        {   
            bool canConvert = false;

            canConvert = Int32.TryParse(userInput[2], out int timeStamp);

            if (canConvert.Equals(false))
            {
                Console.WriteLine("Invalid index input. Must be an int");
            }

            return timeStamp;
        }

        public string ReturnsData(string[] userInput)
        {

            return userInput[3];
        }

    }
}
