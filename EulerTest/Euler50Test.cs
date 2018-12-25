using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler50Test {

        [Test]
        public void TestSolve050() {

            Euler50 e = new Euler50();
            Assert.AreEqual(997651.0, e.Solve());

        }

    }

}
