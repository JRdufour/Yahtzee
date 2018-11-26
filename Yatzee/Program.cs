using System;

namespace Yatzee {
    class MainClass {
        public static void Main(string[] args) {
  //          Console.WriteLine("Hello World!");


            //ScoreCard s = new ScoreCard() {

            //};


            //s.GenerateScoreCard(new int[] { 3, 3, 4, 4, 3 });
            //s.GenerateScoreCard(new int[] { 3, 3, 3, 4, 3 });
            //s.GenerateScoreCard(new int[] { 3, 3, 3, 3, 3 });

            Game game = new Game();
            game.Play();


            //    Die d = new Die();
            //    for (int i = 0; i < 10; i++) {

            //        d.Roll();
            //        Console.WriteLine(d);
            //        d.Roll();
            //        Console.WriteLine(d);
            //        d.Roll();
            //        Console.WriteLine(d);
            //        d.Roll();
            //        Console.WriteLine(d);
            //    }
        }


    }
}
