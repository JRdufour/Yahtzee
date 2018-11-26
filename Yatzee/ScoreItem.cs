using System;
using System.Linq;
namespace Yatzee {


    public class ScoreItem {
        public int value;
        public string name;
        public int gridIndex;
        private int PotentialScore { get; }
        private Hands HandType;
        private delegate int Output(int[] x);
        private readonly Output EvaluateScoreFunction;


        public ScoreItem(int index, Hands type) {
            this.value = -1;
            this.gridIndex = index;
            this.HandType = type;
            switch(type){
                case Hands.Ones:
                    this.name = "Ones";
                    this.EvaluateScoreFunction = CheckOnes;
                        break;
                case Hands.Twos:
                    this.name = "Twos";
                    this.EvaluateScoreFunction = CheckTwos;
                        break;
                case Hands.Threes:
                    this.name = "Threes";
                    this.EvaluateScoreFunction = CheckThrees;
                        break;
                case Hands.Fours:
                    this.name = "Fours";
                    this.EvaluateScoreFunction = CheckFours;
                        break;
                case Hands.Fives:
                    this.name = "Fives";
                    this.EvaluateScoreFunction = CheckFives;
                    break;
                case Hands.Sixes:
                     this.name = "Sixes";
                    this.EvaluateScoreFunction = CheckSixes;
                        break;
                case Hands.FullHouse:
                    this.name = "Full House";
                    this.EvaluateScoreFunction = CheckFullHouse;
                    break;
                case Hands.ThreeOfKind:
                    this.name = "Three of a Kind";
                    this.EvaluateScoreFunction = CheckThreeOfKind;
                    break;
                case Hands.FourOfKind:
                    this.name = "Four of a Kind";
                    this.EvaluateScoreFunction = CheckFourOfKind;
                    break;
                case Hands.LrgStraight:
                    this.name = "Large Straight";
                    this.EvaluateScoreFunction = CheckLargeStraight;
                    break;
                case Hands.SmlStraight:
                          this.name = "Small Straight";
                    this.EvaluateScoreFunction = CheckSmallStraigt;
                    break;
                case Hands.Yahtzee:
                    this.name = "Yahtzee";
                    this.EvaluateScoreFunction = CheckYahtzee;
                    break;
                case Hands.Chance:
                    this.name = "Chance";
                    this.EvaluateScoreFunction = CheckChance;
                    break;
            }
        }
        override public string ToString() {
            return this.value == -1 ? "-" : this.value.ToString();
        }

        public int GetPotentialScore(int[] vals) {
            return Evaluate(EvaluateScoreFunction, vals);
        }

        public string GetPotentialScoreDisplay(int[] vals) {
            var result = GetPotentialScore(vals);
            return this.value == -1 ? result.ToString() : "-";
        }

        //want to use a delegate to evaluate the functions and return the value or "-"
        private int Evaluate(Output f1, int[] hand) {
 
            var result = f1(hand);
            return result;

        }

        private static int CheckSingles(int[] values, int singleVal) {
            int numVals = values.Count(i => i == singleVal);
            return (numVals * singleVal);
        }
        private static int CheckOnes(int[] vals){
            return CheckSingles(vals, 1);
        }

        private static int CheckTwos(int[] vals) {
            return CheckSingles(vals, 2);
        }

        private static int CheckThrees(int[] vals) {
            return CheckSingles(vals, 3);
        }

        private static int CheckFours(int[] vals) {
            return CheckSingles(vals, 4);
        }

        private static int CheckFives(int[] vals) {
            return CheckSingles(vals, 5);
        }

        private static int CheckSixes(int[] vals) {
            return CheckSingles(vals, 6);
        }

        /*
         * Check if three of a kind is found\
         * if found, return the sum of all the numbers
         * else, return 0
         */

        /*This function takes an array of numbers and a number of values to check against
 * If a number of identical elements greater than or equal to numOfKind occurs
 * the function will return true if the specified number of same elements has been found
 * You can check for three of a kind, four of a kind, and a yahtzee with this function*/
        private static bool CheckXOfAKind(int[] vals, int x) {
            //TODO
            var xOfKindFound = false;

            var groupsOfNumbers = vals.GroupBy(val => val);
            //Console.WriteLine($"There are {groupsOfNumbers.Count()} groups");

            foreach (var group in groupsOfNumbers) {
                if (group.Count() >= x) {
                    xOfKindFound = true;
                    break;
                }

            }
            return xOfKindFound;
        }

        private int CheckThreeOfKind(int[] values) {
            //    return -1;
            return CheckXOfAKind(values, 3) ? values.Sum() : 0;
        }

        private static int CheckFourOfKind(int[] values) {
            return CheckXOfAKind(values, 4) ? values.Sum() : 0;
        }


        private static int CheckFullHouse(int[] values) {
            //TODO

            var groups = values.GroupBy(val => val);
            return CheckXOfAKind(values, 3) && !CheckXOfAKind(values, 4) && groups.Count() == 2 ? 30 : 0;
        }

        private static int CheckSmallStraigt(int[] values) {
            bool straightFound = false;
            //
            int[][] winningCombos = {
                new int[]{
                    1,2,3,4
                },
                new int[]{
                    2,3,4,5
                },
                new int[]{
                    3,4,5,6
                }

            };

            foreach (var combo in winningCombos) {
                straightFound |= IsSubset(values, combo);
            }
            return straightFound ? 30 : 0;
        }

        private static int CheckLargeStraight(int[] values) {
            bool straightFound = false;
            int[][] winningCombos = {
                new int[]{
                    1,2,3,4,5
                },
                new int[]{
                    2,3,4,5,6
                }
            };

            foreach (var combo in winningCombos) {
                straightFound |= IsSubset(values, combo);
            }
            return straightFound ? 40 : 0;
        }

        private static int CheckYahtzee(int[] values) {
            return CheckXOfAKind(values, 5) ? 50 : 0;
        }

        public int CheckChance(int[] values) {
            return values.Sum();
        }

        public static bool IsSubset(int[] bigArray, int[] subArray) {
            var isSubset = true;
            foreach (var i in subArray) {
                if (!bigArray.Contains(i)) {
                    isSubset = false;
                    break;
                }
            }
            return isSubset;
        }
    }


}
