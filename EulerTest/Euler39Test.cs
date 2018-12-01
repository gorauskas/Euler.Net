using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {
    public class Euler39Test {

        [Test]
        public void TestSolve() {

            Euler39 e = new Euler39();
            Assert.AreEqual(840.0, e.Solve());

        }

    }
}
