using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler22Test {

        [Test]
        public void TestSolve022() {

            Euler22 e = new Euler22();
            Assert.AreEqual(871198282.0, e.Solve());

        }

    }

}
