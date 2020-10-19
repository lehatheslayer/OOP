using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab2 {
  public class ProductManager {
    private Dictionary<int, Product> product = new Dictionary<int, Product>();
    private int ProductIds = 0;

    public ProductManager() { }

    public void CreateProduct(string name) {
      Product sub = new Product(name, 0, 0);
      product.Add(ProductIds, sub);
      IncreaseProductId();
    }

    public int IncreaseProductId() {
      ProductIds += 1;
      return ProductIds;
    }

    public Dictionary<int, Product> GetProduct() {
      return product;
    }
  }
}
