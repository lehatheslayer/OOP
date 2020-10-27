using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab2 {
  class Program {
    static void Main() {
      ShopManager markets = new ShopManager();

      markets.CreateShop("pyaterochka", "202");
      markets.CreateShop("katarina", "202");
      markets.CreateShop("pegas", "lenina");

      Console.WriteLine(markets.GetShop(0).GetName() + ":");
      markets.AddProductToShop(1400, 12, 0, 0);
      markets.AddProductToShop(1350, 4, 1, 0);
      markets.AddProductToShop(3000, 19, 2, 0);
      markets.AddProductToShop(5800, 1, 3, 0);
      markets.AddProductToShop(4600, 5, 4, 0);
      markets.WhatCanIBuyForThis(7500, 0);

      Console.WriteLine(markets.GetShop(1).GetName() + ":");
      markets.AddProductToShop(1750, 8, 0, 1);
      markets.AddProductToShop(510, 24, 5, 1);
      markets.AddProductToShop(155, 53, 6, 1);
      markets.AddProductToShop(450, 18, 7, 1);
      markets.AddProductToShop(2450, 9, 8, 1);
      markets.AddProductToShop(4200, 7, 9, 1);
      markets.WhatCanIBuyForThis(5000, 1);

      Console.WriteLine(markets.GetShop(2).GetName() + ":");
      markets.AddProductToShop(1100, 16, 0, 2);
      markets.AddProductToShop(2250, 7, 10, 2);
      markets.AddProductToShop(490, 31, 5, 2);
      markets.AddProductToShop(3900, 2, 9, 2);
      markets.AddProductToShop(6100, 2, 3, 2);
      markets.AddProductToShop(3200, 9, 2, 2);
      markets.WhatCanIBuyForThis(3000, 2);

      Console.WriteLine("");
      markets.GetCheapestProduct(0);

      Console.WriteLine("");
      Pair<int, int>[] goods;
      goods = new Pair<int, int>[3]; //товар-количество
      for (int i = 0; i < 3; i++) {
        goods[i] = new Pair<int, int>();
        goods[i].First = i;
        goods[i].Second = 4 + i * 5;
      }
      markets.TheCheapestNumberOfGoods(goods);

      Console.WriteLine("");
      markets.GetShop(0).GetProductInfo(0);

      Console.WriteLine("");
      markets.GetShop(0).BuyProduct(9, 0);

      Console.WriteLine("");
      markets.GetShop(0).GetProductInfo(0);
    }
  }
}
