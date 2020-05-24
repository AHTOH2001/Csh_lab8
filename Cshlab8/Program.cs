using System;
using System.Collections.Generic;

namespace CshLab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter 1 or 2");
            char c = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (c == '1')
            {
                Console.WriteLine("Enter amount of sportsmans");
                int n = Convert.ToInt32(Console.ReadLine());
                Random rnd = new Random(DateTime.Now.Millisecond);
                string[] nme = { "vasya", "kolya", "vitya", "VikuSHa", "boris", "genadiy", "anton" };
                Programmer.Regions[] regions = { Programmer.Regions.Brest, Programmer.Regions.Gomel, Programmer.Regions.Grodno, Programmer.Regions.Minsk, Programmer.Regions.Mogilel, Programmer.Regions.Vitebsk };
                List<Sportsman> sportsmans = new List<Sportsman>();
                for (int i = 0; i < n; i++)
                {
                    Human human = new Human(age: rnd.Next() % 100 + 1,
                                         weight: rnd.Next() % 300 + 1,
                                         height: rnd.Next() % 200 + 1,
                                         name: nme[rnd.Next() % nme.Length]);

                    int m = rnd.Next() % 3 + 1;
                    ISpecificSport[] mas = new ISpecificSport[m];
                    for (int j = 0; j < m; j++)
                    {
                        int k = rnd.Next() % 3;
                        switch (k)
                        {
                            case 0:
                                mas[j] = new Programmer(regions[rnd.Next() % 6], rnd.Next() % 1, rnd.Next() % 1, rnd.Next() % 1, rnd.Next() % 5, rnd.Next() % 3, rnd.Next() % 2, rnd.NextDouble() * rnd.Next() % 1000);
                                break;
                            case 1:
                                mas[j] = new LightAthlet(rnd.Next() % 3, rnd.Next() % 5, rnd.Next() % 12, rnd.Next() % 200, rnd.Next() % 200);
                                break;
                            case 2:
                                mas[j] = new Weightlifter(rnd.Next() % 3, rnd.Next() % 5, rnd.Next() % 12);
                                break;

                        }
                    }
                    sportsmans.Add(new Sportsman(human, mas));
                }
                //sportsmans.Sort(new Human.CompareByName()); // Sort sportsmans by name;
                sportsmans.Sort();
                for (int i = 0; i < n; i++)
                    sportsmans[i].OutInfo();

                Console.WriteLine("All people sorted according to their results");
            }
            else
            if (c == '2')
            {
                Human human1 = new Human(age: 19, weight: 50, height: 163, name: "VikushaNormalnaya");
                Programmer sport1 = new Programmer(region: Programmer.Regions.Minsk, thirdDiplomaResp: 0, secondDiplomaResp: 0, firstDiplomaResp: 2, thirdDiplomaObl: 1);
                ISpecificSport sport3;
                Sportsman sportsman1 = new Sportsman(human1);
                sportsman1.Add(sport1);
                sportsman1.Add(new LightAthlet(GoldMedal: 1, SilverMedal: 0, BronzeMedal: 0, PowerOfLeftLeg: 123, PowerOfRightLeg: 89));
                sportsman1.OutInfo();
                sportsman1[SportName.SportProgramming] = new Programmer(region: Programmer.Regions.Gomel, thirdDiplomaResp: 0, secondDiplomaResp: 0, firstDiplomaResp: 0, thirdDiplomaObl: 1, klacSpeed: 13.2);
                sportsman1.OutInfo();
                Sportsman sportsman2 = new Sportsman(age: 18, weight: 250, height: 183, name: "Toshunya");
                ISpecificSport sport2 = new Weightlifter(GoldMedal: 1, SilverMedal: 0, BronzeMedal: 0);
                sportsman2.Add(sport2);
                sportsman2.OutInfo();
                Console.WriteLine(sportsman1[SportName.SportProgramming].GetResult());
                Human hm1 = new Human(5, 5, 5, "Vitya");
                Human hm2 = (Human)hm1.Clone();
                hm2.OutInfo();
                sport3 = (ISpecificSport)sport1.Clone();
                if (sport1.Equals(sport3)) Console.WriteLine("\nsport1 is equal sport3");
                else Console.WriteLine("\nsport1 is not equal sport3");

            }
            Console.ReadKey();
        }
    }
}

