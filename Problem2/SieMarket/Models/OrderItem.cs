namespace SieMarket.Models;

// 2.1
public class OrderItem{

    public string ProductName {get; set;}
    public int Quantity {get; set;}
    public decimal UnitPrice {get; set;}

    public OrderItem (string productName, int quantity, decimal unitPrice){
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}