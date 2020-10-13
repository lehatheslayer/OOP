using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab2{
  public class Product {
    private string name_;
    private int quanity_;
    private int cost_;

    public Product() { }

    public Product(string name, int quanity, int cost) {
      name_ = name;
      quanity_ = quanity;
      cost_ = cost;
    }

    public string GetName() {
      return name_;
    }

    public int GetQuanity() {
      return quanity_;
    }

    public int GetCost() {
      return cost_;
    }

    public void SetCost(int cost) {
      cost_ = cost;
    }

    public void IncreaseQuanity(int quanity) {
      quanity_ += quanity;
    }
    
    public void DecreaseQuanity(int quanity) {
      quanity_ -= quanity;
    }
  }
}
