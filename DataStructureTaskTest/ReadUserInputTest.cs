using System;
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
            _ReadUserTest = new ReadUserEntry();
        }

        [Test]
        public void CanReadUserInput()
        {
            string testInput = "CREATE 0 12 TESTING  ";
            var result =  _ReadUserTest.ReadUserInput(testInput);

            string[] expected = {"CREATE", "0", "12", "TESTING"};

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void CanThrowExpectionWhenCommandNotValid()
        {
            string[] testInput = { "ThrowExcpetion", "0", "12", "TESTING" };
            Assert.Throws<Exception>(() => _ReadUserTest.CallCommand(testInput));
        }
        [Test]
        public void CanTellUserWhenCallCommandThrowsExp()
        {
            string[] testInput = { "ThrowExcpetion", "0", "12", "TESTING" };

            var ex = Assert.Throws<Exception>(() => _ReadUserTest.CallCommand(testInput));

            Assert.AreEqual("Command not valid.", ex.Message);
        }
        [Test]
        public void CanThrowExceptionIfIndexGivenNotValid()
        {
            string[] testInput = { "CREATE", "Invalid", "12", "TESTING" };

            Assert.Throws<Exception>(() => _ReadUserTest.ReturnsIndex(testInput));
        }

    }
}
