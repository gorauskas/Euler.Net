using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler53Test {

        [Test]
        public void TestSolve053() {

            Euler53 e = new Euler53();
            Assert.AreEqual(4075.0, e.Solve());

        }

    }

}
