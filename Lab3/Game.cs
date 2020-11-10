using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab3 {
  public class Game {
    private List<Transport> Transports;
    private int RaceType;
    private List<int> RegisteredTransports;
    private int Distance;

    public Game() {
      Transports = new List<Transport>();
      RaceType = 3;
      RegisteredTransports = new List<int>();
      Distance = 0;
    }

    public void Add(string name, int speed, bool type, int restInterval, double[] restDuration, int[] distReducer, int[] distInterval, bool e) {
      if (type == false)
        Transports.Add(new Land(name, speed, type, restInterval, restDuration));
      else
        Transports.Add(new Air(name, speed, type, distReducer, distInterval, e));
    }

    public void Register(int r_type, int[] ids, int distance) {
      if (this.RaceType != 3) {
        Console.WriteLine("Предстоящая гонка уже зарегистрирована");
        return;
      }
      switch (r_type) {
        case 0: //Land
          for (int i = 0; i < ids.Length; i++) {
            if (!this.GetTransports().Contains(this.GetTransports()[ids[i]])) {
              Console.WriteLine("Наземного транспорта с id " + ids[i] + " не существует");
              return;
            }
            if (this.GetTransports()[ids[i]].GetType() != false) {
              Console.WriteLine("Транспорт с id " + ids[i] + " не является наземным");
              return;
            }
            RegisteredTransports.Add(ids[i]);
          }
          Distance = distance;
          RaceType = r_type;
          break;
        case 1: //Air
          for (int i = 0; i < ids.Length; i++) {
            if (!this.GetTransports().Contains(this.GetTransports()[ids[i]])) {
              Console.WriteLine("Наземного транспорта с id " + ids[i] + " не существует");
              return;
            }
            if (this.GetTransports()[ids[i]].GetType() != true) {
              Console.WriteLine("Транспорт с id " + ids[i] + " не является воздушным");
              return;
            }
            RegisteredTransports.Add(ids[i]);
          }
          Distance = distance;
          RaceType = r_type;
          break;
        case 2: //Air&Land
          for (int i = 0; i < ids.Length; i++) {
            if (!this.GetTransports().Contains(this.GetTransports()[ids[i]])) {
              Console.WriteLine("Наземного транспорта с id " + ids[i] + " не существует");
              return;
            }
            RegisteredTransports.Add(ids[i]);
          }
          Distance = distance;
          RaceType = r_type;
          break;
      }
    }

    public void StartRace() {
      if (this.GetRaceType() == 3) {
        Console.WriteLine("Гонка еще не была объявлена");
        return;
      }
      int WinnerId = 0;
      double Min = 9999999;
      foreach(int id in this.GetRegisteredTransports()) {
        double time = this.GetTransports()[id].GetTime(this.GetDistance());
        if (Min > time) {
          Min = time;
          WinnerId = id;
        }
      }
      RaceType = 3;
      this.GetRegisteredTransports().Clear();
      Distance = 0;
      Console.WriteLine(this.GetTransports()[WinnerId].GetName());
    }

    public int GetDistance() { return Distance; }
    public List<int> GetRegisteredTransports() { return RegisteredTransports; }
    public int GetRaceType() { return RaceType; }
    public List<Transport> GetTransports() { return Transports; }

  }
}
