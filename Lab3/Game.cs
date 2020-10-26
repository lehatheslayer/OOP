using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab3 {
  public class Game {
    private Dictionary<int, Air> Air = new Dictionary<int, Air>();
    private Dictionary<int, Land> Land = new Dictionary<int, Land>();
    private int Id = 0;

    public Game() { }

    public void AddLand(string name, int speed, int interval, double[] duration) {
      Land obj = new Land(name, speed, interval, duration);
      Land.Add(Id, obj);
      Id += 1;
    }
    public void AddAir(string name, int speed, int[] reducer, int[] interval, bool e) {
      Air obj = new Air(name, speed, reducer, interval, e);
      Air.Add(Id, obj);
      Id += 1;
    }

    public double LandTime(int id, double distance) {
      int speed = this.GetLand()[id].GetSpeed();
      int interval = this.GetLand()[id].GetRestInterval();
      double[] duration = this.GetLand()[id].GetRestDuration();
      int restnumber =  Convert.ToInt32(distance / (speed * interval));
      double totalrest = 0;
      int flag = 0;
      for (int i = 0; i < restnumber; i++) {
        if (i <= duration.Length - 1) {
          flag = i;
          totalrest += duration[i];
        }
        else {
          totalrest += duration[flag];
        }
      }
      double time = totalrest + distance / speed;
      return time;
    }
    public double AirTime(int id, double distance) {
      int speed = this.GetAir()[id].GetSpeed();
      int[] interval = this.GetAir()[id].GetDistanceInterval();
      int[] reducer = this.GetAir()[id].GetDistanceReducer();
      bool e = this.GetAir()[id].GetEvenly();
      double time = 0;
      int r = 0;
      if (e == true) {
        while(true) {
          r += reducer[0];
          distance -= interval[0];
          if (distance >= 0) {
            time += (100 + r) / 100 * interval[0] / speed;
            if (distance == 0)
              return time;
            r += reducer[0];
          }
          else {
            time += (100 + r) / 100 * (interval[0] + distance) / speed;
            return time;
          }
        }
      }
      else {
        if (interval.Length == 0) {
          return (100 + reducer[0]) / 100 * distance / speed;
        }
        for (int i = 0; i < interval.Length; i++) {
          if (distance < interval[i]) {
            r = i;
            break;
          }
        }
        return (100 + reducer[r]) / 100 * distance / speed;
      }
    }

    public void Race(int type, int[] ids, double distance) {
      double Min = 999999;
      int MinId = -1;
      switch (type) {
        case 0: //land
          for (int i = 0; i < ids.Length; i++) {
            if (!this.GetLand().ContainsKey(ids[i])) {
              Console.WriteLine("Наземного транспорта с id " + ids[i] + " не существует");
              return;
            }
          }
          Console.WriteLine("Гонка началась");
          for (int i = 0; i < ids.Length; i++) {
            if (Min > this.LandTime(ids[i], distance)) {
              Min = this.LandTime(ids[i], distance);
              MinId = ids[i];
            }
          }
          Console.WriteLine("Победитель гонки: " + this.GetLand()[MinId].GetName());
          break;
        case 1: //air
          for (int i = 0; i < ids.Length; i++) {
            if (!this.GetAir().ContainsKey(ids[i])) {
              Console.WriteLine("Воздушного транспорта с id " + ids[i] + " не существует");
              return;
            }
          }
          Console.WriteLine("Гонка началась");
          for (int i = 0; i < ids.Length; i++) {
            if (Min > this.AirTime(ids[i], distance)) {
              Min = this.AirTime(ids[i], distance);
              MinId = ids[i];
            }
          }
          Console.WriteLine("Победитель гонки: " + this.GetAir()[MinId].GetName());
          break;
        case 2: //air&land
          Console.WriteLine("Гонка началась");
          for (int i = 0; i < ids.Length; i++) {
            if (!this.GetAir().ContainsKey(ids[i]))
              continue;
            if (Min > this.AirTime(ids[i], distance)) {
              Min = this.AirTime(ids[i], distance);
              MinId = ids[i];
            }
          }
          for (int i = 0; i < ids.Length; i++) {
            if (!this.GetLand().ContainsKey(ids[i]))
              continue;
            if (Min > this.LandTime(ids[i], distance)) {
              Min = this.LandTime(ids[i], distance);
              MinId = ids[i];
            }
          }
          if (!this.GetAir().ContainsKey(MinId))
            Console.WriteLine("Победитель гонки: " + this.GetLand()[MinId].GetName());
          else
            Console.WriteLine("Победитель гонки: " + this.GetAir()[MinId].GetName());
          break;
      }
    }

    public void Display() {
      Console.WriteLine("Air:");
      foreach(KeyValuePair<int, Air> tr in this.GetAir())
        Console.WriteLine(tr.Key + " " + tr.Value.GetName() + " " + tr.Value.GetSpeed());
      Console.WriteLine("Land:");
      foreach(KeyValuePair<int, Land> tr in this.GetLand())
        Console.WriteLine(tr.Key + " " + tr.Value.GetName() + " " + tr.Value.GetSpeed());
    }

    public Dictionary<int, Air> GetAir() {
      return Air;
    }
    public Dictionary<int, Land> GetLand() {
      return Land;
    }

  }
}
