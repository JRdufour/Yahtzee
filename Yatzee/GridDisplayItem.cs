using System;
namespace Yatzee {
    public enum DisplayItemType {
        title, separator, scoreItem, header
    }
    public struct GridDisplayItem {


        string name;
        string number;
        string potentialScore;
        string playerScore;
        DisplayItemType type;

        public GridDisplayItem(string header1, string header2, string header3, string header4){
            this.name = header2;
            this.number = header1;
            this.potentialScore = header3;
            this.playerScore = header4;
            this.type = DisplayItemType.header;
        }
        public GridDisplayItem(DisplayItemType type, string name, int number, string potentialScore, string playerScore){
            //used to display potential scores to the user
            this.name = name;
            this.number = number.ToString();
            this.type = type;

            this.potentialScore = potentialScore;
            this.playerScore = playerScore;
        }
        public GridDisplayItem(DisplayItemType type, string title){
            this.name = title;
            this.number = "";
            this.type = DisplayItemType.title;
            this.potentialScore = "";
            this.playerScore ="";
        }
        public GridDisplayItem(DisplayItemType type){
            this.name = "";
            this.number = "";
            this.type = type;
            this.potentialScore = "";
            this.playerScore = "";
        }
        override public string ToString() {
            switch(type){
                case DisplayItemType.separator:
                    return "--------------------------------------------------------------------";
                case DisplayItemType.header:

                case DisplayItemType.scoreItem:
                    string display = this.number;
                    var numSpaces = 5 - display.Length;
                    for (int i = 0; i < numSpaces; i++) {
                        display += " ";
                    }
                    display += $"| {name}";
                    numSpaces = 16 - name.Length;
                    for (int i = 0; i < numSpaces; i++) {
                        display += " ";
                    }
                    display += "|";
                    display += $" {potentialScore}";
                    numSpaces = 16 - potentialScore.Length;
                    for (int i = 0; i < numSpaces; i++) {
                        display += " ";
                    }
                    display += "|";
                    display += $" {playerScore}";
                    numSpaces = 10 - playerScore.Length;
                    for (int i = 0; i < numSpaces; i++) {
                        display += " ";
                    }
                    return display;
                    
                case DisplayItemType.title:
                    return $"              {this.name}";

                default: return "\n";
            }

           
        }
    }

}
