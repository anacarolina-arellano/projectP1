using System;
namespace projectP1{
  class Entity
  {
    public int posX;
    public int posY;


    public int PosX
    {
        get
        {
            return posX;
        }

        set
        {
            posX = value;
        }
    }

    public int PosY
    {
        get
        {
            return posY;
        }

        set
        {
            posY = value;
        }
    }
    // char identifier; //What is printed in the console
    // int currentHealth;
    // int maxHealth;
    // int hit;      //Percentage chance to be hit
    // int attack;   //Damage they deal when they hit

    // enum EntityStates //The States an Entity can exist in
    // {
    //   ALIVE = 1,
    //   DEAD

    // };

    // protected virtual void Attack(Entity receiving)
    // {
    //   int hitRoll = Random.Next(1,100);
    //   if (hitRoll < receiving.hit){

    //   }

    // }

    // protected virtual void TakeDamage()
    // {
      
    // }    

    // protected virtual void Die()
    // {

    // }
  }
}
