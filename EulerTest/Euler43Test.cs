using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler43Test {

        [Test]
        public void TestSolve() {

            Euler43 e = new Euler43();
            Assert.AreEqual(16695334890.0, e.Solve());

        }

    }

}
