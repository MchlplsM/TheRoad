using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRoad
{
    class Player
    {
        public string name;
        public string weapon = "Fists";
        public int coins = 100;
        public int maxHealth = 10;
        public int health = 10;
        public int damage = 1;
        public int armorValue = 0;

        public int mod = 0;
        public int difficulty;
        public int Difficulty(int difficulty)
        {
            Random rand = new Random();
            if(difficulty == 1)
            {
                return rand.Next(1, 6);
            }
            else if (difficulty == 2)
            {
                return rand.Next(2, 8);
            }
            else
            {
                return rand.Next(3, 10);
            }

        }
    }
}
