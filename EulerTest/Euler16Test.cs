using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler16Test {

        [Test]
        public void TestSolve() {

            Euler16 e = new Euler16();
            Assert.AreEqual(1366.0, e.Solve());

        }

    }

}
