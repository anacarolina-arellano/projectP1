/*
José Ignacio Ferrer / Daiyong Kim / Ana Carolina Arellano
Player.cs
Final Project
Intro to Programming in C#
February 16, 2021
*/

using System;

namespace projectP1
{
    class Player : Entity
    {
        //Stores the name of the player playing the game
        string playerName;
        //The player can be a Fighter, a Wizard or a Thief
        string playerClass;
        //Determines the health given at the end of each level depending on your class
        int healthMultiplier;

        enum PlayerClasses
        {
            FIGHTER = 1,
            THIEF,
            WIZARD
        }

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

        //Determines the max health a player gains upon finishing a level
        public int HealthMultiplier
        {
            get
            {
                return healthMultiplier;
            }
        }

        //Constructor
        public Player(string playerName, int classNum)
        {
            this.playerName = playerName;
            switch (classNum)
            {
                //Fighters are the most durable of the classes. They hit ok and have medium armor
                case (int)PlayerClasses.FIGHTER:
                    this.identifier = 'F';
                    this.playerClass = "Fighter";
                    this.maxHealth = 20;
                    this.currentHealth = maxHealth;
                    this.armorClass = 40;
                    this.attackDamage = 5;
                    this.healthMultiplier = 2;
                    break;
                //Thieves are the most nimble of them all. They hit ok and have a medium health pool
                case (int)PlayerClasses.THIEF:
                    this.identifier = 'T';
                    this.playerClass = "Thief";
                    this.maxHealth = 15;
                    this.currentHealth = maxHealth;
                    this.armorClass = 60;
                    this.attackDamage = 7;
                    this.healthMultiplier = 1;
                    break;
                //Wizards have the lowest armor and health, but they can hit like a truck
                case (int)PlayerClasses.WIZARD:
                    this.identifier = 'W';
                    this.playerClass = "Wizard";
                    this.maxHealth = 10;
                    this.currentHealth = maxHealth;
                    this.armorClass = 40;
                    this.attackDamage = 10;
                    this.healthMultiplier = 1;
                    break;
            }
        }

        //Calls upon the original attack function and adds some flavor to the action
        public override void Attack(Entity receiving)
        {
            Enemy enemyReceiving = (Enemy)receiving;
            Console.WriteLine("You attack the {0}!", enemyReceiving.EnemyName);
            base.Attack(receiving);
            //should the player not die, they have the opportunity to attack back
            if (enemyReceiving.EntityStatus)
            {
                Console.WriteLine("They attack you back!");
                enemyReceiving.Attack(this);
            }
        }

        //Player died
        protected override void Die()
        {
            EntityStatus = false;
        }
    }
}