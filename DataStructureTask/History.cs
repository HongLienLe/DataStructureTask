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

        public string Create(int id, long timeStamp, string data)
        { 
            if (!historyOfObservation.ContainsKey(id)) {
                
                historyOfObservation.Add(id, new List<Observation>() { new Observation(timeStamp, data) });
                return data;
            }
            return ErrMessageNoHistoryExist(id);
        }

        public string Update(int id, long timeStamp, string data)
        {
            if (!historyOfObservation.ContainsKey(id))
            {
                return ErrMessageNoHistoryExist(id);
            }
            else if (historyOfObservation.ContainsKey(id) && historyOfObservation[id].Any(x => timeStamp.Equals(x.TimeStamp)))
            {
                var index = historyOfObservation[id].FindIndex(x => timeStamp.Equals(x.TimeStamp));
                historyOfObservation[id][index].Data = data;

                return data;
            }
            else if (historyOfObservation.ContainsKey(id))
            {
                historyOfObservation[id].Add(new Observation(timeStamp, data));
                var priorData = historyOfObservation[id].Last();
                return priorData.Data;
            }
            return null;
        }

        public string Delete(int id, long timeStamp)
        {
            if (historyOfObservation.ContainsKey(id))
            {
                var currentObservarionData = Get(id, timeStamp);
                var findIndex = historyOfObservation[id].RemoveAll(x => x.TimeStamp > timeStamp);
                return currentObservarionData;
            }

            return ErrMessageNoHistoryExist(id);

        }

        public string Delete(int id)
        {
            if (historyOfObservation.ContainsKey(id))
            {
                var ob = historyOfObservation[id].OrderBy(x => x.TimeStamp).Last();
                historyOfObservation.Remove(id);
                return $"{ob.Data}";
            }

            return ErrMessageNoHistoryExist(id);


        }
        public string Get(int id, long timeStamp)
        {
            if (!historyOfObservation.ContainsKey(id))
            {
                return ErrMessageNoHistoryExist(id);
            }
            else if (timeStamp < (historyOfObservation[id].Min(x => x.TimeStamp)))
            {
                return $"ERR There are no avaliable obseration";
            }
            var difference = historyOfObservation[id].Select(x => timeStamp - x.TimeStamp).ToList();
            var minValue = difference.Where(x => x >= 0).Min();
            var i = difference.FindIndex(x => x.Equals(minValue));
            return historyOfObservation[id][i].Data;
        }

        public string Latest(int id)
        {
            if (!historyOfObservation.ContainsKey(id))
            {
                return ErrMessageNoHistoryExist(id);
            }

            var maxTimeStamp = historyOfObservation[id].Max(x => x.TimeStamp);

            var z = Get(id, maxTimeStamp);

            var latestIs = string.Join(' ', maxTimeStamp, z);

            return latestIs;

        }

        public string ErrMessageNoHistoryExist(int id)
        {
            return $"ERR A history already exists for identifier {id}";
        }
    }
}
