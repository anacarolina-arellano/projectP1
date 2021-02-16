using System;

namespace projectP1{
  class Player: Entity
  {
        string playerName;
        string playerClass; //The player can be a Fighter, a Wizard or a Thief
        int score;  //Gold is used to calculate the score at the end
        //Stores the value of an enum determining whether its alive or dead
        int playerStatus = 1;

        //Maximum Health that a player can have
        //Based on its class
        public override int MaxHealth
        {
            get
            {
                return maxHealth;
            }
            set
            {
                //Used in cases where the max health value is increased, and in doing so, also heals the entity to max health
                maxHealth = value;
                CurrentHealth = maxHealth;

            }
        }
        //Sets the name of the player to the received value
        //Returns the player's name
        public string PlayerName
        {
          get
          {
            return playerName;
          }
          set
          {
            playerName = value;
          }
        }
        //Sets the class of the player to the received value
        //Returns the player's class
        public string PlayerClass
        { 
          get
          {
            return playerClass;
          }
          set
          {
            playerClass = value;
          }
        }

        //Sets the player's score to the received value
        //Returns the player's score
        public int Score
        { 
          get
          {
            return score;
          }
          set
          {
            score = value;
          }
        }

        //Sets the player's status to the received value
        //Returns the player's status
        public int PlayerStatus
        {
          get
          {
            return playerStatus;
          }
          set
          {
            playerStatus = value;
          }
        }

        //Constructor
        public Player(string playerName, char identifier)
        {
            this.playerName = playerName;
            switch (identifier)
            {
                //Fighters are the most durable of the classes. They hit ok and have medium armor
                case 'F':
                    this.playerClass = "Fighter";
                    this.maxHealth = 17;
                    this.currentHealth = maxHealth;
                    this.armorClass = 40;
                    this.attackDamage = 4;
                    break;
                //Thieves are the most nimble of them all. They hit ok and have a medium health pool
                case 'T':
                    this.playerClass = "Thief";
                    this.maxHealth = 12;
                    this.currentHealth = maxHealth;
                    this.armorClass = 60;
                    this.attackDamage = 4;
                    break;
                //Wizards have the lowest armor and health, but they can hit like a truck
                case 'W':
                    this.playerClass = "Wizard";
                    this.maxHealth = 9;
                    this.currentHealth = maxHealth;
                    this.armorClass = 40;
                    this.attackDamage = 7;
                    break;
            }
        }
        //Player died
        protected override void Die()
        {
            playerStatus = (int)EntityStatus.DEAD;
        }
    }
}