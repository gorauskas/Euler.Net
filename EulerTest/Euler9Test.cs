using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler9Test {

        [Test]
        public void TestSolve() {

            Euler9 e = new Euler9();
            Assert.AreEqual(31875000.0, e.Solve());

        }

    }

}
