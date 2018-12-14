using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler1Test {

        [Test]
        public void TestSolve001() {

            Euler1 e = new Euler1();
            Assert.AreEqual(233168.0, e.Solve());

        }

    }

}