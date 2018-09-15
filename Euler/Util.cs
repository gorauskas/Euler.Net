using System;
using System.Reflection;
using Mono.Options;


namespace Euler {
    public static class Util {

        public static bool Verbose = false;
        public static string Problem = string.Empty;

        public static Action<object> W = x => Console.Write(x);
        public static Action<object> WL = x => Console.WriteLine(x);
        public static Func<string> RL = () => Console.ReadLine();
        public static Func<ConsoleKeyInfo> RK = () => Console.ReadKey();

        #region Parameters & Usage

        internal static void Version() {
            Assembly asm = Assembly.GetExecutingAssembly();
            AssemblyTitleAttribute title = (AssemblyTitleAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyTitleAttribute));
            AssemblyDescriptionAttribute description = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyDescriptionAttribute));
            AssemblyCopyrightAttribute copyright = (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyCopyrightAttribute));
            Version version = asm.GetName().Version;

            WL("{0} - Version {1}.{2}.{3}".FormatWith(title.Title, version.Major, version.Minor, version.Build));
            WL(description.Description);
            WL(copyright.Copyright);

            Environment.Exit(0);
        }

        internal static void Usage(OptionSet options) {
            WL("Project Euler problems & solutions written in CSharp");
            WL("");
            WL(" Usage: euler.exe [-p|-v|-V|-?]");
            WL("");

            options.WriteOptionDescriptions(Console.Out);

            WL("");
            WL(" Example:");
            WL("  euler.exe -p 2");
            WL("  euler.exe --problem=3 -v");

            Environment.Exit(0);
        }

        internal static void ParseOptions(string[] args) {
            bool showusage = false;
            bool showversion = false;

            var options = new OptionSet() {
                {"?|h|help", "Displays this help message and exits.", x => showusage = x != null},
                {"V", "Displays the version information and exits.", x => showversion = x != null },
                {"v", "Verbose outputs the problem statement and the solution.", x => Verbose = x != null },
                {"p|problem=", "Specify the problem/solution number you want to run.", x => Problem = x },
            };

            options.Parse(args);

            if (showversion)
                Version();

            if (showusage)
                Usage(options);
        }

        #endregion
    }
}
