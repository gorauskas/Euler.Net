using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Euler.Solutions {
    public class Euler54 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 54

    In the card game poker, a hand consists of five cards and are ranked, from
    lowest to highest, in the following way:

      * High Card: Highest value card.
      * One Pair: Two cards of the same value.
      * Two Pairs: Two different pairs.
      * Three of a Kind: Three cards of the same value.
      * Straight: All cards are consecutive values.
      * Flush: All cards of the same suit.
      * Full House: Three of a kind and a pair.
      * Four of a Kind: Four cards of the same value.
      * Straight Flush: All cards are consecutive values of same suit.
      * Royal Flush: Ten, Jack, Queen, King, Ace, in same suit.

    The cards are valued in the order: 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen,
    King, Ace.

    If two players have the same ranked hands then the rank made up of the
    highest value wins; for example, a pair of eights beats a pair of fives (see
    example 1 below). But if two ranks tie, for example, both players have a
    pair of queens, then highest cards in each hand are compared (see example 4
    below); if the highest cards tie then the next highest cards are compared,
    and so on.

    Consider the following five hands dealt to two players:

    Hand  | Player 1            | Player 2            | Winner
    =============================================================
     1      5H 5C 6S 7S KD        2C 3S 8S 8D TD        Player 2
            Pair of Fives         Pair of Eights
    -------------------------------------------------------------
     2      5D 8C 9S JS AC        2C 5C 7D 8S QH        Player 1
            Highest card Ace      Highest card Queen
    -------------------------------------------------------------
     3      2D 9C AS AH AC        3D 6D 7D TD QD        Player 2
            Three Aces            Flush with Diamonds
    -------------------------------------------------------------
     4      4D 6S 9H QH QC        3D 6D 7H QD QS        Player 1
            Pair of Queens        Pair of Queens
            Highest card Nine     Highest card Seven
    -------------------------------------------------------------
     5      2H 2D 4C 4D 4S        3C 3D 3S 9S 9D        Player 1
            Full House            Full House
            With Three Fours      with Three Threes
    -------------------------------------------------------------

    The file, poker.txt, contains one-thousand random hands dealt to two
    players. Each line of the file contains ten cards (separated by a single
    space): the first five are Player 1's cards and the last five are Player 2's
    cards. You can assume that all hands are valid (no invalid characters or
    repeated cards), each player's hand is in no specific order, and in each
    hand there is a clear winner.

    How many hands does Player 1 win?

";
            }
        }

        public string Answer {
            get {
                return "Player One wins {0} hands."
                    .FormatWith(this.Solve());
            }
        }

        private Dictionary<char, int> CARDS = "23456789TJQKA".ToList().Enumerate(2).ToDictionary(k => k.Item2, v => v.Item1);

        private enum HandRank {
            HighCard      = 0,
            OnePair       = 1000000,
            TwoPair       = 2000000,
            ThreeKind     = 3000000,
            Straight      = 4000000,
            Flush         = 5000000,
            FullHouse     = 6000000,
            FourKind      = 7000000,
            StraightFlush = 8000000,
            RoyalFlush    = 9000000,
        }

        public double Solve() {
            int res = 0;

            foreach (var hands in ReadData("Artifacts/poker.txt")) {
                var p1hv = GetHandValue(hands.Substring(0, 14));
                var p2hv = GetHandValue(hands.Substring(15, 14));

                if (p1hv > p2hv) {
                    res++;
                }
            }

            return res;
        }

        /// <summary>
        /// The first part to evaluating a hand of poker is to rank it
        ///   e.g. Pair, 2 Pair, Flush, etc.
        /// A lot of the time you can determine the winning hand solely on the rank
        /// </summary>
        /// <param name="hand">string</param>
        /// <returns>value</returns>
        private HandRank GetHandRank(string hand) {
            var vals = GetValues(hand);                        // Numeric values
            var suits = GetSuits(hand);                        // Suit values
            var valsHist = Histogram(GetFaceValues(hand));     // histogram of values
            // a string representation of the values distribution for comparison
            string valsDist = valsHist.Values.ToList().ListToString();

            switch (valsHist.Count()) {
                case 5:
                    bool isf = IsFlush(suits);
                    bool iss = IsStraight(vals);

                    if (isf && iss) {
                        if (IsRoyal(vals)) {
                            return HandRank.RoyalFlush;
                        }
                        return HandRank.StraightFlush;
                    } else if (isf && !iss) {
                        return HandRank.Flush;
                    } else if (iss && !isf) {
                        return HandRank.Straight;
                    } else {
                        return HandRank.HighCard;
                    }
                case 4:
                    return HandRank.OnePair;
                case 3:
                    if (valsDist == "[2, 2, 1]") {
                        return HandRank.TwoPair;
                    } else {   //if (valsDist == "[3, 1, 1]") {
                        return HandRank.ThreeKind;
                    }
                case 2:
                    if (valsDist == "[3, 2]") {
                        return HandRank.FullHouse;
                    } else {  // if (valsDist == "[4, 1]") {
                        return HandRank.FourKind;
                    }
            }
            return HandRank.HighCard;
        }

        /// <summary>
        /// The second part to evaluating a hand of poker is to assign it a numeric value based on the rank.
        /// This is needed and 2 competing hands have the same rank
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        private int GetHandValue(string hand) {
            var vals = GetValues(hand);  // sorted descending - highest value at index 0
            HandRank rank = GetHandRank(hand);
            int val = 0;

            switch (rank) {
                // value = 14^4*highestCard + 14^3*2ndHighestCard + 14^2*3rdHighestCard + 14^1*4thHighestCard + LowestCard
                case HandRank.HighCard:
                    val = ((int)Math.Pow(14, 4) * vals[0]) +
                          ((int)Math.Pow(14, 3) * vals[1]) +
                          ((int)Math.Pow(14, 2) * vals[2]) +
                          (14 * vals[3]) +
                          vals[4];
                    break;
                // value = OnePair + 14^3*PairCard + 14^2*HighestCard + 14*MiddleCard + LowestCard
                case HandRank.OnePair:
                    if (vals[0] == vals[1]) {         // a a x y z
                        val = ((int)Math.Pow(14, 3) * vals[0]) +
                              ((int)Math.Pow(14, 2) * vals[2]) +
                              (14 * vals[3]) +
                              vals[4];
                    } else if (vals[1] == vals[2]) {  // x a a y z
                        val = ((int)Math.Pow(14, 3) * vals[1]) +
                              ((int)Math.Pow(14, 2) * vals[0]) +
                              (14 * vals[3]) +
                              vals[4];
                    } else if (vals[2] == vals[3]) {  // x y a a z
                        val = ((int)Math.Pow(14, 3) * vals[2]) +
                              ((int)Math.Pow(14, 2) * vals[0]) +
                              (14 * vals[1]) +
                              vals[4];
                    } else {                          // x y z a a
                        val = ((int)Math.Pow(14, 3) * vals[3]) +
                              ((int)Math.Pow(14, 2) * vals[0]) +
                              (14 * vals[1]) +
                              vals[2];
                    }

                    val = (int)HandRank.OnePair + val;
                    break;
                // value = TwoPair + 14*14*HighPairCard + 14*LowPairCard + UnmatchedCard
                case HandRank.TwoPair:
                    if (vals[0] == vals[1] && vals[2] == vals[3]) {          // a a b b x
                        val = ((int)Math.Pow(14, 2) * vals[0]) +
                              (14 * vals[2]) +
                              vals[4];
                    } else if (vals[0] == vals[1] && vals[3] == vals[4]) {   // a a x b b
                        val = ((int)Math.Pow(14, 2) * vals[0]) +
                              (14 * vals[3]) +
                              vals[2];
                    } else {                                                 // x a a b b
                        val = ((int)Math.Pow(14, 2) * vals[1]) +
                              (14 * vals[3]) +
                              vals[0];
                    }

                    val = (int)HandRank.TwoPair + val;
                    break;
                // value = ThreeKind + SetCardRank
                case HandRank.ThreeKind:
                    val = (int)HandRank.ThreeKind + vals[2];
                    break;
                // value = Straight + valueHighCard()
                case HandRank.Straight:
                    val = (int)HandRank.Straight + vals[0];
                    break;
                // value = Flush + valueHighCard()
                case HandRank.Flush:
                    val = (int)HandRank.Flush + vals[0];
                    break;
                // value = FullHouse + SetCardRank
                case HandRank.FullHouse:
                    val = (int)HandRank.FullHouse + vals[2];
                    break;
                // value = FourKind + 4sCardRank
                case HandRank.FourKind:
                    val = (int)HandRank.FourKind + vals[2];
                    break;
                // value = StraightFlush + valueHighCard()
                case HandRank.StraightFlush:
                    val = (int)HandRank.StraightFlush + vals[0];
                    break;
                // value = RoyalFlush + valueHighCard()
                case HandRank.RoyalFlush:
                    val = (int)HandRank.RoyalFlush + vals[0];
                    break;
            }

            return val;
        }

        /// <summary>
        /// Returns the frequency occurance of card values in a hand.
        ///   e. g. this is how we tell if there are 1 pair or 2 pairs
        ///   
        /// Histogram of face values can give us the following:
        ///   - High Card:  Count = 5  (1, 1, 1, 1, 1)
        ///   - One Pair:   Count = 4  (2, 1, 1, 1)
        ///   - Two Pair:   Count = 3  (2, 2, 1)
        ///   - 3 Kind:     Count = 3  (3, 1, 1)
        ///   - Full House: Count = 2  (3, 2)
        ///   - Four Kind:  Count = 2  (4, 1)
        ///   
        /// Histogram of suits can give us the following:
        ///   - Flush:      Count = 1  (5)
        /// </summary>
        /// <param name="vals"></param>
        /// <returns></returns>
        private Dictionary<char, int> Histogram(List<char> vals) {
            Dictionary<char, int> d = new Dictionary<char, int>();

            foreach (var item in vals) {
                if (d.ContainsKey(item)) {
                    d[item]++;
                } else {
                    d.Add(item, 1);
                }
            }

            return d.OrderByDescending(x => x.Value).ToDictionary(k => k.Key, v => v.Value);
        }

        /// <summary>
        /// A hand is a flush when the historgram of the suites in the hand map one suit with a frequency of 5
        /// and hence a single count on the dictionary
        /// </summary>
        /// <param name="handSuits"></param>
        /// <returns></returns>
        private bool IsFlush(List<char> handSuits) {
            var d = Histogram(handSuits);
            return d.Count() == 1;
        }

        /// <summary>
        /// A straight occured when the value of the highest card subtracted by the smallest card is 4
        /// but you also have to account for the Ace playing low
        /// </summary>
        /// <param name="handValues"></param>
        /// <returns></returns>
        private bool IsStraight(List<int> handValues) {
            handValues.Sort();

            // check special case
            if (handValues[4] == 14) {
                // Wheel = A five-high straight (A-2-3-4-5), with the ace playing low. 
                if (handValues[0] == 2 && handValues[1] == 3 && handValues[2] == 4 && handValues[3] == 5) {
                    return true;
                }
            }

            return handValues[4] - handValues[0] == 4;
        }

        /// <summary>
        /// The royal flush is straight flush from 10 to Ace
        /// </summary>
        /// <param name="handValues"></param>
        /// <returns></returns>
        private bool IsRoyal(List<int> handValues) {
            return (handValues[0] == 10 && handValues[1] == 11 && handValues[2] == 12 && handValues[3] == 13 && handValues[4] == 14);
        }

        /// <summary>
        /// Get the numeric values of the cards in the hand
        /// e.g.
        ///   Face  | Numeric
        /// -------------------
        ///    2    |    2
        ///    8    |    8
        ///    T    |    10
        ///    A    |    14
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        private List<int> GetValues(string hand) {
            List<int> li = new List<int>();

            foreach (var item in hand.Split(" ").Select(x => x.Substring(0, 1).ToCharArray()[0]).ToList()) {
                li.Add(CARDS[item]);
            }

            return li.OrderByDescending(x => x).ToList();
        }

        /// <summary>
        /// Get the face values of the cards in the hand
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        private List<char> GetFaceValues(string hand) {
            return hand.Split(" ").Select(x => x.Substring(0, 1).ToCharArray()[0]).ToList();
        }

        /// <summary>
        /// Get the suits in the hand
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        private List<char> GetSuits(string hand) {
            return hand.Split(" ").Select(x => x.Substring(1, 1).ToCharArray()[0]).ToList();
        }

        /// <summary>
        /// read the data from the file returning a "list" of lines
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private IEnumerable<string> ReadData(string file) {
            string line;

            using (var reader = File.OpenText(file)) {
                while ((line = reader.ReadLine()) != null) {
                    yield return line;
                }
            }
        }
    }    
}
