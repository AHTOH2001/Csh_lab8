using System;

namespace CshLab6
{
    class Weightlifter : Sportsman, ISpecificSport
    {
        private Medals _medals;
        public Weightlifter(int GoldMedal, int SilverMedal, int BronzeMedal)
        {
            _medals = new Medals(GoldMedal, SilverMedal, BronzeMedal);
        }
        public SportName GetSportName() => SportName.Weightlifting;
        public double GetResult() => _medals.GetResult();
        public bool IsSuit(Human human)
        {
            if (human.Age < 18 || human.Age > 50) return false;
            if (human.Weight < 60 || human.Weight > 400) return false;
            if (human.Height < 130 || human.Height > 250) return false;
            if (GetResult() == 0) return false;
            return true;
        }
        public override void OutInfo()
        {
            Console.WriteLine("This person trohi likes potiagat' metal:");
            _medals.OutInfo();
        }
        public int CompareTo(ISpecificSport compareSport)
        {
            if (compareSport == null) return 1;
            if (GetResult() - compareSport.GetResult() > 0) return 1;
            if (GetResult() - compareSport.GetResult() < 0) return -1;
            return 0;
        }

        public bool Equals(ISpecificSport other)
        {
            return this.GetResult() == other.GetResult() && this.GetSportName() == other.GetSportName();
        }
    }
}
