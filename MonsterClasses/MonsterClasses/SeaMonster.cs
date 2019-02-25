using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterClasses
{
    public class SeaMonster : Monster // Colon means SeaMonster inherits from Monster
    {
        // Fields
        private string _homeSea;
        private bool _hasGills;

        // Properties
        public bool HasGills
        {
            get { return _hasGills; }
            set { _hasGills = value; }
        }

        public string HomeSea
        {
            get { return _homeSea; }
            set { _homeSea = value; }
        }

        // Methods
        public override bool IsHappy() // Using the abstract (required) method from Parent Class
        {
            //if (_hasGills) // If _hasGills is true, IsHappy will return true.
            //{
            //    return true;
            //}

            //else
            //{
            //    return false;
            //}



            //      if true ? return true : else false  
            return _hasGills ? true : false; // This is the shorter version of the above code. ? is called 'Unary Operator'
        }

        public override string Greeting()
        {
            return $"Hello, I am a Sea Monster and my name is {_name}";
        }
    }
}
