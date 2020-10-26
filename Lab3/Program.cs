using System;
using System.Collections.Generic;

namespace Lab3 {
    class Program {
        static void Main(string[] args) {
            Game myGame = new Game(); //(string name, int speed, int interval, int duration)

            myGame.AddAir("ковер-самолет", 10, new int[] {0, 3, 10, 5}, new int[] {1000, 5000, 10000}, false);
            myGame.AddAir("ступа", 8, new int[] {6}, new int[] {}, false);
            myGame.AddAir("метла", 20, new int[] {1}, new int[] {1000}, true);

            myGame.AddLand("двугорбый верблюд", 10, 30, new double[] {5, 8});
            myGame.AddLand("верблюд-быстроход", 40, 10, new double[] {5, 6.5, 8});
            myGame.AddLand("кентавр", 15, 8, new double[] {2});
            myGame.AddLand("ботинки-вездеходы", 6, 60, new double[] {10, 5});

            int[] AirPack = new int[] {0, 1, 2};
            int[] LandPack = new int[] {3, 4, 5, 6};
            int[] AllInPack = new int[] {0, 1, 2, 3, 4, 5, 6};
            myGame.Display();
            Console.WriteLine("");
            myGame.Race(0, LandPack, 10000);
            Console.WriteLine("");
            myGame.Race(1, AirPack, 10000);
            Console.WriteLine("");
            myGame.Race(2, AllInPack, 10000);
            //myGame.StartRace(0, 10000);
        }
    }
}
