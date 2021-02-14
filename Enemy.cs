using System;
namespace projectP1
{
  class Enemy:Entity
  {
        //Attributes
        int enemyType; //There will be 5 enemy types: 0 R (rat), 1 B (bat), 2 S(skeleton), 3 G(goblin), 4 M(minotaur)
        //This references the values placed on top
        static char[] enemyIdentifiers = { 'R','B','S','G','M' };
        //stores the name of the enemy to print on console
        string enemyName;

        int enemyID;

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

        //ReadOnly, as it should never be changed after enemy creation;
        public int EnemyType
        {
            get
            {
                return enemyType;
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

        //Returns the value of the enemy ID, so that if there are many enemy instances, damage is stored on the correct one
        public int EnemyID
        {
            get
            {
                return enemyID;
            }
        }

        //Constructor
        public Enemy(char identifier, int posX, int posY, int enemyID)
        {
            this.posX = posX;
            this.posY = posY;
            switch (identifier)
            {
                //Rats are the weakest of enemies, meaning they are relatively easy to hit, don't hit really hard, and have medium to low health
                case 'R':
                    this.enemyName = "Rat";
                    this.maxHealth = 5;
                    this.currentHealth = maxHealth;
                    this.armorClass = 20;
                    this.attackDamage = 2;
                    this.enemyID = enemyID;
                    break;
                //Bats are nimbler than rats, but hit just as hard. They have a bit less health to compensate their nimbleness
                case 'B':
                    this.enemyName = "Bat";
                    this.maxHealth = 4;
                    this.currentHealth = maxHealth;
                    this.armorClass = 60;
                    this.attackDamage = 2;
                    this.enemyID = enemyID;
                    break;
                //While Rats and skeletons threaten the players when they come in numbers, Skeletons start to pose a real threat on their own. They have less armor than a bat, but hit harder and are more resilient
                case 'S':
                    this.enemyName = "Skeleton";
                    this.maxHealth = 10;
                    this.currentHealth = maxHealth;
                    this.armorClass = 40;
                    this.attackDamage = 5;
                    this.enemyID = enemyID;
                    break;
                //Goblins don't hit hard and fall easily, but they are slippery, making them a threat if they appear supported by a larger scary creature, or in big numbers
                case 'G':
                    this.enemyName = "Goblin";
                    this.maxHealth = 8;
                    this.currentHealth = maxHealth;
                    this.armorClass = 50;
                    this.attackDamage = 3;
                    this.enemyID = enemyID;
                    break;
                //Minotaurs are the strongest enemies you'll face. Easy to hit but hard to knock down, if you attack them without healing you are sure to fall in battle
                case 'M':
                    this.enemyName = "Minotaur";
                    this.maxHealth = 25;
                    this.currentHealth = maxHealth;
                    this.armorClass = 30;
                    this.attackDamage = 8;
                    this.enemyID = enemyID;
                    break;


            }
        }
        

        //When an enemy dies, its space must be replaced with a loot drop or with the floor value, not game over like the player
        protected override void Die()
        {
            
        }
    }
}