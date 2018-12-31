using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler54Test {

        [Test]
        public void TestSolve054() {

            Euler54 e = new Euler54();
            Assert.AreEqual(376.0, e.Solve());

        }

    }

}
