using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab2 {
  public class Product {
    private string name_;
    private int quanity_;
    private int cost_;
    public Product() { }
    public Product(string name, int quanity, int cost) {
      name_ = name;
      quanity_ = quanity;
      cost_ = cost;
    }
    public string GetName() {
      return name_;
    }
    public int GetQuanity() {
      return quanity_;
    }
    public int GetCost() {
      return cost_;
    }
    public void SetCost(int cost) {
      cost_ = cost;
    }
    public void IncreaseQuanity(int quanity) {
      quanity_ += quanity;
    }
    public void DecreaseQuanity(int quanity) {
      quanity_ -= quanity;
    }
  }
  public class Shop {
    private string name_;
    private string address_;
    private Dictionary<string, Product> product = new Dictionary<string, Product>();
    public Shop() { }
    public Shop(string name, string address) {
      name_ = name;
      address_ = address;
    }
    public void AddProduct(string key, string name, int cost, int quanity) {
      if (!product.ContainsKey(key)) {
        Product sub = new Product(name, quanity, cost);
        product.Add(key, sub);
      }
      else {
        product[key].IncreaseQuanity(quanity);
        if (product[key].GetCost() != cost) {
          product[key].SetCost(cost);
        }
      }
    }
    public void ChangeCost(string key, int cost) {
      product[key].SetCost(cost);
    }
    public void GetProductInfo(string key) {
      try {
        if (!this.GetProducts().ContainsKey(key)) {
          throw new Exception("Такого товара в магазине " + this.GetName() +" нет");
        }
      }
      catch (Exception e) {
        Console.WriteLine($"{e.Message}");
        return;
      }

      Console.WriteLine("Информация продукта " + product[key].GetName() + " in shop " + this.GetName() + ":");
      Console.WriteLine("Имя: " + product[key].GetName());
      Console.WriteLine("Цена: " + product[key].GetCost());
      Console.WriteLine("Количество: " + product[key].GetQuanity());
    }
    public void BuyProduct(int quanity, string productKey) {
      try {
        if (!product.ContainsKey(productKey)) {
          throw new Exception ("В магазине " + this.GetName() + " нет товара " + productKey);
        }
      }
      catch (Exception e) {
        Console.WriteLine($"{e.Message}");
        return;
      }
      if (quanity > product[productKey].GetQuanity()) {
        Console.WriteLine("Количество товаров " + product[productKey].GetName() + " меньше, чем количество, которое вы хотите купить");
        return;
      }
      product[productKey].IncreaseQuanity(quanity);
      Console.WriteLine("Вы успешно приобрели " + quanity + " единиц товара " + product[productKey].GetName());
    }
    public Dictionary<string, Product> GetProducts() {
      return product;
    }
    public string GetName() {
      return name_;
    }
  }
  public class AllShops {
    private Dictionary<string, Shop> shops = new Dictionary<string, Shop>();
    public AllShops() { }
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
