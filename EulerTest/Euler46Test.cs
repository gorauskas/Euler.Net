using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler46Test {

        [Test]
        public void TestSolve046() {

            Euler46 e = new Euler46();
            Assert.AreEqual(5777.0, e.Solve());

        }

    }

}
