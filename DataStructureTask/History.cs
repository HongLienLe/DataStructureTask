using System;
using System.Linq;
using System.Collections.Generic;

namespace DataStructureTask
{
    public class History : IHistory
    {
        static Dictionary<int, List<Observation>> historyOfObservation;

        public History()
        {
            historyOfObservation = new Dictionary<int, List<Observation>>();
        }


        public Dictionary<int, List<Observation>> GetHistoryOfObservationData()
        {
            return historyOfObservation;
        }

        public void Create(int Id, int timeStamp, string data)
        {

            List<Observation> newList = new List<Observation>();
            if (!DoesKeyExist(Id))
            {
                var firstOb = new Observation(timeStamp, data);

                newList.Add(firstOb);

                historyOfObservation.Add(Id, newList);

                PrintOkData(data);
            }
            else
            {
                Console.WriteLine("ERR A history already exists for identifier '1'");
            }

        }

        public void Update(int id, int timeStamp, string data)
        {

                if (!DoesKeyAndTimeExist(id,timeStamp))
                {
                    var newob = new Observation(timeStamp, data);
                    historyOfObservation[id].Add(newob);
                  
                }
                else
                {
                Console.WriteLine("ERR TimeStamp for this index exist");
                }


            if(historyOfObservation[id].Count() > 0)
            {
                int priorId = id - 0;
                var list = historyOfObservation[priorId];
                var ob = list.Last();

                PrintOkData(ob.Data);
            }
        }

        public void Delete(int id)
        {
            if (DoesKeyExist(id))
            {

                historyOfObservation.Remove(id);
            }

        }

        public void Delete(int id, int timeStamp)
        {

                if(DoesKeyAndTimeExist(id, timeStamp))
                {
                    var findIndex = historyOfObservation[id].FindIndex(x => x.TimeStamp.Equals(timeStamp));
                int range = historyOfObservation[id].Count() - findIndex;
                

                    historyOfObservation[id].RemoveRange(findIndex, range);
                }

                if (historyOfObservation[id].Count() >= 0)
                {
                    var maxTimeStamp = historyOfObservation[id].Max(x => x.TimeStamp);

                    var ob = historyOfObservation[id].Where(x => x.TimeStamp.Equals(maxTimeStamp)).ToArray();

                Console.WriteLine($"OK {ob[0].TimeStamp} {ob[0].Data}");

            } else
                {
                Console.WriteLine("ERR There is no avaliable observations");
                }

        }

        public void Get(int id, int timeStamp)
        {
            if (DoesKeyAndTimeExist(id, timeStamp))
            {
                var i = historyOfObservation[id].FindIndex(x => x.TimeStamp.Equals(timeStamp));

                var list = historyOfObservation[id];
                var ob = list[i];

                Console.WriteLine($"GET {ob.Data}");
            } else
            {
                Console.WriteLine($"ERR No history exists for identifier '{id}'");
            }
        }

        public void Latest(int id)
        {
            if (DoesKeyExist(id))
            {
                var list = historyOfObservation[id];

                var maxTimeStamp = list.Max(x => x.TimeStamp);

                var ob = list.Where(x => x.TimeStamp.Equals(maxTimeStamp)).ToArray();

                Console.WriteLine($"OK {ob[0].TimeStamp} {ob[0].Data}");
            }
            else
            {
                Console.WriteLine($"ERR No history exists for identifier '{id}'");
            }
        }
        public bool DoesKeyExist(int index)
        {
            return historyOfObservation.ContainsKey(index);
        }

        public bool DoesTimeStampExist(List<Observation> observationlist, int timeStamp)
        {
            foreach (var ob in observationlist)
            {
                if (ob.TimeStamp.Equals(timeStamp))
                {
                    return true;
                }
            }
            return false;
        }

        public void PrintOkData(string data)
        {
            Console.WriteLine($"OK {data}");
        }

        public bool DoesKeyAndTimeExist(int id, int timeStamp)
        {
            if (DoesKeyExist(id))
            {
                if (DoesTimeStampExist(historyOfObservation[id], timeStamp))
                {
                    return true;
                }
                return false;
            }

            return false;
        }
    }
}
