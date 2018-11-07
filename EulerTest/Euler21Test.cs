using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler21Test {

        [Test]
        public void TestSolve() {

            Euler21 e = new Euler21();
            Assert.AreEqual(31626.0, e.Solve());

        }

    }

}
