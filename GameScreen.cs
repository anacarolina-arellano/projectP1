using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


namespace projectP1
{
  class GameScreen
  {
    //Variables og the game screen
    const int HEIGHT = 14;
    const int WIDTH = 100;
    private Player myPlayer;
    static char[,] map = new char[HEIGHT, WIDTH];
    int currentLevel = 1;

    public int CurrentLevel
    {
      get
      {
        return currentLevel;
      }
      set
      {
        currentLevel = value;
      }
    }

    //Games screen constructor with player as parameter
    public GameScreen(Player myPlayer) 
    {
        this.myPlayer = myPlayer;
        
    }

        //Function to read the map from the text file and
        //print it on console
        public void CreateMap(int currentLevel)
        {
            // StreamReader
            string levelFile = "levels/level"  + currentLevel  + ".txt";
            StreamReader sr = new StreamReader(levelFile); // import from levelFile

            int count = 0;
            while (sr.Peek() >= 0) //There's more content in the file
            {
                char[] s = sr.ReadLine().ToCharArray();
                for (int i = 0; i < s.Length; i++)
                {
                    map[count, i] = s[i];
                }
                count++;
            }

            //Movement of enemies
            int enemyIndex = 0;
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    //Console.Write(map[i, j]);
                    if (map[i, j] == '$')
                    {
                        myPlayer.PosVert = i; myPlayer.PosHor = j;
                    }

                    //Checks for enemies in tilemap and spawns them in
                    if (map[i, j] == 'R' || map[i, j] == 'B' || map[i, j] == 'S' || map[i, j] == 'G' || map[i, j] == 'M')
                    {
                        SpawnEnemies(i, j, map[i, j], enemyIndex++);
                    }
                }
                //Console.WriteLine();
            }

            sr.Close();

        }
        public void updateMatrix(int curVert, int curHor, int nextVert, int nextHor)
        {
            //Console.WriteLine("cx= {0} cy= {1}   dx= {2} dy= {3}", curVert, curHor, nextVert, nextHor);
            if (NextFlag(nextVert, nextHor)) // if we can go, swap the position and update next position too.
            {
                SwapPosition(curVert, curHor, nextVert, nextHor);
                myPlayer.PosVert = nextVert;
                myPlayer.PosHor = nextHor;
            }

            // enemy movement
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    if(map[i, j] == 'R' || map[i, j] == 'B' || map[i, j] == 'S' || map[i, j] == 'G' || map[i, j] == 'M')        {
                        //Console.Write(map[i, j]);
                        //1. Check enemy
                        //2. if player is beside of enemy -- do not move
                        //3. If enemy - random funcion
                        //4. if We can go
                        //5. swap location
                        if (!CheckPlayer(i, j))
                        {
                            Random rand = new Random();                            
                            switch (rand.Next(1, 5))
                            {
                                case 1:
                                    if (map[i-1, j] == '*')
                                        SwapPosition(i, j, i-1, j);
                                    break;
                                case 2:
                                    if (map[i, j-1] == '*')
                                        SwapPosition(i, j, i, j-1);
                                    break;
                                case 3:
                                    if (map[i+1, j] == '*')
                                        SwapPosition(i, j, i+1, j);
                                    break;
                                case 4:
                                    if (map[i, j+1] == '*')
                                        SwapPosition(i, j, i, j+1);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }                    
                }                
            }

            // view update
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
            
        }

        //
        public bool CheckPlayer(int vert, int hor)
        {
            if (map[vert - 1, hor] == '$' || map[vert, hor - 1] == '$' || map[vert + 1, hor] == '$' || map[vert, hor + 1] == '$')
                return true;
            return false;
        }
        //movememt of the enemy
        public void SwapPosition(int curVert, int curHor, int nextVert, int nextHor)
        {
            char tmp = map[curVert, curHor];
            map[curVert, curHor] = map[nextVert, nextHor];
            map[nextVert, nextHor] = tmp;
        }
        //Reads input from keyboard

        public bool MovePlayer()
        {
            ConsoleKeyInfo _Key = Console.ReadKey();
            switch (_Key.Key)
            {
                case ConsoleKey.RightArrow: 
                    //Console.WriteLine("Right Arrow");                        
                    Console.Clear();
                    updateMatrix(myPlayer.PosVert, myPlayer.PosHor, myPlayer.PosVert, myPlayer.PosHor + 1);                    
                    break;
                case ConsoleKey.LeftArrow:
                    Console.Clear();
                    updateMatrix(myPlayer.PosVert, myPlayer.PosHor, myPlayer.PosVert, myPlayer.PosHor - 1);        
                    break;
                case ConsoleKey.UpArrow:
                    //Console.WriteLine("Up Arrow");                        
                    Console.Clear();
                    updateMatrix(myPlayer.PosVert, myPlayer.PosHor, myPlayer.PosVert - 1, myPlayer.PosHor);                    
                    break;
                case ConsoleKey.DownArrow:
                    //Console.WriteLine("Down Arrow");
                    Console.Clear();
                    updateMatrix(myPlayer.PosVert, myPlayer.PosHor, myPlayer.PosVert + 1, myPlayer.PosHor);                    
                    break;
                case ConsoleKey.Escape:
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
          }
          PrintPlayerStatus();
          // level up conditions
          if(map[myPlayer.PosVert, myPlayer.PosHor + 1] == 'E' 
          && map[myPlayer.PosVert, myPlayer.PosHor + 2] == 'N' 
          && map[myPlayer.PosVert, myPlayer.PosHor + 3] == 'D')
          {
            return false;
          } else
          {
            return true;
          }          
        }


        public bool NextFlag(int curVert, int curHor)
        {
            if (map[curVert, curHor] == '*' || map[curVert, curHor] == '+')
                return true;
            return false;
        }

        public void SpawnEnemies( int posVert, int posHor, char identifier, int id)
        {
            
        }
        
        public void DespawnEnemies(int id)
        {
            
        }

        public void PrintPlayerStatus()
        {
          Console.WriteLine("Player Class: {0}    Player Health: {1}/{2}  Score: {3}  Level {4} ", myPlayer.PlayerClass, myPlayer.CurrentHealth, myPlayer.MaxHealth, myPlayer.Score, currentLevel);
          Console.WriteLine("Player Name: {0}", myPlayer.PlayerName);
        }
    }
}