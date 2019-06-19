//using System;
//using NUnit.Framework;
//using DataStructureTask;

//namespace DataStructureTaskTest
//{
//    public class ReadUserInputTest
//    {
//        ReadUserEntry _ReadUserTest;

//        [SetUp]
//        public void SetUp()
//        {
//            _ReadUserTest = new ReadUserEntry();
//        }

//        [Test]
//        public void CanReadUserInput()
//        {
//            string testInput = "CREATE 0 12 TESTING  ";
//            var result = _ReadUserTest.ProcessUserInput(testInput);

//            string[] expected = { "CREATE", "0", "12", "TESTING" };

//            Assert.AreEqual(expected, result);
//        }
//        [Test]
//        public void CanTellWhenCommandNotValid()
//        {
//            string testInput = "ThrowExcpetion 0 12 TESTING";

//            _ReadUserTest.ExecuteUserInput(testInput);

//        }
//        [Test]
//        public void CanTellIfIndexNotValid()
//        {
//            string[] testInput = { "CREATE", "Invalid", "12", "TESTING" };

//            _ReadUserTest.checkIfIndexValid(testInput);
//        }
//        [Test]
//        public void CanTellIfTimeStampInvalid()
//        {
//            string[] testInput = { "CREATE", "0", "Invalid", "TESTING" };

//            _ReadUserTest.checkIfTimeStampValid(testInput);

//        }

//        [Test]
//        public void checkIfTheValidationWorks()
//        {
//            string[] testTimeStamp = { "CREATE", "0", "Invalid", "TESTING" };
//            string[] testIVCommand = {"Invalid" };
//            string[] testIVId = {"CREATE", "Invalid" };


//            bool resultCommand = _ReadUserTest.CheckIfUserInputValid(testIVCommand);
//            bool resultID = _ReadUserTest.CheckIfUserInputValid(testIVId);
//            bool resultTimeStamp = _ReadUserTest.CheckIfUserInputValid(testTimeStamp);

//            Assert.AreEqual(false, resultCommand);
//            Assert.AreEqual(false, resultID);
//            Assert.AreEqual(false, resultTimeStamp);

//        }

//        [Test]
//        public void CanSetCorrectFields()
//        {
            
//        }


//    }
//}
