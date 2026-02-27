using SieMarket.Models;
namespace SieMarket.Services;

public static class OrderService{

    // 2.3
    public static string GetTopSpendingCustomer(List<Order> orders){
        Dictionary<string, decimal> customerTotals = new Dictionary<string, decimal>();

        foreach(var order in orders){
            decimal finalPrice = order.CalculateFinalPrice();

            if (customerTotals.ContainsKey(order.CustomerName)){
                customerTotals[order.CustomerName] += finalPrice;
            }
            else {
                customerTotals[order.CustomerName] = finalPrice;
            }
        }

        string topCustomer = null;
        decimal maxSpent = 0;

        foreach (var entry in customerTotals){
            if (entry.Value > maxSpent){
                maxSpent = entry.Value;
                topCustomer = entry.Key;
            }
        }

        return topCustomer;
    }

    // 2.4
    public static Dictionary<string, int> GetPopularProducts(List<Order> orders){
        Dictionary<string, int> productQuantities = new Dictionary<string, int>();

        foreach (var order in orders){
            foreach (var item in order.Items){
                if (productQuantities.ContainsKey(item.ProductName)){
                    productQuantities[item.ProductName] += item.Quantity;
                }
                else {
                    productQuantities[item.ProductName] = item.Quantity;
                }
            }
        }

        return productQuantities
            .OrderByDescending(x => x.Value)
            .ToDictionary(x => x.Key, x => x.Value);
    }
}