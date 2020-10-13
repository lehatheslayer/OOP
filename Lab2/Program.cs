using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab2 {
  class Program {
    static void ShopErrors() {
      return;
    }
    static void Main() {
      ShopManager markets = new ShopManager();
      markets.CreateShop("id_1", "pyaterochka", "202");
      markets.CreateShop("id_2", "katarina", "202");
      markets.CreateShop("id_3", "pegas", "lenina");
      markets.GetShop("id_1").AddProduct("id_11", "vans oldskool", 4700, 12);
      markets.GetShop("id_1").AddProduct("id_12", "nike AirMax", 3700, 4);
      markets.GetShop("id_1").AddProduct("id_13", "Картошкаблин", 90, 200);
      markets.GetShop("id_2").AddProduct("id_11", "vans oldscool", 3900, 7);
      markets.GetShop("id_3").AddProduct("id_11", "vans OldSkool", 5500, 24);
      markets.Menu();
    }
  }
}
