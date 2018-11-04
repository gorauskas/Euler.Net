using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler19Test {

        [Test]
        public void TestSolve() {

            Euler19 e = new Euler19();
            Assert.AreEqual(171.0, e.Solve());

        }

    }

}
