using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using DataStructureTask;
using System.IO;
using System.Linq;

namespace DataStructureTaskTest
{
    public class ReadUserInputTest
    {
        ReadUserEntry _ReadUserTest;
        History _history;

        [SetUp]
        public void SetUp()
        {
             _history = new History();
            _ReadUserTest = new ReadUserEntry(_history);
        }

        [Test]
        public void FullRunThrough()
        {
            string path = "/Users/hongle/Projects/DataStructureTask/DataStructureTask/TestEntry.txt";
            var lines = File.ReadAllLines(path).ToList();

            foreach (var query in lines)
            {
                Console.WriteLine(query);
                var x = _ReadUserTest.ProcessInput(query);
                Console.WriteLine(x);
            }

        }

        [Test]
        public void given_input_valid_incorrect_format_then_return_ERRMessage()
        {
            string testIput = "UPDATE 1  4  TEST";
            var value = _ReadUserTest.ProcessInput(testIput);

            Assert.AreEqual("ERR A history already exists for identifier 1", value);
        }

        [Test]
        public void given_input_valid_in_wrong_format_return_false()
        {
            string[] array = { "1", "CREATE", "4", "TEST" };

            Assert.IsFalse(_ReadUserTest.IsValidInput(array));
        }

        [Test]
        public void given_index_valid_then_return_false()
        {
            string[] array = { "CREATE", "INVALID", "4", "TEST" };
            Assert.IsFalse(_ReadUserTest.IsIndexValid(array));
        }

        [Test]
        public void when_given_index_is_valid_return_true()
        {
            string[] array = { "UPDATE", "1", "1", "TEST" };
        
            Assert.IsTrue(_ReadUserTest.IsIndexValid(array));

        }

        [Test]
        public void when_given_timestamp_is_valid_return_true()
        {
            string[] array = { "UPDATE", "1", "1", "TEST" };

            Assert.IsTrue(_ReadUserTest.IsTimeStampValid(array));

        }

        [Test]
        public void given_invalid_index_then_return_false()
        {
            string[] array = { "UPDATE", "INVALID", "1", "TEST" };
  
            Assert.IsFalse(_ReadUserTest.IsIndexValid(array));
        }
    }
}
