using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler40Test {

        [Test]
        public void TestSolve040() {

            Euler40 e = new Euler40();
            Assert.AreEqual(210.0, e.Solve());

        }

    }

}
