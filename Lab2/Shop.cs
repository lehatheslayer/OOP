using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab2 {
  public class Shop {
    private string name_;
    private string address_;
    private Dictionary<int, Product> product = new Dictionary<int, Product>();
    public Shop() {}

    public Shop(string name, string address) {
      name_ = name;
      address_ = address;
    }

    public void AddProduct(int cost, int quanity, int id, ProductManager product) {
      if (!this.GetProducts().ContainsKey(id)) {
        Product sub = new Product(product.GetProduct()[id].GetName(), quanity, cost);
        this.GetProducts().Add(id, sub);
      }
      else {
        this.GetProducts()[id].IncreaseQuanity(quanity);
        if (this.GetProducts()[id].GetCost() != cost) {
          this.GetProducts()[id].SetCost(cost);
        }
      }
    }

    public void ChangeCost(int key, int cost) {
      product[key].SetCost(cost);
    }

    public void GetProductInfo(int key) {
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

    public void BuyProduct(int quanity, int productKey) {
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
      product[productKey].IncreaseQuanity(quanity * (-1));
      Console.WriteLine("Вы успешно приобрели " + quanity + " единиц товара " + product[productKey].GetName());
    }

    public Dictionary<int, Product> GetProducts() {
      return product;
    }

    public string GetName() {
      return name_;
    }
  }
}
