using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace OpponentLibrary
{
    public class Demon : Opponent
    {
        public bool IsUpperLevel { get; set; }

        public Demon(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isUpperLevel)
            : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsUpperLevel = isUpperLevel;
        }

        public Demon()
        {
            MaxLife = 15;
            MaxDamage = 5;
            Name = "Low-Level Demon";
            Life = 15;
            HitChance = 10;
            Block = 5;
            MinDamage = 1;
            Description = "Careful! Motivated by evil!\n";
            IsUpperLevel = false;
        }

        public override string ToString()
        {
            return base.ToString() + (IsUpperLevel ? "An upper level demon. Approach carefully!" : "An average demon...easy match!");
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            int calculatedDamage = rand.Next(MinDamage, MaxDamage + 1);

            if (IsUpperLevel)
            {
                calculatedDamage += calculatedDamage;//double damage
            }
            return calculatedDamage;
        }
    }
}
