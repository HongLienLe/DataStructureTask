using System;
using System.Collections.Generic;
namespace DataStructureTask
{
    public interface IHistory
    {
        Dictionary<int, List<Observation>> GetHistoryOfObservationData();
        void Create(int id, int timeStamp, string data);
        void Update(int id, int timeStamp, string data);
        void Delete(int id);
        void Delete(int id, int timeStamp);
        void Get(int id, int timeStamp);
        void Latest(int id);
    }
}
