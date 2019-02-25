using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterClasses
{
    // Parent Class
    public abstract class Monster // Abstract classes can have abstract members, but not all members have to be abstract.
    {
        //Enums
        public enum MonsterAction { Attack, Defend, Retreat }

        //Fields
        private int _id;
        public string _name; // This is public becase other classes need to reference _name
        private int _age;
        private int _height;
        private int _weight;
        private string _color;
        private bool _eatHumans;
        private bool _playsGolf;


        //Properties
        public bool PlaysGolf
        {
            get { return _playsGolf; }
            set { _playsGolf = value; }
        }

        public bool EatHumans
        {
            get { return _eatHumans; }
            set { _eatHumans = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        

        //Constructors
        public Monster() // Default Constructor has the same name as the Class and no parameters
        { 

        }

        public Monster(int id, string name) // This constructor is used to create a new 'Monster'
        {
            _id = id;
            _name = name;
        }
        

        //Methods
        public virtual string Greeting() // Virtual allows child classes to alter this method. Virtual also means it doesn't have to be used.
        {
            return $"Hello, my name is {_name}";
        }

        public abstract bool IsHappy(); // Abstract forces child classes to define this method. Parent class also has to be abstract.
    }
}
