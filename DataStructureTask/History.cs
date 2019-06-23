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
                historyOfObservation.Add(id, new List<Observation>() {new Observation(timeStamp, data)});
                PrintData(data);
            }
            else
            {
                Console.WriteLine($"ERR A history already exists for identifier {id}'");
            }
        }

        public void Update(int id,long timeStamp, string data)
        {
            if (!DoesKeyAndTimeExist(id,timeStamp))
                {
                    var newob = new Observation(timeStamp, data);
                    historyOfObservation[id].Add(newob);
                    var priorob = historyOfObservation[id].ElementAt(historyOfObservation[id].Count() - 2);
                    PrintData(priorob.Data);
                }
                else if(DoesKeyExist(id))
                {
                    FindObservation(id, timeStamp).TimeStamp = timeStamp;
                    PrintData(FindObservation(id, timeStamp).Data);
                    FindObservation(id, timeStamp).Data = data;
                }
        }

        public void Delete(int id, long timeStamp)
        {
            if (DoesKeyAndTimeExist(id, timeStamp))
            {
                var findIndex = historyOfObservation[id].FindIndex(x => x.TimeStamp.Equals(timeStamp));
                int range = historyOfObservation[id].Count() - findIndex;
                historyOfObservation[id].RemoveRange(findIndex, range);
            }

             if (historyOfObservation[id].Count() == 0)
            {
                Console.WriteLine("ERR There is no avaliable observations");
            } else
            {
                var ob = FindObservation(id, MaxTimeStamp(id));
                PrintData(ob.Data);
            }
        }

        public void Delete(int id)
        {
            if (!DoesKeyExist(id))
            {
                PrintErrorMsgNoHistoryExist(id);
            } else{
                var ob = FindObservation(id, MaxTimeStamp(id));
                PrintData(ob.Data);
                historyOfObservation.Remove(id);
            }
        }

        public void Get(int id, long timeStamp)
        {
            if (!DoesKeyExist(id))
            {
                PrintErrorMsgNoHistoryExist(id);
            } else {
                var difference = historyOfObservation[id].Select(x => Math.Abs(x.TimeStamp - timeStamp)).ToList();
                var minValue = difference.Min();
                var i = difference.FindIndex(x => x.Equals(minValue));
                var ob = historyOfObservation[id][i];
                PrintData(ob.Data);
            }
        }

        public void Latest(int id)
        {
            if (!DoesKeyExist(id))
            {
                PrintErrorMsgNoHistoryExist(id);
            } else {
                var ob = FindObservation(id, MaxTimeStamp(id));
                Console.WriteLine($"OK {ob.TimeStamp} {ob.Data}");
            }
        }

        public bool DoesKeyExist(int id)
        {
            return historyOfObservation.ContainsKey(id);
        }

        public void PrintErrorMsgNoHistoryExist(int id)
        {
            Console.WriteLine($"ERR No history exists for identifier '{id}'");
        }

        public void PrintData(string data)
        {
            Console.WriteLine($"OK {data}");
        }

        public bool DoesKeyAndTimeExist(int id, long timeStamp)
        {
            return historyOfObservation[id].Any(x => x.TimeStamp.Equals(timeStamp)) && DoesKeyExist(id);
        }

        public Observation FindObservation(int id, long timeStamp)
        {
            int i = historyOfObservation[id].FindIndex(x => x.TimeStamp.Equals(timeStamp));

            return historyOfObservation[id][i];
        }

        public long MaxTimeStamp(int id)
        {
            return historyOfObservation[id].Max(x => x.TimeStamp);
        }
    }
}
