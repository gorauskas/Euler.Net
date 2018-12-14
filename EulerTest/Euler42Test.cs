using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler42Test {

        [Test]
        public void TestSolve042() {

            Euler42 e = new Euler42();
            Assert.AreEqual(162.0, e.Solve());

        }

    }

}
