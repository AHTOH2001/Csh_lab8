using System;
using System.Collections.Generic;

namespace CshLab6
{

    class Sportsman : Human, IComparable<Sportsman>
    {
        private List<ISpecificSport> _SpecificSport = new List<ISpecificSport>();
        private double _score;
        public Sportsman(int age, int weight, int height, string name, params ISpecificSport[] sports) : base(age, weight, height, name)
        {
            for (int i = 0; i < sports.Length; i++)
                Add(sports[i]);
        }
        public Sportsman(Human human, params ISpecificSport[] sports) : base(human.Age, human.Weight, human.Height, human.Name)
        {
            for (int i = 0; i < sports.Length; i++)
                Add(sports[i]);
        }
        public Sportsman()
        {
        }

        public int Find(SportName value)
        {
            for (int i = 0; i < _SpecificSport.Count; i++)
            {
                if (_SpecificSport[i].GetSportName() == value) return i;
            }
            return -1;
        }
        public ISpecificSport this[SportName ind]
        {
            set
            {
                int i = Find(ind);
                if (i == -1)
                    throw new FieldAccessException("Invalid sport name");

                _score -= _SpecificSport[i].GetResult();
                _SpecificSport.RemoveAt(i);
                _SpecificSport.Insert(i, value);
                _score += value.GetResult();

            }
            get
            {
                int i = Find(ind);
                if (i == -1) throw new FieldAccessException("Invalid sport name");
                return _SpecificSport[i];
            }
        }
        public void Add(ISpecificSport sport)
        {
            if (sport == null) throw new Exception("Null sports are forbidden");
            if (!sport.IsSuit(this)) return;
            int i = Find(sport.GetSportName());
            if (i != -1)
                this[sport.GetSportName()] = sport;
            else
            {
                _SpecificSport.Add(sport);
                _score += sport.GetResult();
            }
        }
        public override void OutInfo()
        {
            base.OutInfo();
            for (int i = 0; i < _SpecificSport.Count; i++)
                _SpecificSport[i].OutInfo();
            if (_SpecificSport.Count == 0)
                Console.WriteLine("But actually this person is not a sportsman /:");
            else
                Console.WriteLine($"Total score: {Math.Round(_score, 4)}");
        }
        public static bool operator <(Sportsman s1, Sportsman s2) => s1._score < s2._score;
        public static bool operator >(Sportsman s1, Sportsman s2) => s1._score > s2._score;
        public int CompareTo(Sportsman compareSportsman)
        {
            if (compareSportsman == null) return 1;
            if (_score - compareSportsman._score > 0) return 1;
            if (_score - compareSportsman._score < 0) return -1;
            return 0;
        }
    }

    public enum SportName
    {
        SportProgramming,
        Weightlifting,
        LightAthletic
    }
    public struct Medals
    {
        private int GoldMedal, SilverMedal, BronzeMedal;
        public Medals(int goldMedal, int silverMedal, int bronzeMedal)
        {
            GoldMedal = goldMedal;
            SilverMedal = silverMedal;
            BronzeMedal = bronzeMedal;
        }
        public void OutInfo()
        {
            if (GoldMedal != 0)
                Console.WriteLine($"number of gold medals: {GoldMedal}");
            if (SilverMedal != 0)
                Console.WriteLine($"number of silver medals: {SilverMedal}");
            if (BronzeMedal != 0)
                Console.WriteLine($"number of bronze medals: {BronzeMedal}");
        }
        public double GetResult() => GoldMedal * 3 + SilverMedal * 2 + BronzeMedal;

    }
}

