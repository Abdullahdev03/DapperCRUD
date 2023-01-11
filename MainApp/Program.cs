using Domain.Models;
using Infrastructure.Services;

var productService = new ProductService();
var customerService = new CustomerService();
var orderService = new OrderService();


System.Console.WriteLine("Enter an operator product/order/customer");
while (true)
{
  string option = Console.ReadLine();
  if (option == "stop") break;

  _ = option switch
  {
    "product" => Product(),
    "order" => Order(),
    "customer" => Customer(),
    _ => false,
  };
}
bool Product()
{
  System.Console.WriteLine("Enter an operator show/add/delete/update");
  while (true)
  {
    string option = Console.ReadLine();
    if (option == "stop") break;

    _ = option switch
    {
      "add" => Add(),
      "update" => Update(),
      "delete" => Delete(1),
      "show" => Show(),
      _ => false,
    };
  }
  bool Add()
  {
    var st = new Product()
    {
      productname = "Galaxy note 20",
      company = "Samsung",
      productcount = 3000,
      price = 1000
    };
    productService.AddProduct(st);
    return true;
  }
  bool Update()
  {
    var st = new Product()
    {
      productname = "Galaxy note 21 ultra",
      company = "Samsung",
      productcount = 500,
      price = 1500,
      Id = 4
    };
    var result = productService.UpdateProduct(st);
    if (result) System.Console.WriteLine("Updated");
    else System.Console.WriteLine("Not founded");
    return true;
  }
  bool Delete(int id)
  {
    productService.DeleteProduct(id);
    return true;
  }
  bool Show()
  {
    var allcountry = productService.GetProduct();
    foreach (var cr in allcountry)
    {
      System.Console.WriteLine($"ID = {cr.Id} ProductName= {cr.productname} Company = {cr.company} productcount = {cr.productcount} price = {cr.price}");
    }
    return true;
  }
  return true;
}
bool Customer()
{
  System.Console.WriteLine("Enter an operator show/add/delete/update");
  while (true)
  {
    string option = Console.ReadLine();
    if (option == "stop") break;

    _ = option switch
    {
      "add" => Add(),
      "update" => Update(),
      "delete" => Delete(1),
      "show" => Show(),
      _ => false,
    };
  }
  bool Add()
  {
    var st = new Customer()
    {
      Id = 8,
      Firstname = "Abdulloh1"
    };
    customerService.AddCustomer(st);
    return true;
  }
  bool Update()
  {
    var st = new Customer()
    {
      Firstname = "Muhammad",
      Id = 1
    };
    var result = customerService.UpdateCustomer(st);
    if (result) System.Console.WriteLine("Updated");
    else System.Console.WriteLine("Not founded");
    return true;
  }
  bool Delete(int id)
  {
    customerService.DeleteCustomer(id);
    return true;
  }
  bool Show()
  {
    var allcountry = customerService.GetCustomer();
    foreach (var cr in allcountry)
    {
      System.Console.WriteLine($"ID = {cr.Id} Firstname= {cr.Firstname} ");
    }
    return true;
  }
  return true;
}
bool Order()
{
  System.Console.WriteLine("Enter an operator show/add/delete/update");
  while (true)
  {
    string option = Console.ReadLine();
    if (option == "stop") break;

    _ = option switch
    {
      "Add" => Add(),
      "Update" => Update(),
      "Delete" => Delete(1),
      "Show" => Show(),
      _ => false,
    };
  }
  bool Add()
  {
    var st = new Order()
    {
      productid = 1,
      customerid = 1,
      createdate = DateTime.Now,
      price = 5000
    };
    orderService.AddOrder(st);
    return true;
  }
  bool Update()
  {
    var st = new Order()
    {
      productid = 2,
      customerid = 2,
      createdate = DateTime.Now,
      price = 2000,
      Id = 5
    };
    var result = orderService.UpdateOrder(st);
    if (result) System.Console.WriteLine("Updated");
    else System.Console.WriteLine("Not founded");
    return true;
  }
  bool Delete(int id)
  {
    orderService.DeleteOrder(id);
    return true;
  }
  bool Show()
  {
    var allcountry = orderService.GetOrder();
    foreach (var cr in allcountry)
    {
      System.Console.WriteLine($"ID = {cr.Id} productid= {cr.productid} customerid = {cr.customerid} createdate = {cr.createdate} price = {cr.price}");
    }
    return true;
  }
  return true;
}
