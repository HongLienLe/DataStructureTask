using System;
using FluentAssertions;
using System.Collections.Generic;
namespace DataStructureTask
{
    public class Observation
    {

        public long TimeStamp {get; set;}
        public string  Data { get; set; }

        public Observation(long timeStamp, string data)
        {
            this.TimeStamp = timeStamp;
            this.Data = data;
        }
    }
}
