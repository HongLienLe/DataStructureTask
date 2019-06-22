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
                    var priorob = historyOfObservation[id].ElementAt(historyOfObservation[id].Count() - 2);
                    PrintOkData(priorob.Data);
                }
                else if(DoesKeyExist(id))
                {
                    var i = historyOfObservation[id].FindIndex(x => x.TimeStamp.Equals(timeStamp));
                    historyOfObservation[id][i].TimeStamp = timeStamp;

                    PrintOkData(historyOfObservation[id][i].Data);
                    historyOfObservation[id][i].Data = data;
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

             if (historyOfObservation[id].Count() == 0)
            {
                Console.WriteLine("ERR There is no avaliable observations");
            } else
            {
                var obMaxTimeStamp = historyOfObservation[id].Max(x => x.TimeStamp);
                var ob = historyOfObservation[id].Where(x => x.TimeStamp.Equals(obMaxTimeStamp)).ToArray();
                PrintOkData(ob[0].Data);

            }

        }

        public void Delete(int id)
        {
            if (DoesKeyExist(id) == true)
            {

                var obMaxTimeStamp = historyOfObservation[id].Max(x => x.TimeStamp);
                var ob = historyOfObservation[id].Where(x => x.TimeStamp.Equals(obMaxTimeStamp)).ToArray();
                PrintOkData(ob[0].Data);

                historyOfObservation.Remove(id);

            }

        }

        public void Get(int id, long timeStamp)
        {
            if (DoesKeyExist(id))
            {
                if (DoesTimeStampExist(id, timeStamp))
                {
                    var findOb = historyOfObservation[id].Where(x => x.TimeStamp.Equals(timeStamp)).ToArray();
                    PrintOkData(findOb[0].Data);
                }
                else
                {
                    var range = historyOfObservation[id].Select(x => Math.Abs(x.TimeStamp - timeStamp)).ToList();
                    var minValue = range.Min();

                    var i = range.FindIndex(x => x.Equals(minValue));

                    var oblist = historyOfObservation[id];
                    var ob = oblist[i];

                    PrintOkData(ob.Data);
                }

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
