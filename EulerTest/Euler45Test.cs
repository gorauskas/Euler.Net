using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler45Test {

        [Test]
        public void TestSolve045() {

            Euler45 e = new Euler45();
            Assert.AreEqual(1533776805.0, e.Solve());

        }

    }

}
