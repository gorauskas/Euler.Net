using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler57Test {

        [Test]
        public void TestSolve057() {

            Euler57 e = new Euler57();
            Assert.AreEqual(153.0, e.Solve());

        }

    }

}
