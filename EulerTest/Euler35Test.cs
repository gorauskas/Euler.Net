using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler35Test {

        [Test]
        public void TestSolve035() {

            Euler35 e = new Euler35();
            Assert.AreEqual(55.0, e.Solve());

        }

    }
}
