using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler37Test {

        [Test]
        public void TestSolve() {

            Euler37 e = new Euler37();
            Assert.AreEqual(748317.0, e.Solve());

        }

    }

}
