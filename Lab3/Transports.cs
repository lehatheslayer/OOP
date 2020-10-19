using System;

namespace Lab3 {
  public abstract class Transport {
    private int Speed;
    private string Name;
    private int Type;

    public Transport (string name, int speed, int type) {
      Name = name;
      Speed = speed;
      Type = type;
    }
    public int GetSpeed() {
      return Speed;
    }
    public string GetName() {
      return Name;
    }
    new public int GetType() {
      return Type;
    }
  }
  public class Air : Transport {
    private int DistanceReducer;

    public Air(string name, int speed, int type, int reducer) : base(name, speed, type) {
      DistanceReducer = reducer;
    }
    public int GetDistanceReducer() {
      return DistanceReducer;
    }
  }
  public class Land : Transport {
    private int RestInterval;
    private int RestDuration;

    public Land(string name, int speed, int type, int interval, int duration) : base(name, speed, type) {
      RestInterval = interval;
      RestDuration = duration;
    }
    public int GetRestInterval() {
      return RestInterval;
    }
    public int GetRestDuration() {
      return RestDuration;
    }
  }
}
