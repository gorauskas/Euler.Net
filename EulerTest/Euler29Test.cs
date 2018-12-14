using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler29Test {

        [Test]
        public void TestSolve029() {

            Euler29 e = new Euler29();
            Assert.AreEqual(9183.0, e.Solve());

        }

    }

}
