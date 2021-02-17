/*
José Ignacio Ferrer / Daiyong Kim / Ana Carolina Arellano
Enemy.cs
Final Project
Intro to Programming in C#
February 16, 2021
*/

using System;
namespace projectP1
{
    class Enemy : Entity
    {

        //Attributes
        //stores the name of the enemy to print on console
        string enemyName;
        //Stores the value of an enum determining whether its alive or dead
        int enemyStatus = (int)EntityStatus.ALIVE;

        bool alreadyMoved = false;

        //Both types of entities behave differentyl in how their MaxHealth fluctuates in game, so they have different properties
        public override int MaxHealth
        {
            get
            {
                return maxHealth;
            }
            set
            {
                this.maxHealth = MaxHealth;
            }
        }

        //ReadOnly, as it should never be changed after enemy creation, used for messages in the console
        public string EnemyName
        {
            get
            {
                return enemyName;
            }
        }

        //Changed only in the case that Die() is called
        public int EnemyStatus
        {
            get
            {
                return enemyStatus;
            }
            set
            {
                enemyStatus = value;
            }
        }

        //Determines whether the enemy has already moved before in a turn
        public bool AlreadyMoved
        {
            get
            {
                return alreadyMoved;
            }
            set
            {
                alreadyMoved = value;
            }
        }


        //Constructor
        public Enemy(char identifier, int posVert, int posHor)
        {
            this.posVert = posVert;
            this.posHor = posHor;
            this.identifier = identifier;
            switch (identifier)
            {
                //Rats are the weakest of enemies, meaning they are relatively easy to hit, don't hit really hard, and have medium to low health
                case 'R':
                    this.enemyName = "Rat";
                    this.maxHealth = 5;
                    this.currentHealth = maxHealth;
                    this.armorClass = 20;
                    this.attackDamage = 2;
                    break;
                //Bats are nimbler than rats, but hit just as hard. They have a bit less health to compensate their nimbleness
                case 'B':
                    this.enemyName = "Bat";
                    this.maxHealth = 4;
                    this.currentHealth = maxHealth;
                    this.armorClass = 60;
                    this.attackDamage = 2;
                    break;
                //While Rats and skeletons threaten the players when they come in numbers, Skeletons start to pose a real threat on their own. They have less armor than a bat, but hit harder and are more resilient
                case 'S':
                    this.enemyName = "Skeleton";
                    this.maxHealth = 10;
                    this.currentHealth = maxHealth;
                    this.armorClass = 40;
                    this.attackDamage = 5;
                    break;
                //Goblins don't hit hard and fall easily, but they are slippery, making them a threat if they appear supported by a larger scary creature, or in big numbers
                case 'G':
                    this.enemyName = "Goblin";
                    this.maxHealth = 8;
                    this.currentHealth = maxHealth;
                    this.armorClass = 50;
                    this.attackDamage = 3;
                    break;
                //Minotaurs are the strongest enemies you'll face. Easy to hit but hard to knock down, if you attack them without healing you are sure to fall in battle
                case 'M':
                    this.enemyName = "Minotaur";
                    this.maxHealth = 25;
                    this.currentHealth = maxHealth;
                    this.armorClass = 30;
                    this.attackDamage = 8;
                    break;


            }
        }
        //Function to make damage to the player
        public override void Attack(Entity receiving)
        {
            base.Attack(receiving);
        }

        //When an enemy dies, its space must be replaced with a loot drop or with the floor value, not game over like the player
        protected override void Die()
        {
            Console.WriteLine("The {0} has died!", enemyName);
            enemyStatus = (int)EntityStatus.DEAD;
        }
    }
}