using System;
using System.Collections.Generic;

namespace Lab3 {
  public class Game {
    private Dictionary<int, Transport> Transports = new Dictionary<int, Transport>();
    private Dictionary<int, Land> TransportsL = new Dictionary<int, Land>();
    private int TransportId = 0;

    public Game() { }

    public void AddLand(string name, int speed, int interval, int duration) {
      Land obj = new Land(name, speed, 0, interval, duration);
      TransportsL.Add(TransportId, obj);
      TransportId += 1;
    }
    public void AddAir(string name, int speed, int reducer) {
      Transport obj = new Air(name, speed, 1, reducer);
      Transports.Add(TransportId, obj);
      TransportId += 1;
    }

    public double LandFormula(Land obj, int distance) {
        if (obj.GetName() == "двугорбый верблюд") {
          return distance / obj.GetSpeed() + 5 + (Convert.ToInt32(distance / (obj.GetSpeed() * obj.GetRestInterval())) - 1) * 8;
        }
        if (obj.GetName() == "верблюд-быстроход") {
          return distance / obj.GetSpeed() + 5 + 6.5 + (Convert.ToInt32(distance / (obj.GetSpeed() * obj.GetRestInterval())) - 2) * 8;
        }
        if (obj.GetName() == "кентавр") {
          return distance / obj.GetSpeed() + Convert.ToInt32(distance / (obj.GetSpeed() * obj.GetRestInterval())) * 2;
        }
        if (obj.GetName() == "ботинки-вездеходы") {
          return distance / obj.GetSpeed() + 10 + (Convert.ToInt32(distance / (obj.GetSpeed() * obj.GetRestInterval())) - 1) * 5;
        }
        return default;
    }
    public double AirFormula(Air obj, int distance) {
        if (obj.GetName() == "ковер-самолет") {
          if (distance <= 1000) {
            return distance / obj.GetSpeed();
          }
          else if (distance <= 5000) {
            return 1.06 * distance / obj.GetSpeed();
          }
          else if (distance <= 10000) {
            return 1.1 * distance / obj.GetSpeed();
          }
          else {
            return 1.05 * distance / obj.GetSpeed();
          }
        }
        if (obj.GetName() == "ступа") {
          return (100 + obj.GetDistanceReducer()) / 100 * distance / obj.GetSpeed();
        }
        if (obj.GetName() == "метла") {
          return (100 + distance / 1000) / 100 * distance / obj.GetSpeed();
        }
        return default;
    }

    public void StartRace(int type, int distance) {
      double min = 9999;
      string name = ";";
      switch (type) {
        case 0:
          foreach(KeyValuePair<int, Land> tr in this.GetTransportsL()) {
            if (tr.Value.GetType() == 0) {
              if (LandFormula(tr.Value, distance) < min) {
                min = LandFormula(tr.Value, distance);
                name = tr.Value.GetName();
              }
            }
          }
          Console.WriteLine("Land Race: " + name);
          break;
        case 1:
          Console.WriteLine("Air");
          break;
        case 2:
          Console.WriteLine("all");
          break;
      }
    }

    public void Display() {
      foreach(KeyValuePair<int, Transport> tr in this.GetTransports()) {
        Console.WriteLine(tr.Key + tr.Value.GetName() + " " + tr.Value.GetSpeed());
      }
    }

    public Dictionary<int, Transport> GetTransports() {
      return Transports;
    }
    public Dictionary<int, Land> GetTransportsL() {
      return TransportsL;
    }

  }
}
