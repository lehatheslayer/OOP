using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Lab1 {
  class Program {
    static void Main() {
      Console.WriteLine("Write the name of ini file: ");
      string iniFile = Console.ReadLine();
      File myFile = new File(iniFile);
      //Console.WriteLine(myFile.section[10].getLength());
      myFile.GetValue<double>("AD_DEV", "BufferLenSeconds");
      myFile.GetValue<Boolean>("ADC_DEV", "BufferLenSeconds");
      myFile.GetValue<double>("ADC_DEV", "BufferLenSeconds");
    }
  }
}
