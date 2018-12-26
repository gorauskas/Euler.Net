using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler51Test {

        [Test]
        public void TestSolve051() {

            Euler51 e = new Euler51();
            Assert.AreEqual(121313.0, e.Solve());

        }

    }

}
