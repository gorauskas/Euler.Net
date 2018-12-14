using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler6Test {

        [Test]
        public void TestSolve006() {

            Euler6 e = new Euler6();
            Assert.AreEqual(25164150.0, e.Solve());

        }

    }

}
