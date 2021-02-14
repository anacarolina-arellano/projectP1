using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


namespace projectP1
{
    class GameScreen
    {
        const int HEIGHT = 14;
        const int WIDTH = 59;
        public List<Enemy> enemiesInMap = new List<Enemy>();
        private Player myPlayer;
        static char[,] map = new char[HEIGHT, WIDTH];

        public GameScreen(Player myPlayer)
        {
            this.myPlayer = myPlayer;
        }

        public void CreateMap(/*int levelNumber*/)
        {
            // StreamReader
            string levelFile = "level" /* + levelNumber */ + ".txt";
            StreamReader sr = new StreamReader("../../levels/test.txt"); //??

            int count = 0;
            while (sr.Peek() >= 0)
            {
                char[] s = sr.ReadLine().ToCharArray();
                for (int i = 0; i < s.Length; i++)
                {
                    map[count, i] = s[i];
                }
                count++;
            }


            int enemyIndex = 0;
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    //Console.Write(map[i, j]);
                    if (map[i, j] == '$')
                    {
                        myPlayer.PosX = i; myPlayer.PosY = j;
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

        public void updateMatrix(int curX, int curY, int nextX, int nextY)
        {
            //Console.WriteLine("cx= {0} cy= {1}   dx= {2} dy= {3}", curX, curY, nextX, nextY);
            
            char tmp = map[curX, curY];
            map[curX, curY] = map[nextX, nextY];
            map[nextX, nextY] = tmp;

            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
            myPlayer.PosX = nextX;
            myPlayer.PosY = nextY;
        }

        public char getValueFromMap(int curX, int curY)
        {
            return map[curX, curY];
        }

        public void MovePlayer()
        {
            ConsoleKeyInfo _Key = Console.ReadKey();
            switch (_Key.Key)
            {
                case ConsoleKey.RightArrow:
                    //Console.WriteLine("Right Arrow");                        
                    Console.Clear();
                    if (getValueFromMap(myPlayer.PosX, myPlayer.PosY + 1) == '+' || getValueFromMap(myPlayer.PosX, myPlayer.PosY + 1) == '*')
                        updateMatrix(myPlayer.PosX, myPlayer.PosY, myPlayer.PosX, myPlayer.PosY + 1);
                    else
                        updateMatrix(myPlayer.PosX, myPlayer.PosY, myPlayer.PosX, myPlayer.PosY);
                    break;
                case ConsoleKey.LeftArrow:
                    //Console.WriteLine("Left Arrow");                        
                    Console.Clear();
                    if (getValueFromMap(myPlayer.PosX, myPlayer.PosY - 1) == '+' || getValueFromMap(myPlayer.PosX, myPlayer.PosY - 1) == '*')
                        updateMatrix(myPlayer.PosX, myPlayer.PosY, myPlayer.PosX, myPlayer.PosY - 1);
                    else
                        updateMatrix(myPlayer.PosX, myPlayer.PosY, myPlayer.PosX, myPlayer.PosY);
                    break;
                case ConsoleKey.UpArrow:
                    //Console.WriteLine("Up Arrow");                        
                    Console.Clear();
                    if (getValueFromMap(myPlayer.PosX - 1, myPlayer.PosY) == '+' || getValueFromMap(myPlayer.PosX - 1, myPlayer.PosY) == '*')
                        updateMatrix(myPlayer.PosX, myPlayer.PosY, myPlayer.PosX - 1, myPlayer.PosY);
                    else
                        updateMatrix(myPlayer.PosX, myPlayer.PosY, myPlayer.PosX, myPlayer.PosY);
                    break;
                case ConsoleKey.DownArrow:
                    //Console.WriteLine("Down Arrow");
                    Console.Clear();
                    if (getValueFromMap(myPlayer.PosX + 1, myPlayer.PosY) == '+' || getValueFromMap(myPlayer.PosX + 1, myPlayer.PosY) == '*')
                        updateMatrix(myPlayer.PosX, myPlayer.PosY, myPlayer.PosX + 1, myPlayer.PosY);
                    else
                        updateMatrix(myPlayer.PosX, myPlayer.PosY, myPlayer.PosX, myPlayer.PosY);
                    break;
                case ConsoleKey.Escape:
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        public void SpawnEnemies( int posX, int posY, char identifier, int id)
        {
            enemiesInMap.Add(new Enemy(identifier, posX, posY, id));
        }

        public void DespawnEnemies(int id)
        {
            enemiesInMap.RemoveAt(id);
        }
    }
}