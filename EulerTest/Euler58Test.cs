using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler58Test {

        [Test]
        public void TestSolve058() {

            Euler58 e = new Euler58();
            Assert.AreEqual(26241.0, e.Solve());

        }

    }

}
