using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler34Test {

        [Test]
        public void TestSolve034() {

            Euler34 e = new Euler34();
            Assert.AreEqual(40730.0, e.Solve());

        }

    }
}
