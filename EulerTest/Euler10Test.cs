using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler10Test {

        [Test]
        public void TestSolve() {

            Euler10 e = new Euler10();
            Assert.AreEqual(142913828922.0, e.Solve());

        }

    }

}
