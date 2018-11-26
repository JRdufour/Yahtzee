using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading;

namespace Yatzee {
    public class ScoreCard {
        public ScoreItem Ones { get; set; } = new ScoreItem(1, Hands.Ones);
        public ScoreItem Twos { get; set; } = new ScoreItem(2, Hands.Twos);
        public ScoreItem Threes { get; set; } = new ScoreItem(3, Hands.Threes);
        public ScoreItem Fours { get; set; } = new ScoreItem(4, Hands.Fours);
        public ScoreItem Fives { get; set; } = new ScoreItem(5, Hands.Fives);
        public ScoreItem Sixes { get; set; } = new ScoreItem(6, Hands.Sixes);
        public ScoreItem ThreeOfKind { get; set; } = new ScoreItem(7, Hands.ThreeOfKind);
        public ScoreItem FourOfKind { get; set; } = new ScoreItem(8, Hands.FourOfKind);
        public ScoreItem FullHouse { get; set; } = new ScoreItem(9, Hands.FullHouse);
        public ScoreItem SmlStraight { get; set; } = new ScoreItem(10, Hands.SmlStraight);
        public ScoreItem LrgStraight { get; set; } = new ScoreItem(11, Hands.LrgStraight);
        public ScoreItem Yahtzee { get; set; } = new ScoreItem(12, Hands.Yahtzee);
        public ScoreItem Chance { get; set; } = new ScoreItem(13, Hands.Chance);

        List<ScoreItem> ScoresGroupOne = new List<ScoreItem>();
        List<ScoreItem> ScoresGroupTwo = new List<ScoreItem>();
        List<ScoreItem>[] ScoreGroups;

        public ScoreCard() {
            ScoresGroupOne.Add(Ones);
            ScoresGroupOne.Add(Twos);
            ScoresGroupOne.Add(Threes);
            ScoresGroupOne.Add(Fours);
            ScoresGroupOne.Add(Fives);
            ScoresGroupOne.Add(Sixes);
            ScoresGroupTwo.Add(ThreeOfKind);
            ScoresGroupTwo.Add(FourOfKind);
            ScoresGroupTwo.Add(FullHouse);
            ScoresGroupTwo.Add(SmlStraight);
            ScoresGroupTwo.Add(LrgStraight);
            ScoresGroupTwo.Add(Yahtzee);
            ScoresGroupTwo.Add(Chance);
            ScoreGroups = new List<ScoreItem>[]{
                ScoresGroupOne, ScoresGroupTwo
            };
        }


        public void GenerateScoreCard(int[] vals) {
            //     GridDisplayItem[] displayItems = {

            //    new GridDisplayItem(DisplayItemType.scoreItem, "Ones", 1, Evaluate(CheckSingles, this.Ones, vals, 1), Ones.ToString()),
            //    new GridDisplayItem(DisplayItemType.scoreItem, "Twos", 2, Evaluate(CheckSingles, this.Twos, vals, 2), Twos.ToString()),
            //    new GridDisplayItem(DisplayItemType.scoreItem, "Threes", 3, Evaluate(CheckSingles, this.Threes,  vals,3), Threes.ToString()),
            //    new GridDisplayItem(DisplayItemType.scoreItem, "Fours", 4, Evaluate(CheckSingles, this.Fours, vals, 4), Fours.ToString()),
            //    new GridDisplayItem(DisplayItemType.scoreItem, "Fives", 5, Evaluate(CheckSingles, this.Fives, vals, 5) , Fives.ToString()),
            //    new GridDisplayItem(DisplayItemType.scoreItem, "Sixes", 6, Evaluate(CheckSingles, this.Sixes, vals, 6), Sixes.ToString()),
            //    new GridDisplayItem(DisplayItemType.separator),
            //    new GridDisplayItem(DisplayItemType.scoreItem, "3 of a Kind", 7, new ScoreItem(CheckThreeOfKind(vals)).ToString(), ThreeOfKind.ToString()),
            //    new GridDisplayItem(DisplayItemType.scoreItem, "4 of a Kind", 8, CheckFourOfKind(vals).ToString(), FourOfKind.ToString()),
            //    new GridDisplayItem(DisplayItemType.scoreItem, "Full House", 9, CheckFullHouse(vals).ToString(), FullHouse.ToString()),
            //    new GridDisplayItem(DisplayItemType.scoreItem, "Small Straight", 10, CheckSmallStraigt(vals).ToString(), SmlStraight.ToString()),
            //    new GridDisplayItem(DisplayItemType.scoreItem, "Large Straight", 11, CheckLargeStraight(vals).ToString(), LrgStraight.ToString()),
            //    //new GridDisplayItem(DisplayItemType.scoreItem, "Yahtzee", 12, Evaluate(CheckYahtzee, vals), Yahtzee.ToString()),


            //};
            List<GridDisplayItem> displayItems = new List<GridDisplayItem>();

            displayItems.Add(new GridDisplayItem(DisplayItemType.title, "SCORE CARD"));
            displayItems.Add(new GridDisplayItem("Num", "Combo", "Potential Score", "Your score")); 
            displayItems.Add(new GridDisplayItem(DisplayItemType.separator));
            foreach (ScoreItem s in ScoresGroupOne){
                //  Console.Write($"name: {s.name}\n");
                displayItems.Add(new GridDisplayItem(DisplayItemType.scoreItem, s.name, s.gridIndex, s.GetPotentialScoreDisplay(vals), s.ToString()));
                //Console.WriteLine(new GridDisplayItem(DisplayItemType.scoreItem, s.name, s.gridIndex, s.GetPotentialScoreDisplay(vals), s.ToString()).ToString());
            }
            displayItems.Add(new GridDisplayItem(DisplayItemType.separator));
            foreach (ScoreItem s in ScoresGroupTwo) {
                //  Console.Write($"name: {s.name}\n");
                displayItems.Add(new GridDisplayItem(DisplayItemType.scoreItem, s.name, s.gridIndex, s.GetPotentialScoreDisplay(vals), s.ToString()));
                //Console.WriteLine(new GridDisplayItem(DisplayItemType.scoreItem, s.name, s.gridIndex, s.GetPotentialScoreDisplay(vals), s.ToString()).ToString());
            }
            displayItems.Add(new GridDisplayItem(DisplayItemType.separator));


            var sleepVal = 200;
                Thread.Sleep(sleepVal);
                Console.Write("Generating scores");
                Thread.Sleep(sleepVal);
                Console.Write(".");
                Thread.Sleep(sleepVal);
                Console.Write(".");
                Thread.Sleep(sleepVal);
                Console.Write(".\n");
                Thread.Sleep(sleepVal * 3);
            foreach (var i in displayItems) {
                Console.WriteLine(i.ToString());
            }


            //    Console.WriteLine($"\n          Score Card          ");
            //    Console.WriteLine($"_______________________________");
            //    Console.WriteLine($"1  | Ones         |     {  }");
            //    Console.WriteLine($"2  | Twos         |     {  }");
            //    Console.WriteLine($"3  | Threes       |     {  }");
            //    Console.WriteLine($"4  | Fours        |     {  }");
            //    Console.WriteLine($"5  | Fives        |     { } ");
            //    Console.WriteLine($"6  | Sixes        |     {  } ");
            //    Console.WriteLine($"_______________________________");
            //    Console.WriteLine($"7  | 3 of a Kind  |     {)}");
            //    Console.WriteLine($"8  | 4 of a Kind  |     {)}");
            //    //Console.WriteLine($"9  | Full House   |     {}");
            //    Console.WriteLine($"10 | Sml. Straight|     {)}");
            //    Console.WriteLine($"11 | Lrg. Straight|     {}");
            //    Console.WriteLine($"12 | Yahtzee      |     {)}");
            //    Console.WriteLine($"_______________________________");
            //}

        }
        public bool IsFull(){
            var full = true;
            foreach(var i in ScoreGroups){
                foreach(var item in i){
                    if(item.value == -1){
                        full = false;
                    }
                }
            }
            return full;
    }

        public bool ChooseScoreItem(int itemChoice, int[] vals){
            foreach(var list in ScoreGroups){
                var chosenItems = from item in list
                                  where item.gridIndex == itemChoice
                                  select item;
                foreach(var i in chosenItems){
                    if(i.value == -1){
                        i.value = i.GetPotentialScore(vals);
                        return true;
                    }
                }
                
            }
            return false;
        }

        public int CalulateTotal(){
            int total = 0;
            foreach (var list in ScoreGroups) {
                foreach(var item in list){
                    total += item.value;
                }
            }
            return total;
        }
    }

}

