using System.Collections.Generic;
using Dapper;
using Domain.Models;
using Npgsql;

namespace Infrastructure.Services;
public class OrderService
{
  private string _connectionString = "Server=127.0.0.1;Port=5432;Database=DapperCRUD;User Id=postgres;Password=22385564;";

  public List<Order> GetOrder()
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = "SELECT * FROM orders";
      var result = connection.Query<Order>(sql);
      return result.ToList();
    }
  }
  public bool AddOrder(Order order)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"INSERT INTO orders (productid,customerid,createdate,price)" +
      $" VALUES ('{order.productid}', '{order.customerid}','{order.createdate}','{order.price}')";
      var insert = connection.Execute(sql);
      if (insert > 0) return true;
      else return false;
    }
  }
  public bool UpdateOrder(Order order)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"update orders set productid ='{order.productid}', customerid = '{order.customerid}',productcount = '{order.productcount}', createdate='{order.createdate}', price = '{order.price}' where id = '{order.Id}'";
      var update = connection.Execute(sql);
      if (update > 0) return true;
      else return false;
    }
  }
  public bool DeleteOrder(int Id)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"delete from orders where id = {Id}";
      var delete = connection.Execute(sql);
      if (delete > 0) return true;
      else return false;
    }
  }
}  