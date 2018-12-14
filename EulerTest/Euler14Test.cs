using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler14Test {

        [Test]
        public void TestSolve014() {

            Euler14 e = new Euler14();
            Assert.AreEqual(837799.0, e.Solve());

        }
            
    }

}
