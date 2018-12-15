using NUnit.Framework;

using Euler.Solutions;

namespace Euler.Tests {

    public class Euler44Test {

        [Test]
        public void TestSolve044() {

            Euler44 e = new Euler44();
            Assert.AreEqual(5482660.0, e.Solve());

        }

    }

}
