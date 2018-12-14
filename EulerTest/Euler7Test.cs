using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler7Test {

        [Test]
        public void TestSolve007() {

            Euler7 e = new Euler7();
            Assert.AreEqual(104743.0, e.Solve());

        }

    }

}
