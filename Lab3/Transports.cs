using System;

namespace Lab3 {
  public abstract class Transport {
    private int Speed;
    private string Name;

    public Transport (string name, int speed) {
      Name = name;
      Speed = speed;
    }
    public int GetSpeed() {
      return Speed;
    }
    public string GetName() {
      return Name;
    }
  }
  public class Air : Transport {
    private int[] DistanceReducer; //percent
    private int[] DistanceInterval;
    private bool Evenly;

    public Air(string name, int speed, int[] reducer, int[] interval, bool e) : base(name, speed) {
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
    public int[] GetDistanceReducer() {
      return DistanceReducer;
    }
    public int[] GetDistanceInterval() {
      return DistanceInterval;
    }
    public bool GetEvenly() {
      return Evenly;
    }
  }
  public class Land : Transport {
    private int RestInterval;
    private double[] RestDuration;

    public Land(string name, int speed, int interval, double[] duration) : base(name, speed) {
      RestInterval = interval;
      RestDuration = new double[duration.Length];
      for (int i = 0; i < duration.Length; i++) {
        RestDuration[i] = duration[i];
      }
    }
    public int GetRestInterval() {
      return RestInterval;
    }
    public double[] GetRestDuration() {
      return RestDuration;
    }
  }
}
