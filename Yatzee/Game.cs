using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
namespace Yatzee {
    public class Game {
        private readonly List<Die> Dice;
        private ScoreCard card;

        public Game() {
            //generate new Player
           

            //generate 5 dice
            Dice = new List<Die>{
                new Die(),
                new Die(),
                new Die(),
                new Die(),
                new Die()
            };

            this.card = new ScoreCard();

        }

        public void Play(){
            //welcome player
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("***************   WELCOME TO YAHTZEE   ****************");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n");
            //play a new round for as long as the score card isnt full
            for (int i = 0; i < 13; i++) {
                PlayRound();
            }
            Console.WriteLine("Game Over!");
            card.GenerateScoreCard(new int[]{0});
            Console.WriteLine(new GridDisplayItem(DisplayItemType.separator));

            Console.WriteLine("SCORE:            " + card.CalulateTotal());
        }
        /*
         * 
         * Play Round function, plays one round of yahtztt
         */
        public void PlayRound(){
            
            RollDice();
            int numRolls = 0;
            List<int> chosenDice;
            do {
                DisplayDice();
                chosenDice = ChooseDice();
                //roll the dice not selected
                for (int i = 1; i < 6;i++){
                    if(!chosenDice.Contains(i)){
                        //Console.WriteLine(i);
                        Dice[i-1].Roll();
                    }
                }
                numRolls++;
            } while (numRolls < 3);
            DisplayDice();

            var numArray = (from die in Dice
                            select die.DieVal).ToArray();
                        

         
            card.GenerateScoreCard(numArray);
            //display potential scoreboard to user
            //ask which combination they want to use
            var valid = false;
            do {
                Console.WriteLine("Which combo do you wish to use?");
                //update their scorecard
                int.TryParse(Console.ReadLine(), out int choice);
                if(choice > 0 || choice < 13) {
                    //use linq query to find score item with corresponding index
                    valid = card.ChooseScoreItem(choice, numArray);
                    if(!valid){
                        Console.WriteLine("You chose poorly");
                    }
                }
            } while (!valid);

        }
        /**
 * 
 * Roll all the dice
 */

        public void RollDice(){
            foreach(Die d in Dice){
                
                d.Roll();
            }
        }
        /**
 * 
 * Display all the dice to the screen
 */

        public void DisplayDice(){
            Console.Write("\n\n");
            Console.Write("ROLLING DICE...");
            foreach(Die d in Dice){
                Thread.Sleep(300);
                Console.Write($"{d} ");
            }
            Console.Write("\n");
        }

        /**
 * 
 * ask the player which dice they want to keep
 */

        public List<int> ChooseDice(){
            Console.WriteLine("Choose the dice you wish to keep, separated by commas, numbered 1-5");
            Console.WriteLine("Press 0 to re-roll all");
            List<int> diceToKeep = new List<int>();
            var input = Console.ReadLine();
         //   Console.Write(input);
            //if(input.Trim() == "all" || input == "All"){
            //    diceToKeep.Add(1);
            //    diceToKeep.Add(2);
            //    diceToKeep.Add(3);
            //    diceToKeep.Add(4);
            //    diceToKeep.Add(5);
            //    return diceToKeep;
            //}
            String[] tokens = input.Split(',');

            foreach (string s in tokens) {
                if (int.TryParse(s, out int i) && i < 7 && i > -1) {
                    diceToKeep.Add(i);
                } else {
                    Console.WriteLine("Invalid input, try again");
                    diceToKeep.Clear();
                    ChooseDice();
                }
            }
            if(diceToKeep[0] == 0){
                return new List<int> {0};
            }
            return diceToKeep;
        }
    }
}
