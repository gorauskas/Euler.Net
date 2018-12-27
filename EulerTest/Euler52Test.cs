using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler52Test {

        [Test]
        public void TestSolve052() {

            Euler52 e = new Euler52();
            Assert.AreEqual(142857.0, e.Solve());

        }

    }

}
