using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler30Test {

        [Test]
        public void TestSolve() {

            Euler30 e = new Euler30();
            Assert.AreEqual(443839.0, e.Solve());

        }

    }

}
