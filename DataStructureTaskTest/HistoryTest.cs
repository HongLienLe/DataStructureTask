using NUnit.Framework;
using Moq;
using DataStructureTask;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace Tests
{
    public class HistoryTest
    {


        [Test]
        public void CanGetDictionary()

        {
            History test = new History();
           var historyObList = test.GetHistoryOfObservationData();
            Dictionary<int, List<Observation>> expected = new Dictionary<int, List<Observation>>();

            Assert.AreEqual(expected, historyObList);
        }

        [Test]
        public void CanCreateEntryInDictionary()
        {
            History test = new History();
            Observation expectedObservation = new Observation(10, "Testing");
            test.Create(0, 10, "Testing");

            var resultDic = test.GetHistoryOfObservationData();
            var resultValue = resultDic[0];
            var resultOb = resultValue[0];


            Assert.AreEqual(expectedObservation.TimeStamp, resultOb.TimeStamp);
        }
        [Test]
        public void CanUpdateTheDictionary()
        {
            History test = new History();
            test.Create(0, 10, "Testing");
            test.Update(0, 1, "TestingUpdated");
            var dic = test.GetHistoryOfObservationData();
            var listInDicKey0 = dic[0];
            var obIndex1 = listInDicKey0[1];
            string expectedDataUpdate = "TestingUpdated";
            Assert.AreEqual(expectedDataUpdate, obIndex1.Data);
        }

        [Test]
        public void CanPrintLastElementAtIndex()
        {
            History test = new History();
            test.Create(0, 10, "Testing");
            test.Update(0, 11, "TestingUpdated");
        }
        [Test]
        public void CanRemovesIndexInDic()
        {
            History test = new History();
            test.Create(0, 10, "Testing");
            test.Update(0, 11, "TestingUpdated");

            test.Delete(0);

            var result = test.DoesKeyExist(0);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void CanDeleteTimeStampFromListInDic()
        {
            History test = new History();
            test.Create(0, 10, "Testing");
            test.Update(0, 11, "TestingUpdated");

            test.Delete(0, 10);

            var dic = test.GetHistoryOfObservationData();


            var result = test.DoesTimeStampExist(dic[0],10);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void CanPrintFromGetData()
        {
            History test = new History();
            test.Create(0, 10, "Testing");
            test.Get(0, 10);
        }
        [Test]
        public void CanCallLastest()
        {
            History test = new History();
            test.Create(0, 10, "Testing");
            test.Update(0, 11, "TestingUpdated");
            test.Update(0, 12, "123");
            test.Latest(0);

        }
       
    }
}