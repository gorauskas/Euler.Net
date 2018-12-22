using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler48Test {

        [Test]
        public void TestSolve048() {

            Euler48 e = new Euler48();
            Assert.AreEqual(9110846700.0, e.Solve());

        }

    }

}
