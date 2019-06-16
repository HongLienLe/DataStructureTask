using System;
using Moq;
using DataStructureTask;
using NUnit.Framework;

namespace DataStructureTaskTest
{
    public class ExecuteUserInputTest
    {

        [Test]
        public void CanCreateEntryInDictionary()
        {
            var moqUserInput = new Mock<IReadUserEntry>();

            moqUserInput.SetupSet(x => x.Index = 0);

          

        }

    }
}
