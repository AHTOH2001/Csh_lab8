using System;

namespace CshLab6
{
    class Programmer : Sportsman, ISpecificSport
    {
        private readonly int _thirdDiplomaObl;
        private readonly int _secondDiplomaObl;
        private readonly int _firstDiplomaObl;
        private readonly int _thirdDiplomaResp;
        private readonly int _secondDiplomaResp;
        private readonly int _firstDiplomaResp;

        private double _klacSpeed;

        public Programmer(Regions region, int thirdDiplomaResp, int secondDiplomaResp, int firstDiplomaResp, int thirdDiplomaObl = 0, int secondDiplomaObl = 0, int firstDiplomaObl = 0, double klacSpeed = 0)
        {
            _region = region;
            _thirdDiplomaObl = thirdDiplomaObl;
            _secondDiplomaObl = secondDiplomaObl;
            _firstDiplomaObl = firstDiplomaObl;
            _thirdDiplomaResp = thirdDiplomaResp;
            _secondDiplomaResp = secondDiplomaResp;
            _firstDiplomaResp = firstDiplomaResp;
            _klacSpeed = klacSpeed;
        }
        public enum Regions
        {
            Minsk,
            Brest,
            Gomel,
            Mogilel,
            Grodno,
            Vitebsk
        }
        private readonly Regions _region;
        public SportName GetSportName() => SportName.SportProgramming;
        public double GetResult() => _thirdDiplomaResp + _secondDiplomaResp * 2 + _firstDiplomaResp * 3 + _thirdDiplomaObl * 0.2 + _secondDiplomaObl * 0.5 + _firstDiplomaObl * 0.8;
        public bool IsSuit(Human human)
        {
            if (human.Age < 6 || human.Age > 28) return false;
            if (human.Name == "Vikusha") return false;
            if (GetResult() == 0) return false;
            return true;
        }
        public override void OutInfo()
        {
            Console.Write("This person trohi likes sport programming");
            if (_klacSpeed != 0) Console.WriteLine($" and do klac klac with speed {_klacSpeed} per second:");
            else Console.WriteLine(":");
            if (_thirdDiplomaObl != 0)
                Console.WriteLine($"number of diplomas of the third degree in {_region} regional stage: {_thirdDiplomaObl}");
            if (_secondDiplomaObl != 0)
                Console.WriteLine($"number of diplomas of the second degree in {_region} regional stage: {_secondDiplomaObl}");
            if (_firstDiplomaObl != 0)
                Console.WriteLine($"number of diplomas of the first degree in {_region} regional stage: {_firstDiplomaObl}");
            if (_thirdDiplomaResp != 0)
                Console.WriteLine($"number of diplomas of the third degree in republican stage: {_thirdDiplomaResp}");
            if (_secondDiplomaResp != 0)
                Console.WriteLine($"number of diplomas of the second degree in republican stage: {_secondDiplomaResp}");
            if (_firstDiplomaResp != 0)
                Console.WriteLine($"number of diplomas of the first degree in republican stage: {_firstDiplomaResp}");
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
