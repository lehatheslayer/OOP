using System;
using System.Collections.Generic;

namespace Lab3 {
    class Program {
        static void Main(string[] args) {
            Game myGame = new Game(); //(string name, int speed, int interval, int duration)
            myGame.AddAir("ковер-самолет", 10, 0);
            myGame.AddAir("ступа", 8, 6);
            myGame.AddAir("метла", 20, 1);
            myGame.AddLand("двугорбый верблюд", 10, 30, 5);
            myGame.AddLand("верблюд-быстроход", 10, 40, 5);
            myGame.AddLand("кентавр", 15, 8, 2);
            myGame.AddLand("ботинки-вездеходы", 6, 60, 10);
            myGame.Display();
            myGame.StartRace(0, 10000);
        }
    }
}
