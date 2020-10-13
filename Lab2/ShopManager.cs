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
    public Shop GetShop(string key) {
      return shops[key];
    }
  }
}
