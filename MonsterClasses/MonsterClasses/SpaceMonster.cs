using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterClasses
{
    public class SpaceMonster : Monster, IBattle // Colon means SpaceMonster inherits from Monster and IBattle. Can implement one base class, but multiple interfaces.
    {
        // Fields
        private string _galaxy;
        

        // Properties
        public string Galaxy
        {
            get { return _galaxy; }
            set { _galaxy = value; }
        }


        // Methods
        public override string Greeting() // 'override' indicates we want to redefine the Greeting method from the Monster Class.
        {
            return $"Hellow, my name is {base.Name} and I am from the {_galaxy} galaxy.";
        }

        public override bool IsHappy()
        {
            return PlaysGolf ? true : false; ;
        }

        public MonsterAction MonsterBattleResponse()
        {
            Random randomNumber = new Random(); // Generates a random number.
            int battleResponseNumber = randomNumber.Next(0, 101); // Generates a number between 0 and 100.

            if (battleResponseNumber >= 66) // 1/3 of the time monster will attack, etc. These numbers could be changed to make the monster more 'aggresive', 'passive', etc.
            {
                return MonsterAction.Attack;
            }
            else if (battleResponseNumber >= 33)
            {
                return MonsterAction.Defend;
            }
            else
            {
                return MonsterAction.Retreat;
            }
        }
    }
}
