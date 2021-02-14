using System;

namespace projectP1
{
    class MainClass
    {
        
        public static void Main(string[] args)
        {
            Player myPlayer = new Player();
            Menus myMenu = new Menus();
            GameScreen gs = new GameScreen(myPlayer);
            //Print title
            myMenu.welcome();
            //Give options to play or instructions
            Console.WriteLine("Press 1 if you'd like to play or 2 to see the instructions");
            //Catch format errors
            //FIXME: THIS CODE WORKS BUT IDK WHY
            //FIXME: IT PRINTS RANDOM STUFF LIKE
            //1R;1R
            bool valid = false;
            while(!valid){
              try{
                int answer = int.Parse(Console.ReadLine());
                if(answer == 0 || answer == 1){
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
            //END OF PLAY/INSTRUCTIONS
            gs.CreateMap();
            
            gs.updateMatrix(myPlayer.PosX, myPlayer.PosY, myPlayer.PosX, myPlayer.PosY);

            bool continueFlag = true;
            while (continueFlag)
            {
                gs.MovePlayer();
            }


        }
    }
}
