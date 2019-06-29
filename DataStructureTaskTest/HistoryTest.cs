using NUnit.Framework;
using Moq;
using DataStructureTask;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Tests
{
    public class HistoryTest
    {
        History historyTest;

        [SetUp]
        public void SetUp()
        {
            historyTest = new History();
        }

        [Test]
        public void CanGetDictionary()
        {
            var historyObList = historyTest.GetHistoryOfObservationData();
            Dictionary<int, List<Observation>> expected = new Dictionary<int, List<Observation>>();

            Assert.AreEqual(expected, historyObList);
        }

        [Test]
        public void CanCreateEntryInDictionary()
        {
            string expectedData = "TEST";
            var resultData =  historyTest.Create(1, 1, "TEST");
            Assert.AreEqual(expectedData, resultData);

        }
        [Test]
        public void CanUpdateTheDictionary()
        {

            historyTest.Create(0, 10, "Test");
            var result = historyTest.Update(0, 11, "TestingUpdated");
 
            string expectedDataUpdate = "TestingUpdated";
            Assert.AreEqual(expectedDataUpdate, result);
        }

        [Test]
        public void update_id_does_not_exist_return_ERRMessage()
        {
            Assert.AreEqual(ErrMessageNoHistoryExist(0),historyTest.Update(0, 11, "TestingUpdated"));
        }

        [Test]
        public void will_update_add_another_timeStamp_observation_return_true()
        {
            historyTest.Create(0, 1, "Test");
            var expected = historyTest.Update(0, 2, "TestUpdated");
            int expectedCount = 2;
            var dic = historyTest.GetHistoryOfObservationData();
            var resultCount = dic[0].Count();
            Assert.AreEqual(expectedCount, resultCount);
        }

        [Test]
        public void will_update_existing_timeStamp_observation_return_true()
        {
            historyTest.Create(0, 1, "Test");
            var expected = historyTest.Update(0, 1, "TestUpdated");
            int expectedCount = 1;
            var dic = historyTest.GetHistoryOfObservationData();
            var resultCount = dic[0].Count();
            Assert.AreEqual(expectedCount, resultCount);
        }

        [Test]
        public void will_Delete_ListOfObservation_via_Id_return_true()
        {
            historyTest.Create(0, 1, "Test");
            historyTest.Delete(0);
            var dic = historyTest.GetHistoryOfObservationData();
            Assert.AreEqual(0, dic.Count());
        }

        [Test]
        public void cant_delete_if_history_id_does_not_exist_return_true()
        {
            Assert.AreEqual(ErrMessageNoHistoryExist(0),historyTest.Delete(0));

        }
        [Test]
        public void delete_from_given_timestamp()
        {
            historyTest.Create(0, 1, "Test1");
            historyTest.Update(0, 2, "Test2");
            historyTest.Update(0, 3, "Test3");

            var resultLast = historyTest.Delete(0, 2);
            string lastInDic = "Test2";

            Assert.AreEqual(lastInDic, resultLast);
        }
        [Test]
        public void delete_timestamp_less_than_min_timestam_then_throw_exception()
        { 
            historyTest.Create(0, 1, "Test1");
            Assert.AreEqual($"ERR There are no avaliable obseration", historyTest.Delete(0,0));
        }


        [Test]
        public void can_get_from_history_return_true()
        {
            historyTest.Create(0, 1, "Test1");
            historyTest.Update(0, 2, "Test2");
            historyTest.Update(0, 3, "Test3");

            var testResult = historyTest.Get(0, 1);

            Assert.AreEqual("Test1", testResult);
        }
        [Test]
        public void will_throw_expection_if_id_does_not_exist()
        {
            Assert.AreEqual(ErrMessageNoHistoryExist(0), historyTest.Get(0, 0));
        }
        [Test]
        public void will_throw_exception_if_timeStamp_less_than_existing_timeStamp_value()
        {
            historyTest.Create(0, 1, "Test1");

            Assert.AreEqual($"ERR There are no avaliable obseration", historyTest.Get(0, 0));

        }
        [Test]
        public void given_input_for_get_return_data_lower_bound_to_timeStamp()
        {
            historyTest.Create(0, 5, "Test1");
            historyTest.Update(0, 10, "Test2");
            historyTest.Update(0, 15, "Test3");

            var testResult = historyTest.Get(0, 7);
            Console.WriteLine(testResult);
            Assert.AreEqual("Test1", testResult);

        }

        [Test]
        public void given_input_valid_for_latest_return_string_with_timeStamp_data()
        {
            historyTest.Create(0, 5, "Test1");
            historyTest.Update(0, 10, "Test2");
            historyTest.Update(0, 15, "Test3");
            var testResult = historyTest.Latest(0);

            Assert.AreEqual("15 Test3", testResult);
        }
        [Test]
        public void call_latest_and_index_doesnt_exist_throw_exception()
        {
            Assert.AreEqual(ErrMessageNoHistoryExist(0), historyTest.Latest(0));
        }

        //[Test]
        //public void CanPrintLastElementAtIndex()
        //{
        //    History test = new History();
        //    test.Create(0, 10, "Testing");
        //    test.Update(0, 11, "TestingUpdated");


        //}
        //[Test]
        //public void CanRemovesIndexInDic()
        //{
        //    History test = new History();
        //    test.Create(0, 10, "Testing");
        //    test.Update(0, 11, "TestingUpdated");

        //    test.Delete(0);

        //    var result = test.DoesKeyExist(0);

        //    Assert.AreEqual(false, result);
        //}

        //[Test]
        //public void CanDeleteTimeStampFromListInDic()
        //{
        //    History test = new History();
        //    test.Create(0, 10, "Testing");
        //    test.Update(0, 11, "TestingUpdated");

        //    test.Delete(0, 10);

        //    var result = test.DoesKeyAndTimeExist(0, 10);

        //    Assert.AreEqual(false, result);
        //}

        //[Test]
        //public void CanPrintFromGetData()
        //{
        //    History test = new History();
        //    test.Create(0, 10, "Testing");
        //    test.Get(0, 10);
        //}
        //[Test]
        //public void CanCallLastest()
        //{
        //    History test = new History();
        //    test.Create(0, 10, "Testing");
        //    test.Update(0, 11, "TestingUpdated");
        //    test.Update(0, 12, "123");
        //    test.Latest(0);

        //}
        //[Test]
        //public void CanGetData()
        //{
        //    History test = new History();
        //    test.Create(0, 10, "10");
        //    test.Update(0, 15, "TestingUpdated");

        //    test.Get(0, 16);

        //}
        public string ErrMessageNoHistoryExist(int id)
        {
            return $"ERR A history already exists for identifier {id}";

        }
    }
}