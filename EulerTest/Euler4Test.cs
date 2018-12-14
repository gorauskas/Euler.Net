using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler4Test {

        [Test]
        public void TestSolve004() {

            Euler4 e = new Euler4();
            Assert.AreEqual(906609.0, e.Solve());

        }

    }

}
