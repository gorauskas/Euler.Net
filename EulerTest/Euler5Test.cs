using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler5Test {

        [Test]
        public void TestSolve() {

            Euler5 e = new Euler5();
            Assert.AreEqual(232792560.0, e.Solve());

        }

    }

}
