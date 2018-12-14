using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler2Test {

        [Test]
        public void TestSolve002() {

            Euler2 e = new Euler2();
            Assert.AreEqual(4613732.0, e.Solve());

        }

    }

}
