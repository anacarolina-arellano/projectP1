/*
José Ignacio Ferrer / Daiyong Kim / Ana Carolina Arellano
Entity.cs
Final Project
Intro to Programming in C#
February 16, 2021
*/

using System;
namespace projectP1
{
    //Abstract class, as it will never be instantiated as an Entity, only as a Player or enemy
    abstract class Entity
    {
        //possible status of player and enemies
        protected bool entityStatus=true;
        //Attributes
        protected char identifier;    //The Console identifier for the entity
        protected int currentHealth;  //The current health of the entity (never more than maxHealth)
        protected int maxHealth;      //Max health of the entity (can be increased through powerups
        protected int armorClass;            //Percentage chance to be hit by an attack
        protected int attackDamage;         //Damage they deal when they hit with an attack
        protected int posVert;              //Current position in the grid on the Y Axis
        protected int posHor;              //Current position in the Grid on the X Axis

        //Properties
        public bool EntityStatus
        {
            get
            {
                return entityStatus;
            }
            set
            {
                entityStatus = value;
            }
        }

        //Marks the player's current health
        public int CurrentHealth
        {
            get
            {
                return currentHealth;
            }
            set
            {
                currentHealth = value;
                //Makes sure that an object's current health doesn't surpass its max health limit
                if (currentHealth > maxHealth)
                {
                    currentHealth = maxHealth;
                }
                //If the entity's health reaches 0, they die
                else if (currentHealth <= 0)
                {
                    Die();

                }
            }
        }

        //Abstract method, so that each of the inheriting classes may define its behavior inside their own class
        public abstract int MaxHealth
        {
            get;
            set;
        }

        //defines the chance to be hit
        public int ArmorClass
        {
            get
            {
                return armorClass;
            }

            set
            {
                //should always be able to be hit, characters may not be invincible, even after collecting powerups that make them nimbler
                armorClass = value;
                if (armorClass < 90)
                {
                    armorClass = 90;
                }
            }
        }

        //Is the damage an entity does to another when attacking them
        public int AttackDamage
        {
            get
            {
                return attackDamage;
            }
            set
            {
                attackDamage = value;
            }
        }

        //The Vertical position of the entity in the matrix
        public int PosVert
        {
            get
            {
                return posVert;
            }
            set
            {
                posVert = value;
            }
        }

        //The Horizontal position of the entity in the matrix
        public int PosHor
        {
            get
            {
                return posHor;
            }
            set
            {
                posHor = value;
            }
        }

        //Happens whenever an entity collides with another, and happens the same way for both types of entities
        public virtual void Attack(Entity receiving)
        {
            Random randomNumber = new Random();
            int hitRoll = randomNumber.Next(1, 100);

            //Whenever the character hits, it deals iits attackDamage as damage to the other's health.
            if (hitRoll >= receiving.armorClass)
            {
                receiving.TakeDamage(AttackDamage);
                return;
            }
            Console.WriteLine("It misses!");

        }

        //Both types of entities take damage in the same way
        protected virtual void TakeDamage(int damageDealt)
        {
            Console.WriteLine("The Attack hit! It dealt {0} damage!", damageDealt);
            CurrentHealth -= damageDealt;
        }

        //Both types of entities cause diferent things as they die, meaning each would need to define what happens
        protected abstract void Die();
    }
}
