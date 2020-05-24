using System;

namespace CshLab6
{
    class LightAthlet : Sportsman, ISpecificSport
    {
        private Medals _medals;
        private struct LegsPower
        {
            public int LeftPower, RightPower;
        }
        LegsPower Legs;
        public LightAthlet(int GoldMedal, int SilverMedal, int BronzeMedal, int PowerOfLeftLeg, int PowerOfRightLeg)
        {
            _medals = new Medals(GoldMedal, SilverMedal, BronzeMedal);
            Legs.LeftPower = PowerOfLeftLeg;
            Legs.RightPower = PowerOfRightLeg;
        }
        public SportName GetSportName() => SportName.LightAthletic;
        public double GetResult() => _medals.GetResult();
        public bool IsSuit(Human human)
        {
            if (human.Age < 18 || human.Age > 50) return false;
            if (human.Weight < 30 || human.Weight > 140) return false;
            if (human.Height < 120 || human.Height > 250) return false;
            if (GetResult() == 0) return false;
            return true;
        }
        public override void OutInfo()
        {
            Console.WriteLine("This person trohi likes light athletic:");
            if (Legs.LeftPower > Legs.RightPower) Console.WriteLine($"His favourite left leg has {Legs.LeftPower} power");
            else Console.WriteLine($"His favourite right leg has {Legs.RightPower} power");
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
