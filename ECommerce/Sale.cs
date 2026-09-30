using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce;

public class Sale
{
    public int Id { get; set; } = Random.Shared.Next();
    public int Num { get; set; }
    public string DocClient { get; set; } = string.Empty;
    public List<SaleDetail> PurchasedItems { get; set; } = new();
    public DateTime date;
    public decimal Total => PurchasedItems.Sum(i => i.Subtotal);

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
        PurchasedItems = PurchasedItems.Append(new SaleDetail(product, quantity)).ToList();
        //retornar algo? paradigma funcional creo
    }
}
