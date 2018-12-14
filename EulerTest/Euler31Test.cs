using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler31Test {

        [Test]
        public void TestSolve031() {

            Euler31 e = new Euler31();
            Assert.AreEqual(73682.0, e.Solve());

        }

    }

}
