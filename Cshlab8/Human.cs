using System;
using System.Collections.Generic;
using System.Text;

namespace CshLab6
{
    class Human : ICloneable
    {
        private int _age = 0, _weight = 0, _height = 0;
        private string _name;
        public Human(int age, int weight, int height, string name)
        {
            Age = age;
            Weight = weight;
            Height = height;
            Name = name;
        }
        public Human()
        {
        }
        public int Age
        {
            set
            {
                if (value >= 120 || value <= 0) throw new InvalidOperationException("Invalid age");
                else
                    _age = value;
            }
            get => _age;
        }
        public int Weight
        {
            set
            {
                if (value >= 1000 || value <= 0) throw new InvalidOperationException("Invalid weight");
                else
                    _weight = value;
            }
            get => _weight;
        }
        public int Height
        {
            set
            {
                if (value >= 300 || value <= 0) throw new InvalidOperationException("Invalid height");
                else
                    _height = value;
            }
            get => _height;
        }
        public string Name
        {
            set
            {
                for (int i = 0; i < value.Length; i++)
                    if (!(value[i] >= 'A' && value[i] <= 'Z') && !(value[i] >= 'a' && value[i] <= 'z'))
                        throw new InvalidOperationException("Invalid name");

                if (value.Length == 0) throw new InvalidOperationException("Invalid name");
                _name = value;
            }
            get => FixName(_name);
        }
        
        static public Func<char, char> FixLetter { get; set; }
       
        static public string FixName(string value)
        {
            StringBuilder name = new StringBuilder();
            if (value[0] >= 'A' && value[0] <= 'Z') name.Append(value[0]);
            else name.Append((char)(value[0] - 'a' + 'A'));

            if (FixLetter == null)
                FixLetter = letter => letter;
            for (int i = 1; i < value.Length; i++)
                name.Append(FixLetter(value[i]));
            return name.ToString();
        }
        public virtual void OutInfo()
        {
            Console.WriteLine($"\nName = {Name}\nAge = {Age}\nWeight = {Weight}\nHeigth = {Height}");
        }
        
        public delegate void myAction(object x);
        public event myAction CloneCreated;
        public object Clone()
        {
            CloneCreated?.Invoke(this.MemberwiseClone());
            return this.MemberwiseClone();
        }

        public class CompareByName : IComparer<Human>
        {
            public int Compare(Human value1, Human value2)
            {
                return value1.Name.CompareTo(value2.Name);
            }
        }
    }
}
