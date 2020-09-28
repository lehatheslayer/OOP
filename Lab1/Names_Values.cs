using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Lab1 {
  public struct Names_Values {
      private string name_;
      private string value_;
      public Names_Values(string name, string value) {
        name_ = name;
        value_ = value;
      }
      public string getName() {
        return name_;
      }
      public string getValue() {
        return value_;
      }
  }
}
