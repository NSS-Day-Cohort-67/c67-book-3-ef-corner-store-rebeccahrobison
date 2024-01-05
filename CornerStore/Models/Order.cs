
using System.ComponentModel.DataAnnotations;

namespace CornerStore.Models;

public class Order
{
  public int Id { get; set; }
  [Required]
  public int CashierId { get; set; }
  public List<OrderProduct> OrderProducts { get; set; }
  public decimal Total
  {
    get
    {
      // Sum of product prices * quantity in OrderProduct
      if (OrderProducts == null)
      {
        return 0;
      }

      decimal total = 0;
      foreach (var orderProduct in OrderProducts)
      {
        var product = orderProduct.Product;
        if (product != null)
        {
          total += product.Price * orderProduct.Quantity;
        }
      }
      return total;

      // LINQ method option
      // return OrderProducts.Sum(orderProduct =>
      //       {
      //           var product = orderProduct.Products?.FirstOrDefault();
      //           return product != null ? product.Price * orderProduct.Quantity : 0;
      //       });
    }
  }
  public DateTime? PaidOnDate { get; set; }
  public Cashier Cashier { get; set; }
}
