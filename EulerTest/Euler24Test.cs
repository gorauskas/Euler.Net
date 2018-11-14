using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler24Test {

        [Test]
        public void TestSolve() {

            Euler24 e = new Euler24();
            Assert.AreEqual(2783915460.0, e.Solve());

        }

    }

}
