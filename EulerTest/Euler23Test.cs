using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler23Test {

        [Test]
        public void TestSolve023() {

            Euler23 e = new Euler23();
            Assert.AreEqual(4179871.0, e.Solve());

        }

    }

}
