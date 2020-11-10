using System;

namespace Lab3 {
  public abstract class Transport {
    private int Speed;
    private string Name;
    private bool Type;

    public Transport (string name, int speed, bool type) {
      Type = type;
      Name = name;
      Speed = speed;
    }

    public int GetSpeed() { return Speed; }
    public string GetName() { return Name; }
    new public bool GetType() { return Type; }



    public abstract double GetTime(int distance);
  }
  public class Air : Transport {
    private int[] DistanceReducer; //percent
    private int[] DistanceInterval;
    private bool Evenly;

    public Air(string name, int speed, bool type, int[] reducer, int[] interval, bool e) : base(name, speed, type) {
      DistanceReducer = new int[reducer.Length];
      DistanceInterval = new int[interval.Length];
      Evenly = e;
      for (int i = 0; i < reducer.Length; i++){
        DistanceReducer[i] = reducer[i];
      }
      for (int i = 0; i < interval.Length; i++){
        DistanceInterval[i] = interval[i];
      }
    }

    public int[] GetDistanceReducer() { return DistanceReducer; }
    public int[] GetDistanceInterval() { return DistanceInterval; }
    public bool GetEvenly() { return Evenly; }

    public override double GetTime(int distance) {
      int speed = this.GetSpeed();
      int[] interval = this.GetDistanceInterval();
      int[] reducer = this.GetDistanceReducer();
      bool e = this.GetEvenly();
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
  }
  public class Land : Transport {
    private int RestInterval;
    private double[] RestDuration;

    public Land(string name, int speed, bool type, int interval, double[] duration) : base(name, speed, type) {
      RestInterval = interval;
      RestDuration = new double[duration.Length];
      for (int i = 0; i < duration.Length; i++) {
        RestDuration[i] = duration[i];
      }
    }

    public int GetRestInterval() { return RestInterval; }
    public double[] GetRestDuration() { return RestDuration; }

    public override double GetTime(int distance) {
      int speed = this.GetSpeed();
      int interval = this.GetRestInterval();
      double[] duration = this.GetRestDuration();
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
  }
}
