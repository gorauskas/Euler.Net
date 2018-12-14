using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler25Test {   

        [Test]
        public void TestSolve025() {

            Euler25 e = new Euler25();
            Assert.AreEqual(4782.0, e.Solve());

        }

    }

}
