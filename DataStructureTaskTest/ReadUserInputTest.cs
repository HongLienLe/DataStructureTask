using System;
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
            var mock = new Mock<IHistory>();
            _ReadUserTest = new ReadUserEntry(mock.Object);

        }

        [Test]
        public void CanReadUserInput()
        {
            string testInput = "CREATE 0 12 TESTING  ";
            var result = _ReadUserTest.ReadingStringInput(testInput);

            string[] expected = { "CREATE", "0", "12", "TESTING" };

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void CanTellWhenCommandNotValid()
        {
            string testInput = "ThrowExcpetion 0 12 TESTING";

            _ReadUserTest.ProcessInput(testInput);

        }
        [Test]
        public void CanTellIfIndexNotValid()
        {
            string[] testInput = { "CREATE", "Invalid", "12", "TESTING" };

            _ReadUserTest.IsIndexValid(testInput);
        }
        [Test]
        public void CanTellIfTimeStampInvalid()
        {
            string[] testInput = { "CREATE", "0", "Invalid", "TESTING" };

            _ReadUserTest.IsTimeStampValid(testInput);

        }

        [Test]
        public void checkIfTheValidationWorks()
        {
            string testTimeStamp = "CREATE 0 Invalid TESTING";
            string testIVCommand = "Invalid" ;
            string testIVId ="CREATE Invalid";


             _ReadUserTest.ProcessInput(testIVCommand);
            _ReadUserTest.ProcessInput(testIVId);
             _ReadUserTest.ProcessInput(testTimeStamp);


        }

        [Test]
        public void CanSetCorrectFields()
        {

        }


    }
}
