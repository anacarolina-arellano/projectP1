using System;
namespace projectP1
{
    //Abstract class, as it will never be instantiated as an Entity, only as a Player or enemy
    abstract class Entity
    {
        //possible status of player and enemies
        protected enum EntityStatus{
          ALIVE = 1,
          DEAD
        }
        //Attributes
        protected char identifier;    //The Console identifier for the entity
        protected int currentHealth;  //The current health of the entity (never more than maxHealth)
        protected int maxHealth;      //Max health of the entity (can be increased through powerups
        protected int armorClass;            //Percentage chance to be hit by an attack
        protected int attackDamage;         //Damage they deal when they hit with an attack
        public int posVert;              //Current position in the grid on the Y Axis
        public int posHor;              //Current position in the Grid on the X Axis

        //Properties
        public char Identifier
        {
          get
          {
            return identifier;
          }
          set
          {
            identifier = value;
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
                //If the pentity's health reaches 0, they die
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
        protected virtual void Attack(Entity receiving)
        {
            Random randomNumber = new Random();
            int hitRoll = randomNumber.Next(1, 100);
            
            //Whenever the character hits, it deals iits attackDamage as damage to the other's health.
            if (hitRoll >= receiving.armorClass)
            {
                receiving.TakeDamage(AttackDamage);
            }

        }

        //Both types of entities take damage in the same way
        protected virtual void TakeDamage( int damageDealt)
        {
            CurrentHealth -= damageDealt;
        }

        //Both types of entities cause diferent things as they die, meaning each would need to define what happens
        protected abstract void Die();
    }
}
