using System;
using System.Collections.Generic;

namespace Lab3 {
    class Program {
        static void Main(string[] args) {
            Game myGame = new Game(); //(string name, int speed, int interval, int duration)

            myGame.Add("ковер-самолет", 10, true, default, default, new int[] {0, 3, 10, 5}, new int[] {1000, 5000, 10000}, false);
            myGame.Add("ступа", 8, true, default, default, new int[] {6}, new int[] {}, false);
            myGame.Add("метла", 20, true, default, default, new int[] {1}, new int[] {1000}, true);

            myGame.Add("двугорбый верблюд", 10, false, 30,  new double[] {5, 8}, default, default, default);
            myGame.Add("верблюд-быстроход", 40, false, 10,  new double[] {5, 6.5, 8}, default, default, default);
            myGame.Add("кентавр", 15, false, 8,  new double[] {2}, default, default, default);
            myGame.Add("ботинки-вездеходы", 6, false, 60,  new double[] {10, 5}, default, default, default);

            int[] AirPack = new int[] {0, 1, 2};
            int[] LandPack = new int[] {3, 4, 5, 6};
            int[] AllInPack = new int[] {0, 1, 2, 3, 4, 5, 6};

            myGame.Register(0, LandPack, 2000);
            myGame.StartRace();
            myGame.Register(0, AirPack, 2000);
            myGame.StartRace();
            myGame.Register(1, AirPack, 2000);
            myGame.StartRace();
            myGame.Register(2, AllInPack, 2000);
            myGame.StartRace();

            //myGame.StartRace(0, 10000);
        }
    }
}
