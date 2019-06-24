using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using DataStructureTask;

namespace DataStructureTaskTest
{
    public class ReadUserInputTest
    {
        ReadUserEntry _ReadUserTest;

        [SetUp]
        public void SetUp()
        {
            _ReadUserTest = new ReadUserEntry(SetUpIHistoryMock());
        }
        public void create_new_entry_in_dic_return_true()
        {
            string expectedData = "test";
            var dic = _ReadUserTest.ProcessInput("CREATE 0 0 test");
            var resultData = dic[0][1].Data;
            Assert.AreEqual(expectedData, resultData);
        }
        [Test]
        public void cant_create_new_entry_that_already_exist_return_false()
        {
            string expectedData = "test";
            var dic = _ReadUserTest.ProcessInput("CREATE 1 10 test");
            var resultData = dic[0][1].Data;
            Assert.AreEqual(expectedData, resultData);

        }
        public IHistory SetUpIHistoryMock()
        {
            Dictionary<int, List<Observation>> testDic = new Dictionary<int, List<Observation>>()
            {   {1, new List<Observation>(){new Observation(10, "test10"),
                                            new Observation(11, "test11"),
                                            new Observation(12, "test12"),
                                            new Observation(13, "test13"),}},
                {2, new List<Observation>(){new Observation(20, "test20"),
                                            new Observation(21, "test21"),
                                            new Observation(22, "test22"),
                                            new Observation(23, "test23")}}};
            var mock = new Mock<IHistory>();
            mock.Setup(x => x.GetHistoryOfObservationData()).Returns(testDic);

            return mock.Object;
        }
    }
}
