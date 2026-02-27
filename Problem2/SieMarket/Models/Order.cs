namespace SieMarket.Models;

// 2.1
public class Order{

    public int OrderId {get; set;}
    public string CustomerName {get; set;}
    public List<OrderItem> Items {get; set;}

    public Order (int orderId, string customerName){
        OrderId = orderId;
        CustomerName = customerName;
        Items = new List<OrderItem>();
    }

    // 2.2
    public decimal CalculateFinalPrice(){
        decimal total = 0;
        foreach (var item in Items){
            total += item.Quantity * item.UnitPrice;
        }
        if (total > 500){
            total *= 0.90m;
        }
        return total;
    }
}