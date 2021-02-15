using System;
using System.Threading;

namespace projectP1
{
    class MainClass
    {
      //Function that allows us to interpret the received
      //number and change it into a valid class for the player
      public static char setClass(int num){
        char chosen = 'T';
        switch(num)
        {
          case 1:
            chosen = 'F'; //Class fighter
            break;
          case 2:
            chosen = 'T'; //Class thief
            break; 
          case 3:
            chosen = 'W'; //Class wizard
            break;
          default:
            break;
        }
        return chosen;
      }
        
        public static void Main(string[] args)
        {
          int keepPlaying = 1;
          while(keepPlaying == 1) {
            //Declaration of variables
            int MAX_LEVEL = 4;
            Menus myMenu = new Menus();
            int answer = 0; //asked to the player later
            string name = ""; //asked to the player later
            bool valid = false; //used for error checking

            //Print title
            myMenu.welcome();
            //Give options to play or instructions
            Console.WriteLine("Press 1 if you'd like to play or 2 to see the instructions");

            //Catch format errors
            while(!valid){
              try{
                answer = int.Parse(Console.ReadLine());
                //Answer it's only valid if the player wants
                //wants to play (1) of read the instructions (2)
                if(answer == 1 || answer == 2){
                    valid = true;
                }
                else{
                  //Any other number it's invalid
                  Console.WriteLine("You must enter 1 or 2.");
                }
              } 
              catch(FormatException){
                //inputs that are not integers are invalid
                Console.WriteLine("You must enter a number, 1 or 2.");
              }
            }
            
            //END OF PLAY/INSTRUCTIONS

            //if the player entered '2' the instructions
            //are displayed
            if(answer == 2){
              myMenu.instructions();
            }

            //ask for player's name 
            Console.WriteLine("Please enter your name.");
            valid = false;
            while(!valid){
              name = Console.ReadLine();
              //player's name can not be empty
              if(name.Length > 0){
                Console.WriteLine("Welcome {0}!", name);
                valid = true;
              }
              else{
                //ask for valid name
                Console.WriteLine("You must enter a valid name!");
              }
            }
            //ask for player's class
            valid = false;
            myMenu.chooseClass();
            //Catch errors
            while(!valid){
              try{
                answer = int.Parse(Console.ReadLine());
                //Player's class is only valid if it's 1, 2 or 3
                if(answer == 1 || answer == 2 || answer == 3){
                    valid = true;
                    Console.WriteLine("That's great!");
                }
                else{
                  //ask for valid class
                  Console.WriteLine("You must enter 1, 2 or 3.");
                }
              } 
              catch(FormatException){
                //ask for an answer that is a number 
                Console.WriteLine("You must choose a class by entering one of the available numbers.");
              }
            }
            Console.Clear();

            //Declaration of variables that are dependant
            //from previous player's answers
            char myClass = setClass(answer);
            Player myPlayer = new Player(name, myClass);
            GameScreen gs = new GameScreen(myPlayer);
            
            //game starts
            myMenu.startOfGame();
            while(true){
              //Creation of map
              gs.CreateMap(gs.CurrentLevel);
              
              //If event(Key control) is occured, new Screen is called
              if(myPlayer.PlayerStatus == 2){
                myMenu.gameOver();
                break;
              }
              gs.updateMatrix(myPlayer.PosVert, myPlayer.PosHor, myPlayer.PosVert, myPlayer.PosHor);

              bool continueFlag = true;
              while (continueFlag)
              {
                if(gs.MovePlayer() != true)   // get information from MovePlayer for next Level
                {
                  break;
                }                  
              }
              //if player has reached the last level
              if(gs.CurrentLevel == MAX_LEVEL) 
              {
                myMenu.congratulations();
                Console.ReadLine(); 
                System.Environment.Exit(0);  
              }
              gs.CurrentLevel++;    //Increment level
            }

            //Game has ended
            Console.WriteLine("Press 1 to play again or 0 to quit");
            //ask for player's answer
            valid = false;
            //Catch errors
            while(!valid){
              try{
                keepPlaying = int.Parse(Console.ReadLine());
                //Player's answerclass is only valid if it's 1 or 0
                if(keepPlaying == 1 || keepPlaying == 0){
                    valid = true;
                }
                else{
                  //ask for valid answer
                  Console.WriteLine("You must enter 1 or 0");
                }
              } 
              catch(FormatException){
                //ask for an answer that is a number 
                Console.WriteLine("You must enter a number.");
              }
            }
            //Player wants to keep playing
            if(keepPlaying == 1){
              Console.WriteLine("Great! Lets go then!");
            }
            //Player wants to quit
            else{
              Console.WriteLine("What a last, come back soon!");
            }
          }
        }
    }
}
