using System;

namespace projectP1
{
    class MainClass
    {
      public static char setClass(int num){
        char chosen = 'T';
        switch(num)
        {
          case 1:
            chosen = 'F';
            break;
          case 2:
            chosen = 'T';
            break; 
          case 3:
            chosen = 'W';
            break;
          default:
            break;
        }
        return chosen;
      }
        
        public static void Main(string[] args)
        {
            
            Menus myMenu = new Menus();
            int answer = 0;
            //Print title
            myMenu.welcome();
            //Give options to play or instructions
            Console.WriteLine("Press 1 if you'd like to play or 2 to see the instructions");
            //Catch format errors
            bool valid = false;
            while(!valid){
              try{
                answer = int.Parse(Console.ReadLine());
                if(answer == 1 || answer == 2){
                    valid = true;
                }
                else{
                  Console.WriteLine("You must enter 1 or 2.");
                }
              } 
              catch(FormatException){
                Console.WriteLine("You must enter a number, 1 or 2.");
              }
            }
            Console.Clear();
            //END OF PLAY/INSTRUCTIONS

            if(answer == 2){
              myMenu.instructions();
            }
            valid = false;
            myMenu.chooseClass();
            while(!valid){
              try{
                answer = int.Parse(Console.ReadLine());
                if(answer == 1 || answer == 2 || answer == 3){
                    valid = true;
                }
                else{
                  Console.WriteLine("You must enter 1, 2 or 3.");
                }
              } 
              catch(FormatException){
                Console.WriteLine("You must choose a class by entering one of the available numbers.");
              }
            }
            char myClass = setClass(answer);
            Player myPlayer = new Player(myClass);
            GameScreen gs = new GameScreen(myPlayer);
            
            //Creation of map
            gs.CreateMap();
            
            //
            gs.updateMatrix(myPlayer.PosVert, myPlayer.PosHor, myPlayer.PosVert, myPlayer.PosHor);

            bool continueFlag = true;
            while (continueFlag)
            {
                gs.MovePlayer();
            }


        }
    }
}
