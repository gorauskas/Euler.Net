using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler13Test {

        [Test]
        public void TestSolve() {

            Euler13 e = new Euler13();
            Assert.AreEqual(5537376230.0, e.Solve());

        }

    }

}
