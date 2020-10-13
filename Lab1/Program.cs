using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab1 {
  class Program {
    static void FileErrors(string iniFile) {
      try {
        string[] words = iniFile.Split(new char[] { '.' }); //+=[]:;«,/?'пробел
        if (Regex.IsMatch(words[0], @"[^a-zA-Z0-9_]")) {
          Console.WriteLine(words[0]);
          throw new FileException("Error: invalid chars found");
        }
        if (words.Length == 1) {
          throw new FileException("Error: your file doesn't have the extension");
        }
        if (words[1] != "ini") {
          throw new FileException("Error: wrong file extension");
        }
        if (!System.IO.File.Exists(iniFile)) {
          throw new FileException("Error: there isn't this file in the current directory");
        }
      }
      catch (FileException e){
        Console.WriteLine($"{e.Message}");
        return;
      }
      File myFile = new File(iniFile);
      myFile.menu();
    }
    static void Exit() {
      Environment.Exit(0);
    }
    static void Main() {
      while (true) {
        Console.WriteLine("Введите название ini файла или exit, чтобы выйти");
        string iniFile = Console.ReadLine();
        if (iniFile == "exit") {
          Program.Exit();
        }
        Program.FileErrors(iniFile);
      }
    }
  }
}
