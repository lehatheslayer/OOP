using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Lab1 {
  public class Section {
     private string section_;
     private int length;
     private Names_Values[] info;
     public Section(string section, ref List<string> name, ref List<string> value) {
       section_ = section;
       length = name.Count;
       info = new Names_Values[length];
       for (int i = 0; i < length; i++) {
         info[i] = new Names_Values(name[i], value[i]);
       }
     }
     public string getSection() {
       return section_;
     }
     public int getLength() {
       return length;
     }
     public string getValue(string name) {
       for (int i = 0; i < this.getLength(); i++) {
         if (info[i].getName() ==  name)
           return info[i].getValue();
       }
       string error = "There isn't the name ";
       return error + name;
     }
  }
}
