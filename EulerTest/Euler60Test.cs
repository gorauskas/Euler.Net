using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler60Test {

        [Test]
        public void TestSolve060() {

            Euler60 e = new Euler60();
            Assert.AreEqual(26033.0, e.Solve());

        }

    }

}
