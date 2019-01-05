using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler56Test {

        [Test]
        public void TestSolve056() {

            Euler56 e = new Euler56();
            Assert.AreEqual(972.0, e.Solve());

        }

    }

}
