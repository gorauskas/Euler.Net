using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler49Test {

        [Test]
        public void TestSolve049() {

            Euler49 e = new Euler49();
            Assert.AreEqual(296962999629.0, e.Solve());

        }

    }

}
