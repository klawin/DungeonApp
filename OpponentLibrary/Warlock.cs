using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace OpponentLibrary
{
    public class Warlock : Opponent
    {
        public bool IsUpperLevel { get; set; }

        public Warlock(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isUpperLevel)
            : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsUpperLevel = isUpperLevel;
        }

        public Warlock()
        {
            MaxLife = 10;
            MaxDamage = 5;
            Name = "Low-Level Warlock";
            Life = 10;
            HitChance = 10;
            Block = 5;
            MinDamage = 1;
            Description = "Careful! Motivated by evil!\n";
            IsUpperLevel = false;
        }

        public override string ToString()
        {
            return base.ToString() + (IsUpperLevel ? "An upper level warlock. Approach carefully!" : "An average warlock...easy match!");
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            int calculatedDamage = rand.Next(MinDamage, MaxDamage+1);
            
            if (IsUpperLevel)
            {
                calculatedDamage += calculatedDamage;//double damage
            }
            return calculatedDamage;
        }
    }
}
