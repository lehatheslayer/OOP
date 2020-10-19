using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab2 {
  class Program {
    static void Main() {
      ShopManager markets = new ShopManager();
      ProductManager products = new ProductManager();

      products.CreateProduct("Power Threads"); //0
      products.CreateProduct("Arcane boots"); //1
      products.CreateProduct("Reaper"); //2
      products.CreateProduct("Satanic"); //3
      products.CreateProduct("Manta Style"); //4
      products.CreateProduct("Bracers"); //5
      products.CreateProduct("Circlet"); //6
      products.CreateProduct("Boots of speed"); //7
      products.CreateProduct("Travel boots"); //8
      products.CreateProduct("Sange And Yasha"); //9
      products.CreateProduct("Blink dagger"); //10

      markets.CreateShop("pyaterochka", "202");
      markets.CreateShop("katarina", "202");
      markets.CreateShop("pegas", "lenina");

      Console.WriteLine(markets.GetShop(0).GetName() + ":");
      markets.GetShop(0).AddProduct(products.GetProduct(), 1400, 12, 0);
      markets.GetShop(0).AddProduct(products.GetProduct(), 1350, 4, 1);
      markets.GetShop(0).AddProduct(products.GetProduct(), 3000, 19, 2);
      markets.GetShop(0).AddProduct(products.GetProduct(), 5800, 1, 3);
      markets.GetShop(0).AddProduct(products.GetProduct(), 4600, 5, 4);
      //markets.GetCheapestProduct(0);
      markets.WhatCanIBuyForThis(7500, 0);

      Console.WriteLine(markets.GetShop(1).GetName() + ":");
      markets.GetShop(1).AddProduct(products.GetProduct(), 1750, 8, 0);
      markets.GetShop(1).AddProduct(products.GetProduct(), 510, 24, 5);
      markets.GetShop(1).AddProduct(products.GetProduct(), 155, 53, 6);
      markets.GetShop(1).AddProduct(products.GetProduct(), 450, 18, 7);
      markets.GetShop(1).AddProduct(products.GetProduct(), 2450, 9, 8);
      markets.GetShop(1).AddProduct(products.GetProduct(), 4200, 7, 9);
      markets.WhatCanIBuyForThis(5000, 1);

      Console.WriteLine(markets.GetShop(2).GetName() + ":");
      markets.GetShop(2).AddProduct(products.GetProduct(), 1100, 16, 0);
      markets.GetShop(2).AddProduct(products.GetProduct(), 2250, 7, 10);
      markets.GetShop(2).AddProduct(products.GetProduct(), 490, 31, 5);
      markets.GetShop(2).AddProduct(products.GetProduct(), 3900, 2, 9);
      markets.GetShop(2).AddProduct(products.GetProduct(), 6100, 2, 3);
      markets.GetShop(2).AddProduct(products.GetProduct(), 3200, 9, 2);
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
      // markets.Menu();

      Console.WriteLine("");
      markets.GetShop(0).GetProductInfo(0);

      Console.WriteLine("");
      markets.GetShop(0).BuyProduct(9, 0);

      Console.WriteLine("");
      markets.GetShop(0).GetProductInfo(0);
    }
  }
}
