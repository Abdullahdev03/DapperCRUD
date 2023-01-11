namespace Domain.Models;

public class Order
{
  public Order()
  {
    
  }
  public int Id { get; set; }
  public int productid { get; set; }
  public int customerid { get; set; }
  public DateTime createdate { get; set; }
  public int productcount { get; set; }
  public int price { get; set; }

}