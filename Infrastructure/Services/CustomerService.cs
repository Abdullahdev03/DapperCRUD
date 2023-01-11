using System.Collections.Generic;
using Dapper;
using Domain.Models;
using Npgsql;

namespace Infrastructure.Services;
public class CustomerService
{
  private string _connectionString = "Server=127.0.0.1;Port=5432;Database=DapperCRUD;User Id=postgres;Password=22385564;";

  public List<Customer> GetCustomer()
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = "SELECT * FROM customers";
      var result = connection.Query<Customer>(sql);
      return result.ToList();
    }
  }
  public bool AddCustomer(Customer customer)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"INSERT INTO customers (Id,Firstname)" +
      $" VALUES ('{customer.Id}','{customer.Firstname}')";
      var insert = connection.Execute(sql);
      if (insert > 0) return true;
      else return false;
    }
  }
  public bool UpdateCustomer(Customer customer)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"update customers set firstname ='{customer.Firstname}'  where id = '{customer.Id}'";
      var update = connection.Execute(sql);
      if (update > 0) return true;
      else return false;
    }
  }
  public bool DeleteCustomer(int Id)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"delete from customers where id = {Id}";
      var delete = connection.Execute(sql);
      if (delete > 0) return true;
      else return false;
    }
  }
}  