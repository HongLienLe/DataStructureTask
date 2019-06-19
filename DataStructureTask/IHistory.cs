using System;
using System.Collections.Generic;
namespace DataStructureTask
{
    public interface IHistory
    {
        Dictionary<int, List<Observation>> GetHistoryOfObservationData();
        void Create(int id,long timeStamp, string data);
        void Update(int id, long timeStamp, string data);
        void Delete(int id, long timeStamp);
        void Delete(int id);
        void Get(int id, long timeStamp);
        void Latest(int id);
    }
}
