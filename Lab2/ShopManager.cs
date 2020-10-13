using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab2 {
  public class Pair<T, K> {
		public T First{ get; set; }
    public K Second{ get; set; }
	}

  public class ShopManager {
    private Dictionary<string, Shop> shops = new Dictionary<string, Shop>();

    public ShopManager() { }

    public void CreateShop(string key, string name, string address) {
      try {
        if (shops.ContainsKey(key)) {
          throw new Exception("Такой магазин уже существует");
        }
      }
      catch(Exception e) {
        Console.WriteLine($"{e.Message}");
        return;
      }
      Shop sub = new Shop(name, address);
      shops.Add(key, sub);
    }

    public string GetCheapestProduct(string productKey) {
      int minCost = 999999;
      if (this.GetShops().Count == 0) {
        Console.WriteLine("Нет магазинов");
        return default;
      }
      KeyValuePair<string, Shop> s = new KeyValuePair<string, Shop>();
      foreach (KeyValuePair<string, Shop> shop in this.GetShops()) {
        try {
          if (!shop.Value.GetProducts().ContainsKey(productKey)) {
            throw new Exception();
          }
        }
        catch (Exception) {
          continue;
        }
        Console.WriteLine(shop.Key + " " + shop.Value.GetName());
        if (shop.Value.GetProducts()[productKey].GetCost() < minCost) {
          minCost = shop.Value.GetProducts()[productKey].GetCost();
          s = shop;
        }
      }
      if (s.Key != null) {
        Console.WriteLine("Самый дешевый " + s.Value.GetProducts()[productKey].GetName() + " в магазине " + s.Value.GetName() + " со стоимостью " + minCost);
        return s.Key;
      }
      Console.WriteLine("В магазинах нет товара " + productKey);
      return default;
    }

    public void WhatCanIBuyForThis(int money, string key) {
      try {
        if (this.GetShops().Count == 0) {
          throw new Exception("Нет такого магазина");
        }
      }
      catch(Exception e) {
        Console.WriteLine($"{e.Message}");
        return;
      }
      try {
        if (this.GetShops()[key].GetProducts().Count == 0) {
          throw new Exception("В магазине" + this.GetShops()[key].GetName() + " нечего покупать");
        }
      }
      catch(Exception e) {
        Console.WriteLine($"{e.Message}");
        return;
      }
      foreach (KeyValuePair<string, Product> product in this.GetShops()[key].GetProducts()) {
        Console.WriteLine("Можно купить " + money / product.Value.GetCost() + " " + product.Value.GetName() + " в магазине " + this.GetShops()[key].GetName());
      }
      return;
    }

    public void TheCheapestNumberOfGoods(Pair<string, int>[] goods) {
      for (int i = 0; i < goods.Length; i++) {
        //Console.WriteLine(goods[i].First + " " + goods[i].Second);
        int MinCost = 99999999;
        int n = -1;
        bool flag = false;
        Shop ShopId = new Shop();
        foreach (KeyValuePair<string, Shop> shop in this.GetShops()) {
          try {
            if (!shop.Value.GetProducts().ContainsKey(goods[i].First)) {
              throw new Exception ("В магазине " + shop.Value.GetName() + " нет(никогда не было) товара " + goods[i].First);
            }
            else if (shop.Value.GetProducts()[goods[i].First].GetQuanity() < goods[i].Second) {
              throw new Exception ("В магазине " + shop.Value.GetName() + " товаров " + shop.Value.GetProducts()[goods[i].First].GetName() + " меньше, чем " + goods[i].Second);
            }
          }
          catch (Exception e) {
            //Console.WriteLine($"{e.Message}");
            continue;
          }
          if (shop.Value.GetProducts()[goods[i].First].GetCost() * goods[i].Second < MinCost) {
            MinCost = shop.Value.GetProducts()[goods[i].First].GetCost() * goods[i].Second;
            ShopId = shop.Value;
            flag = true;
            n = i;
          }
        }
        if (flag) {
          Console.WriteLine("В магазине " + ShopId.GetName() + " дешевле всего купить " + goods[i].Second + " " + ShopId.GetProducts()[goods[i].First].GetName() + ", чем в других");
        } else {
          Console.WriteLine("Ни в одном магазине невозможно купить " + goods[i].Second + " штук продукта с ключом " + goods[i].First);
        }
      }
      return;
    }

    public Dictionary<string, Shop> GetShops() {
      return shops;
    }

    public void Menu() {
      while(true) {
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("Создать магазин - 1");
        Console.WriteLine("Завести партию товаров в магазин - 2");
        Console.WriteLine("Найти магазин, в ĸотором определенный товар самый дешевый - 3");
        Console.WriteLine("Понять, какие товары можно ĸупить в магазине на некоторую сумму - 4");
        Console.WriteLine("Купить партию товаров в магазине - 5");
        Console.WriteLine("Найти, в каком магазине партия товаров имеет наименьшую сумму - 6");
        Console.WriteLine("Exit, чтобы выйти");
        string ShopKey, ShopName, Address, ProductKey, ProductName, Cost, Quanity, Sum;
        switch (Console.ReadLine()) {
          case "1":
            //markets.CreateShop("id_1", "pyaterochka", "202");
            Console.WriteLine("Введите идентификатор, название и адрес магазина:");
            ShopKey = Console.ReadLine(); ShopName =  Console.ReadLine(); Address = Console.ReadLine();
            this.CreateShop(ShopKey, ShopName, Address);
            Console.WriteLine("Магазин успешно создан");
            //Console.WriteLine(this.GetShop(Key).GetName());
            break;
          case "2":
            //markets.GetShop("id_1").AddProduct("id_11", "vans oldskool", 4700, 12);
            Console.WriteLine("Введите идентификатор магазина, идентификатор, название, цену и количество продуктов:");
            ShopKey = Console.ReadLine(); ProductKey = Console.ReadLine(); ProductName =  Console.ReadLine(); Cost = Console.ReadLine(); Quanity = Console.ReadLine();
            try {
              if (!(this.GetShops().ContainsKey(ShopKey))) {
                throw new Exception("Нет такого магазина");
              }
            }
            catch (Exception e) {
              Console.WriteLine(e.Message);
              break;
            }
            this.GetShop(ShopKey).AddProduct(ProductKey, ProductName, Convert.ToInt32(Cost), Convert.ToInt32(Quanity));
            Console.WriteLine("Продукты успешно добавлены");
            break;
          case "3":
            //markets.GetCheapestProduct("id_12");
            Console.WriteLine("Введите идентификатор продукта:");
            ProductKey = Console.ReadLine();
            this.GetCheapestProduct(ProductKey);
            break;
          case "4":
            //markets.WhatCanIBuyForThis(52598, "id_1");
            Console.WriteLine("Введите сумму денег и идентификатор магазина:");
            Sum = Console.ReadLine(); ShopKey = Console.ReadLine();
            try {
              this.WhatCanIBuyForThis(Convert.ToInt32(Sum), ShopKey);
            }
            catch (System.FormatException) {
              Console.WriteLine("Введите число - сумму денег");
            }
            break;
          case "5":
            //markets.GetShop("id_1").BuyProduct(400, "id_14");
            Console.WriteLine("Введите идентификатор магазина, количество и идентификатор продукта:");
            ShopKey = Console.ReadLine(); Quanity = Console.ReadLine(); ProductKey = Console.ReadLine();
            try {
              if (!(this.GetShops().ContainsKey(ShopKey))) {
                throw new Exception("Нет такого магазина");
              }
            }
            catch (Exception e) {
              Console.WriteLine(e.Message);
              break;
            }
            try {
              this.GetShop(ShopKey).BuyProduct(Convert.ToInt32(Quanity), ProductKey);
            }
            catch (System.FormatException) {
              Console.WriteLine("Введите число - количество продуктов");
              break;
            }
            Console.WriteLine("Продукты успешно куплены");
            break;
          case "6":
            //markets.TheCheapestNumberOfGoods(goods);
            Console.WriteLine("Напишите количество пар идентификатор продукта - количество, а также сами пары:");
            Quanity = Console.ReadLine();
            Pair<string, int>[] goods;
            try {
              goods = new Pair<string, int>[Convert.ToInt32(Quanity)];
            }
            catch (System.FormatException) {
              Console.WriteLine("Нужно написать количество пар");
              break;
            }
            for (int i = 0; i < Convert.ToInt32(Quanity); i++) {
              goods[i] = new Pair<string, int>();
              goods[i].First = Console.ReadLine();
              goods[i].Second = Convert.ToInt32(Console.ReadLine());
            }
            this.TheCheapestNumberOfGoods(goods);
            break;
          case "exit":
            Console.WriteLine("Завершение программы с кодом выхода 0");
            Environment.Exit(0);
            break;
        }
      }
    }

    public Shop GetShop(string key) {
      return shops[key];
    }
  }
}
//идентификаторы, whatcanibuyforthis(определенный магазин)
