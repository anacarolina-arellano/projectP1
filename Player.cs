using System;

namespace projectP1{
  class Player: Entity
  {
        // string playerClass;
        // int gold;  //Gold is used to calculate the score at the end

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

        protected override void Die()
        {
            
        }



    }
}