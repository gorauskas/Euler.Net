using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler47Test {

        [Test]
        public void TestSolve047() {

            Euler47 e = new Euler47();
            Assert.AreEqual(134043.0, e.Solve());

        }

    }

}
