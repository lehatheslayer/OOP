using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab1 {
  public class File {
    private Dictionary<string, Dictionary<string, string>> block = new Dictionary<string, Dictionary<string, string>>();
    public File(string iniFile){
      StreamReader fs = new StreamReader(iniFile);
      string s = fs.ReadLine();
      string sectionName = "";
      while (s != null) {
        s = s.Split(';')[0];
        if (s == "") {
          s = fs.ReadLine();
          continue;
        }
        if (s[0] == '[' && s[s.Length - 1] == ']') {
          sectionName = s.Trim(new char[] { '[', ']' });
          try {
            if (Regex.IsMatch(sectionName, @"[^a-zA-Z0-9_]")) {
              throw new WrongNameException("Error: неправильное название секции");
            }
          }
          catch(WrongNameException e) {
            Console.WriteLine($"{e.Message}");
            Environment.Exit(-1);
          }
          block.Add(sectionName, new Dictionary<string, string>());
        }
        else if (s != ""){
          try {
            if (!Regex.IsMatch(s, "[0-9a-zA-Z_]+ = [0-9a-zA-Z_/\\.]+ *(;.*)?$") || sectionName == "") {
              throw new WrongNameException("Error: поврежденный ini-файл");
            }
          }
          catch(WrongNameException e) {
            Console.WriteLine($"{e.Message}");
            Environment.Exit(-1);
          }
          string[] words = s.Split(new char[] { '=' });

          words[0] = words[0].TrimEnd();
          words[1] = words[1].TrimStart();
          if (block[sectionName].ContainsKey(words[0])) {
            block[sectionName][words[0]] = words[1];
          }
          else {
            block[sectionName].Add(words[0], words[1]);
          }
        }
        s = fs.ReadLine();
      }
    }

    public T GetValue<T>(string sectionName, string name) {
      try {
        return (T) Convert.ChangeType(block[sectionName][name], typeof(T));
      }
      catch(System.FormatException) {
        Console.WriteLine($"Error: нет такого объекта или значения: {sectionName}, {name}");
      }
      catch(System.Collections.Generic.KeyNotFoundException) {
        Console.WriteLine($"Error: нет такого объекта или значения: {sectionName}, {name}");
      }
      return default(T);
    }

    public void menu() {
      while (true) {
        Console.WriteLine("Введите название секции или exit, чтобы выйти:");
        string section = Console.ReadLine();
        this.Exit(section);
        Console.WriteLine("Введите название поля или exit, чтобы выйти:");
        string field = Console.ReadLine();
        this.Exit(field);
        Console.WriteLine("Введите тип данных (string, int, float, double) или exit, чтобы выйти:");
        string t = Console.ReadLine();
        this.Exit(t);
        try {
          if (t != "string" && t != "int" && t != "float" && t != "double") {
              throw new TypeException($"Error: wrong type: {t}");
          }
        }
        catch (TypeException e) {
          Console.WriteLine($"{e.Message}");
          continue;
        }
        if (t == "string" && this.GetValue<string>(section, field) != default) {
          Console.WriteLine(this.GetValue<string>(section, field));
        }
        if (t == "int" && this.GetValue<int>(section, field) != default) {
          Console.WriteLine(this.GetValue<int>(section, field));
        }
        if (t == "float" && this.GetValue<float>(section, field) != default) {
          Console.WriteLine(this.GetValue<float>(section, field));
        }
        if (t == "double" && this.GetValue<double>(section, field) != default) {
          Console.WriteLine(this.GetValue<double>(section, field));
        }
      }
    }

    public void Exit(string txt) {
      if (txt == "exit")
        Environment.Exit(0);
    }
  }
}
