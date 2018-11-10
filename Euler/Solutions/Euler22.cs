using System.IO;
using System.Linq;

namespace Euler.Solutions {
    public class Euler22 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 22:

    Using names.txt (right click and 'Save Link/Target As...'), a 46K text file
    containing over five-thousand first names, begin by sorting it into
    alphabetical order. Then working out the alphabetical value for each name,
    multiply this value by its alphabetical position in the list to obtain a name
    score.

    For example, when the list is sorted into alphabetical order, COLIN, which is
    worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would
    obtain a score of 938 * 53 = 49714.

    What is the total of all the name scores in the file?

";
            }
        }

        public string Answer {
            get {
                return "The total of all the name scores in the file is: {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            return File.ReadAllText("Artifacts/names.txt")
                .Split(new[] { ',' })
                .Select(name => name.Trim(new[] { '\"' }))
                .OrderBy(name => name)
                .Select((name, index) => 
                    (index + 1) * name.ToCharArray()
                                      .Select(letter => (letter - 'A') + 1)
                                      .Sum())
                .Sum();
        }
    }
}
