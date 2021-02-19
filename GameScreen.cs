/*
José Ignacio Ferrer / Daiyong Kim / Ana Carolina Arellano
GameScreen.cs
Final Project
Intro to Programming in C#
February 16, 2021
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace projectP1
{
    class GameScreen
    {
        //Variables og the game screen
        const int HEIGHT = 20;
        const int WIDTH = 100;
        private Player myPlayer;
        private List<Enemy> enemies = new List<Enemy>();
        static char[,] map = new char[HEIGHT, WIDTH];
        int currentLevel = 1;

        //Sets the current level to the received value
        //Returns the current level
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

        //Stores all of the currently existing enemies in a list
        public List<Enemy> Enemies
        {
            get
            {
                return enemies;
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
            //Clears enemy list for future levels
            enemies.Clear();

            // StreamReader
            string levelFile = "../../levels/level" + currentLevel + ".txt";
            StreamReader sr = new StreamReader(levelFile); // import from levelFile

            int count = 0;
            while (sr.Peek() >= 0) //There's more content in the file
            {
                char[] s = sr.ReadLine().ToCharArray(); // readline
                for (int i = 0; i < s.Length; i++)
                {
                    map[count, i] = s[i]; // update map
                }
                count++;
            }

            //Movement of enemies
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
                        SpawnEnemies(i, j, map[i, j]);
                    }
                }
                //Console.WriteLine();
            }

            sr.Close();

        }

        //Updates the maps matrix every time there is a change
        public void updateMatrix(int curVert, int curHor, int nextVert, int nextHor)
        {
            //Console.WriteLine("cx= {0} cy= {1}   dx= {2} dy= {3}", curVert, curHor, nextVert, nextHor);
            if (NextFlag(nextVert, nextHor)) // if we can go, swap the position and update next position too.
            {
                SwapPosition(curVert, curHor, nextVert, nextHor);
                myPlayer.PosVert = nextVert;
                myPlayer.PosHor = nextHor;
            }
            int count = 0;

            // enemy movement
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    if (map[i, j] == 'R' || map[i, j] == 'B' || map[i, j] == 'S' || map[i, j] == 'G' || map[i, j] == 'M')
                    {
                        //Console.Write(map[i, j]);
                        //1. Check enemy
                        //2. if player is beside of enemy -- do not move
                        //3. If enemy - random funcion
                        //4. if We can go
                        //5. swap location
                        foreach (Enemy movingEnemy in enemies)
                        {
                            if (!CheckPlayer(i, j) && movingEnemy.PosVert == i && movingEnemy.PosHor == j && !movingEnemy.AlreadyMoved)
                            {
                                Random rand = new Random();
                                //Flags that the enemy has already moved
                                movingEnemy.AlreadyMoved = true;
                                switch (((rand.Next(1, 5) + count++) % 4) + 1)
                                {
                                    //Enemy move up
                                    case 1:
                                        if (map[i - 1, j] == '*')
                                        {
                                            movingEnemy.PosVert = i - 1;
                                            movingEnemy.PosHor = j;
                                            SwapPosition(i, j, i - 1, j);
                                        }

                                        break;
                                    case 2:
                                        if (map[i, j - 1] == '*')
                                        {
                                            movingEnemy.PosVert = i;
                                            movingEnemy.PosHor = j - 1;
                                            SwapPosition(i, j, i, j - 1);
                                        }

                                        break;
                                    case 3:
                                        if (map[i + 1, j] == '*')
                                        {
                                            movingEnemy.PosVert = i + 1;
                                            movingEnemy.PosHor = j;
                                            SwapPosition(i, j, i + 1, j);
                                        }
                                        break;
                                    case 4:
                                        if (map[i, j + 1] == '*')
                                        {
                                            movingEnemy.PosVert = i;
                                            movingEnemy.PosHor = j + 1;
                                            SwapPosition(i, j, i, j + 1);
                                        }

                                        break;
                                    default:
                                        break;
                                }
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

            //reset alreadyMoved flag
            foreach (Enemy movedEnemy in enemies)
            {
                movedEnemy.AlreadyMoved = false;
            }

        }
        
        //Checks if the player is next to an enemy so that they don't move
        public bool CheckPlayer(int vert, int hor)
        {
            // Enemy checks the existance of player using 4 directions Radar
            if (map[vert - 1, hor] == '$' || map[vert, hor - 1] == '$' || map[vert + 1, hor] == '$' || map[vert, hor + 1] == '$')
                return true;
            return false;
        }

        //Moves enemies and entities by swapping their place with the next spot
        public void SwapPosition(int curVert, int curHor, int nextVert, int nextHor)
        {
            //movememt of the player and the enemy
            char tmp = map[curVert, curHor];
            map[curVert, curHor] = map[nextVert, nextHor];
            map[nextVert, nextHor] = tmp;
        }

        //Makes it so that the player either attacks or move
        public void PlayerAttack(int nextVert, int nextHor)
        {
            bool attacking = false;
            char[] enemyChars = { 'R', 'B', 'S', 'G', 'M' };
            foreach(char nextEnemy in enemyChars)
            {
                if(map[nextVert, nextHor]==nextEnemy)
                {
                    attacking = true;
                }
            }

            if (attacking)
            {
                //It then checks through all the enmies until it finds the one at the correct position
                foreach (Enemy attackedEnemy in enemies)
                {
                    if (attackedEnemy.PosVert == nextVert && (nextHor == attackedEnemy.PosHor))
                    {
                        //The player attacks the enemy
                        myPlayer.Attack(attackedEnemy);

                        //if the enemy is still alive, it doesn't despawn it, if it is dead, it removes it.
                        if (!attackedEnemy.EntityStatus)
                        {
                            DespawnEnemies(attackedEnemy);
                        }
                        break;
                    }
                }
            }
        }
        
        //Makes the Player move or attack depending on where they are at or if they move towards an enemy
        public bool MovePlayer()
        {
            //Reads input from keyboard
            int nextVert = myPlayer.PosVert;
            int nextHor = myPlayer.PosHor;
            ConsoleKeyInfo _Key = Console.ReadKey();
            switch (_Key.Key)
            {
                case ConsoleKey.RightArrow:
                    //Console.WriteLine("Right Arrow");                        
                    Console.Clear();
                    nextVert = myPlayer.PosVert;
                    nextHor = myPlayer.PosHor + 1;
                    break;
                case ConsoleKey.LeftArrow:
                    Console.Clear();
                    nextVert = myPlayer.PosVert;
                    nextHor = myPlayer.PosHor - 1;
                    break;
                case ConsoleKey.UpArrow:
                    //Console.WriteLine("Up Arrow");                        
                    Console.Clear();
                    nextVert = myPlayer.PosVert - 1;
                    nextHor = myPlayer.PosHor;
                    break;
                case ConsoleKey.DownArrow:
                    //Console.WriteLine("Down Arrow");
                    Console.Clear();
                    nextVert = myPlayer.PosVert + 1;
                    nextHor = myPlayer.PosHor;
                    break;
                case ConsoleKey.Escape:
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    //Reprint map on invalid keypress, so that it doesn't print everything a million times
                    for (int i = 0; i < HEIGHT; i++)
                    {
                        for (int j = 0; j < WIDTH; j++)
                        {
                            Console.Write(map[i, j]);
                        }
                        Console.WriteLine();
                    }
                    break;
            }

            //Changed switch case so that it changes the directions only, and now the function is called only at the bottom
            PlayerAttack(nextVert, nextHor);
            updateMatrix(myPlayer.PosVert, myPlayer.PosHor, nextVert, nextHor);
            PrintPlayerStatus();
            
            //Delays keystrokes so that the screen has time to refresh
            Thread.Sleep(100);

            //DebugEnemyPos();

            // level up conditions
            // if player meet 'E','N','D', it  returns false (go to next level or finish this game) 
            if (map[myPlayer.PosVert, myPlayer.PosHor + 1] == 'E'
              && map[myPlayer.PosVert, myPlayer.PosHor + 2] == 'N'
              && map[myPlayer.PosVert, myPlayer.PosHor + 3] == 'D')
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //In charge of determining which positions the player can move into. This tells the player if a valid character is next to it and if they can move there
        public bool NextFlag(int curVert, int curHor)
        {
            // player can move only '+' and '*' cpmditions
            // it look like collision detection
            if (map[curVert, curHor] == '*' || map[curVert, curHor] == '+')
                return true;
            return false;
        }

        //Spawns enemies based on their position determined in the tilemaps
        public void SpawnEnemies(int posVert, int posHor, char identifier)
        {
            enemies.Add(new Enemy(identifier, posVert, posHor));
        }

        //Eliminates enemy sprites once they have been defeated
        public void DespawnEnemies(Enemy deadEnemy)
        {
            map[deadEnemy.PosVert, deadEnemy.PosHor] = '*';

        }

        //Prints the player's status at the bottom of the screen
        public void PrintPlayerStatus()
        {
            Console.WriteLine("Player Class: {0}    Player Health: {1}/{2}     Level {3} ", myPlayer.PlayerClass, myPlayer.CurrentHealth, myPlayer.MaxHealth, currentLevel);
            Console.WriteLine("Player Name: {0}", myPlayer.PlayerName); ;
        }

        //This function shows us enemy information that was useful during the development of the project
        public void DebugEnemyPos()
        {
            foreach (Enemy aliveEnemy in enemies)
            {
                Console.WriteLine("{0}: posVert: {1} posHor: {2} health: {3}", aliveEnemy.EnemyName, aliveEnemy.PosVert, aliveEnemy.PosHor, aliveEnemy.CurrentHealth);
            }
        }
    }
}