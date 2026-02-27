using SieMarket.Models;
using SieMarket.Services;

var order1 = new Order(1, "Ion Popescu");
order1.Items.Add(new OrderItem("Laptop", 1, 450m));
order1.Items.Add(new OrderItem("Mouse", 2, 50m));

var order2 = new Order(2, "Maria Ionescu");
order2.Items.Add(new OrderItem("Laptop", 1, 450m));

var orders = new List<Order> { order1, order2 };

// test 2.2 
// output: 495.00 (laptop 450 + mouse 2×50 = 550, discount 10% => 495)
Console.WriteLine(order1.CalculateFinalPrice());

// test 2.3
// output: Ion Popescu
Console.WriteLine(OrderService.GetTopSpendingCustomer(orders));

// test 2.4
// output: Laptop: 2, Mouse: 2
var popular = OrderService.GetPopularProducts(orders);
foreach (var p in popular)
    Console.WriteLine($"{p.Key}: {p.Value}");