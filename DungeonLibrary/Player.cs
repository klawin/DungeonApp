using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Player : Character
    {
        public CreatureType CreatureType { get; set; }
        public Attack SpecialAttack { get; set; }

        public Player(string name, int hitChance, int block, int life, int maxLife, CreatureType creatureType, Attack specialAttack)
        {
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            CreatureType = creatureType;
            SpecialAttack = specialAttack;
        }

        public override string ToString()
        {
            string description = "";

            switch (CreatureType)
            {
                case CreatureType.Witch:
                    description = "Witches, like mortals, can be either good or evil, but only the good witches serve as protectors of the innocent.";
                    break;
                case CreatureType.Demon:
                    description = "Demons are a race of immortal magical beings motivated by Evil.";
                    break;
            }//end siwtch

            return string.Format("~~ {0} ~~\n" + 
                "Description: {1}\n\n" +
                "Life: {2} of {3}\n" +
                "Hit Chance: {4}%\n" +
                "Block: {5}\n" +
                "Special Attack: {6}\n", Name, description, Life, MaxLife, CalcHitChance(), Block, SpecialAttack);
        }//end ToString()

        public override int CalcDamage()
        {
            Random rand = new Random();

            int damage = rand.Next(SpecialAttack.MinDamage, SpecialAttack.MaxDamage + 1);

            return damage;
        }

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + SpecialAttack.BonusHitChance;
        }
    }//end Player
}//end namespace
