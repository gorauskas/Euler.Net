using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler33Test {

        [Test]
        public void TestSolve() {

            Euler33 e = new Euler33();
            Assert.AreEqual(100.0, e.Solve());

        }

    }
}
