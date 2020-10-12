using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab2 {
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
    public Dictionary<string, Shop> GetShops() {
      return shops;
    }
    public Shop GetShop(string key) {
      return shops[key];
    }
  }
}
