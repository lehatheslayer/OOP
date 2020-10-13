using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab2 {
  class Program {
    static void Main() {
      ShopManager markets = new ShopManager();
      markets.CreateShop("id_1", "pyaterochka", "202");
      markets.CreateShop("id_2", "katarina", "202");
      markets.CreateShop("id_3", "pegas", "lenina");
      markets.GetShop("id_1").AddProduct("id_11", "vans oldskool", 4700, 12);
      markets.GetShop("id_1").AddProduct("id_12", "nike AirMax", 3700, 4);
      markets.GetShop("id_1").AddProduct("id_13", "Картошкаблин", 90, 200);
      markets.GetShop("id_1").GetProductInfo("id_13");
      markets.GetShop("id_2").AddProduct("id_11", "vans oldscool", 3900, 7);
      markets.GetShop("id_2").GetProductInfo("id_11");
      markets.GetShop("id_3").AddProduct("id_11", "vans OldSkool", 5500, 24);
      markets.GetShop("id_3").GetProductInfo("id_11");
      markets.GetCheapestProduct("id_12");
      markets.WhatCanIBuyForThis(52598, "id_1");
      try {
        markets.GetShop("id_1").BuyProduct(400, "id_14");
      }
      catch(Exception) {
        Console.WriteLine("pizdec");
      }
      Pair<string, int>[] goods = new Pair<string, int>[3];
      goods[0] = new Pair<string, int>(); goods[1] = new Pair<string, int>(); goods[2] = new Pair<string, int>();
      goods[0].First = "id_11"; goods[1].First = "id_12"; goods[2].First = "id_13";
      goods[0].Second = 4; goods[1].Second = 12; goods[2].Second = 50;
      markets.TheCheapestNumberOfGoods(goods);
    }
  }
}
