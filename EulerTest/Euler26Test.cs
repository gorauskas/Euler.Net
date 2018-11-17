using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler26Test {

        [Test]
        public void TestSolve() {

            Euler26 e = new Euler26();
            Assert.AreEqual(983.0, e.Solve());

        }

    }

}
