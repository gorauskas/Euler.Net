using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler55Test {

        [Test]
        public void TestSolve055() {

            Euler55 e = new Euler55();
            Assert.AreEqual(249.0, e.Solve());

        }

    }

}
