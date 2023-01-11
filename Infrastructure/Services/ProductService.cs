using System.Collections.Generic;
using Dapper;
using Domain.Models;
using Npgsql;

namespace Infrastructure.Services;
public class ProductService
{
  private string _connectionString = "Server=127.0.0.1;Port=5432;Database=DapperCRUD;User Id=postgres;Password=22385564;";

  public List<Product> GetProduct()
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = "SELECT * FROM products";
      var result = connection.Query<Product>(sql);
      return result.ToList();
    }
  }
  public bool AddProduct(Product product)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"INSERT INTO products (productname, company,productcount,price)" +
      $" VALUES ('{product.productname}', '{product.company}','{product.productcount}','{product.price}')";
      var insert = connection.Execute(sql);
      if (insert > 0) return true;
      else return false;
    }
  }
  public bool UpdateProduct(Product product)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"update products set productname='{product.productname}', company = '{product.company}', productcount ='{product.productcount}', price = '{product.price}' where id = '{product.Id}'";
      var update = connection.Execute(sql);
      if (update > 0) return true;
      else return false;
    }
  }
  public bool DeleteProduct(int Id)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"delete from products where id = {Id}";
      var delete = connection.Execute(sql);
      if (delete > 0) return true;
      else return false;
    }
  }
}  