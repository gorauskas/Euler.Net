using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler36Test {

        [Test]
        public void TestSolve036() {

            Euler36 e = new Euler36();
            Assert.AreEqual(872187.0, e.Solve());

        }

    }

}
