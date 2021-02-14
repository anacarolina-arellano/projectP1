using System;

namespace projectP1
{
    class MainClass
    {
        
        public static void Main(string[] args)
        {
            Player myPlayer = new Player();
            GameScreen gs = new GameScreen(myPlayer);
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
