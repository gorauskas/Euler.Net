using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler18Test {

        [Test]
        public void TestSolve018() {

            Euler18 e = new Euler18();
            Assert.AreEqual(1074.0, e.Solve());

        }

    }

}
