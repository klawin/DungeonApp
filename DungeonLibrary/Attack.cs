using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Attack
    {
        //FIELDS
        public int _minDamage;

        //PROPERTIES
        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public int BonusHitChance { get; set; }
        public bool GoodPower { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }

        //CTORS
        public Attack(string name, int minDamage, int maxDamage, int bonusHitChance, bool goodPower)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            GoodPower = goodPower;
        }

        public Attack()
        {
        }

        //METHODS
        public override string ToString()
        {
            return string.Format("{0}\n" +
                "\t\tDamage: {1} to {2} \n" +
                "\t\tBonus Hit: {3}%\n" +
                "\t\tAttack Type: {4}", Name, MinDamage, MaxDamage, BonusHitChance, GoodPower? "Good" : "Evil");
        }
        
    }
}
