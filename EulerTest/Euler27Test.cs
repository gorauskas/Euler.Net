using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler27Test {

        [Test]
        public void TestSolve() {

            Euler27 e = new Euler27();
            Assert.AreEqual(-59231.0, e.Solve());

        }

    }

}
