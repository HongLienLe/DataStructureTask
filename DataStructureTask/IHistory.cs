using System;
using System.Collections.Generic;
namespace DataStructureTask
{
    public interface IHistory
    {
        Dictionary<int, List<Observation>> GetHistoryOfObservationData();
        string Create(int id,long timeStamp, string data);
        string Update(int id, long timeStamp, string data);
        string Delete(int id, long timeStamp);
        string Delete(int id);
        string Get(int id, long timeStamp);
        string Latest(int id);
    }
}
