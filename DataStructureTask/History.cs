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


        public void Create(int id,long timeStamp, string data)
        {

            if (!DoesKeyExist(id))
            {

                List<Observation> newList = new List<Observation>() {
                    new Observation(timeStamp, data)
                };


                historyOfObservation.Add(id, newList);

                PrintOkData(data);
            }
            else
            {
                Console.WriteLine("ERR A history already exists for identifier '1'");
            }

        }

        public void Update(int id,long timeStamp, string data)
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

        public void Delete(int id, long timeStamp)
        {
            
            if (DoesKeyAndTimeExist(id, timeStamp) == true)
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

            }
            else
            {
                Console.WriteLine("ERR There is no avaliable observations");
            }

        }

        public void Delete(int id)
        {
            if (DoesKeyExist(id) == true)
            {
                historyOfObservation.Remove(id);
            }

        }

        public void Get(int id, long timeStamp)
        {
            if (DoesKeyExist(id))
            {
                
                var range = historyOfObservation[id].Select(x => x.TimeStamp.CompareTo(timeStamp)).ToList();

                var max = range.Max();

                var index = range.FindIndex(x => x.Equals(max));

                var list = historyOfObservation[id];
                var ob = list[index];

                Console.WriteLine($"OK {ob.Data}");


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

        public bool DoesTimeStampExist(int id, long timeStamp)
        {
            foreach (var ob in historyOfObservation[id])
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

        public bool DoesKeyAndTimeExist(int id, long timeStamp)
        {
            if (DoesKeyExist(id))
            {
                if (DoesTimeStampExist(id, timeStamp))
                {
                    return true;
                }
                return false;
            }

            return false;
        }
    }
}
