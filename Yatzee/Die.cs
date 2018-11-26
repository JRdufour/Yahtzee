using System;
namespace Yatzee {
    public class Die {
        public int DieVal { get; private set; }
        private static readonly Random r = new Random();

        public Die() {
            this.Roll();

        }

        public void Roll(){
            this.DieVal = r.Next(1, 7);
            //this.DieVal = r.Next(1, 5);

        }

        override public string ToString(){
            switch (this.DieVal){
                case 1:
                    //return "⚀";
                    return "1";
                    //break;
                case 2:
                    //return "⚁";
                    return "2";
                   // break;
                case 3:
                   //return "⚂";
                    return "3";
                   // break;
                case 4:
                   // return "⚃";
                    return "4";
                   // break;
                case 5:
                   // return "⚄";
                    return "5";
                   // break;
                case 6:
                    //return "⚅";
                    return "6";
                   // break;
                default:
                    return "ERROR";

            }

        }
    }
}
