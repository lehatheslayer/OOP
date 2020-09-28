using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Lab1 {
  public class File {
    private List<Section> section = new List<Section>();
    private List<string> sectionName_ = new List<string>();
    public File(string iniFile){
      iniFile = "/Users/tatanaresetnikova/Documents/GitHub/OOP/Lab1/" + iniFile;
      try {
        string[] words = iniFile.Split(new char[] { '.' });
        if (words[1] != "ini") {
          throw new FileException("Error: wrong file extension");
        }
        if (!System.IO.File.Exists(iniFile)) {
          throw new FileException("Error: there isn't this file in the current directory");
        }
      }
      catch (FileException e){
        Console.WriteLine($"{e.Message}");
        Environment.Exit(-1);
      }
      StreamReader fs = new StreamReader(iniFile);
      string s = fs.ReadLine(); //Чтение файла
      string sect; //Здесь будет хранится название секции
      List<string> name = new List<string>(), value = new List<string>(); //Тута будут списки названий имен и значений
      while (s != null) { //Цикл где происходит парсинг файла
        if (s == "") { continue; }
        if (s[0] == '[') {
          sect = s.Trim(new char[] {'[', ']'});
          sectionName_.Add(sect);
          while (s != null) {
            s = fs.ReadLine();
            if (s == null) { break; }
            if (s == "") { continue; }
            if (s[0] == ';') { continue; }
            if (s[0] == '[') {
              section.Add(new Section(sect, ref name, ref value));
              break;
            }
            else {
              if (s.IndexOf(';') != -1) {
                s = s.Substring(0, s.IndexOf(';'));
              }
              if (s.IndexOf(';') == -1) {
                string[] words = s.Split(new char[] { '=' });
                words[0] = words[0].TrimEnd();
                words[1] = words[1].TrimStart();
                name.Add(words[0]);
                value.Add(words[1]);
              }
            }
          }
        }
      }
    }
    public T GetValue<T>(string sectionName, string name) {
      var number = -1;
      for (int i = 0; i < section.Count; i++) {
        if (sectionName == sectionName_[i]){
          number = i;
          break;
        }
      }
      try {
        return (T) Convert.ChangeType(section[number].getValue(name), typeof(T));
      }
      catch(System.ArgumentOutOfRangeException e) {
        Console.WriteLine($"Error: there isn't section or field: {sectionName}, {name}");
      }
      catch(System.FormatException e) {
        Console.WriteLine($"Error: wrong type: {typeof(T)}");
      }
      return default(T);
      //return (T) Convert.ChangeType(section[number].getValue(name), typeof(T));
    }
  }
}
