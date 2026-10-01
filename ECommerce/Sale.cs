using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ECommerce;

public class Sale
{
    public int Id { get; set; } = Random.Shared.Next();
    public int Num { get; set; }
    public string DocClient { get; set; } = string.Empty;
    public List<SaleDetail> PurchasedItems { get; set; } = new();
    public DateTime Date { get; set; } = DateTime.Now;
    [Ignore]
    public decimal Total { get; set; }
    public string Products { get; set; } = string.Empty;

    public Sale()
    {
        
    }
    public Sale(int num, string docCliente, List<SaleDetail> purchasedItems, decimal total)
    {
        Num = num;
        DocClient = docCliente;
        PurchasedItems = purchasedItems;
    }

    public void AddProduct(IProduct product, int quantity)
    {
        SaleDetail detail = new SaleDetail(product, quantity);
        PurchasedItems = PurchasedItems.Append(detail).ToList();

        // Cada vez que se agrega un producto, se actualizan el total y el texto
        Total = PurchasedItems.Sum(d => d.Subtotal);
        Products = string.Join(",", PurchasedItems.Select(p => $"{p.ProductName} x{p.Quantity}"));

        
    }

}
