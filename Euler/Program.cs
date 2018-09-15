using System;
using System.Reflection;

namespace Euler {
    class Program {
        private static string EULER_CLASS = "Euler.Solutions.Euler";

        static void Main(string[] args) {

            try {

                Util.ParseOptions(args);

                Assembly asm = Assembly.LoadFrom(Assembly.GetExecutingAssembly().Location);
                var t = asm.GetType(Program.EULER_CLASS + Util.Problem, true, true);
                var obj = (IEuler)Activator.CreateInstance(t);

                if (Util.Verbose) {
                    Util.W(obj.Problem);
                }

                Util.WL(obj.Answer);

            } catch (TypeLoadException) {

                if (string.IsNullOrEmpty(Util.Problem)) {
                    Util.WL("Please provide a Project Euler problem number...");
                    Util.WL("Enter euler.exe -? for usage information");
                } else {
                    Util.WL("Unable to load and execute solution to Project Euler problem " + Util.Problem);
                }

            }
        }
    }
}
