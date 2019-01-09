using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Euler.Solutions {
    public class Euler59 : IEuler {

        private const string SAMPLE = " the ";

        public string Problem {
            get {
                return @"
Project Euler Problem 59

    Each character on a computer is assigned a unique code and the preferred
    standard is ASCII (American Standard Code for Information Interchange). For
    example, uppercase A = 65, asterisk (*) = 42, and lowercase k = 107.

    A modern encryption method is to take a text file, convert the bytes to
    ASCII, then XOR each byte with a given value, taken from a secret key. The
    advantage with the XOR function is that using the same encryption key on
    the cipher text, restores the plain text; for example, 65 XOR 42 = 107,
    then 107 XOR 42 = 65.

    For unbreakable encryption, the key is the same length as the plain text
    message, and the key is made up of random bytes. The user would keep the
    encrypted message and the encryption key in different locations, and
    without both ""halves"", it is impossible to decrypt the message.

    Unfortunately, this method is impractical for most users, so the modified
    method is to use a password as a key. If the password is shorter than the
    message, which is likely, the key is repeated cyclically throughout the
    message.The balance for this method is using a sufficiently long password
    key for security, but short enough to be memorable.

    Your task has been made easy, as the encryption key consists of three lower
    case characters. Using cipher.txt (right click and 'Save Link/Target
    As...'), a file containing the encrypted ASCII codes, and the knowledge
    that the plain text must contain common English words, decrypt the message
    and find the sum of the ASCII values in the original text.

";
            }
        }

        public string Answer {
            get {
                return "The sum of the ASCII values in the original text is {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            var data = File.ReadAllText("Artifacts/cipher.txt").Split(',').Select(int.Parse).ToList();
            int sum = 0;

            foreach (var key in KeyGenerator()) {
                // apply all generated keys to the cipher text until we find one that 
                // generates readable plain textS
                string s = string.Concat(data.Zip(Iterate(key), (l, r) => (char)(l ^ r)));
                if (s.Contains(SAMPLE)) {
                    // Util.WL("Key: {0}".FormatWith(key));  // key = god
                    sum = s.ToList().Select(x => (int)x).Sum();
                    break;
                }
            }

            return sum;
        }

        private IEnumerable<string> KeyGenerator() {
            for (char x = 'a'; x < 'z'; x++) {
                for (char y = 'a'; y < 'z'; y++) {
                    for (char z = 'a'; z < 'z'; z++) {
                        yield return string.Concat(x, y, z);
                    }
                }
            }
        }

        private IEnumerable<T> Iterate<T>(IEnumerable<T> e) {
            while (true) {
                foreach (var i in e) {
                    yield return i;
                }
            }
        }
    }
}
