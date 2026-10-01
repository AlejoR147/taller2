using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce;

public class Sale
{
    public int Id { get; set; } = Random.Shared.Next();
    public string DocClient { get; set; } = string.Empty;
    public List<SaleDetail> PurchasedItems { get; set; } = new();
    public DateTime date { get; set; } = DateTime.Now;
    public decimal Total => PurchasedItems.Sum(i => i.Subtotal);

    public Sale()
    {
        
    }

    public Sale(string docCliente, IProduct product, int quantity)
    {
        DocClient = docCliente;
        AddProduct(product, quantity);
    }

    public void AddProduct(IProduct product, int quantity)
    {
        PurchasedItems = PurchasedItems.Append(new SaleDetail(product, quantity)).ToList();
        //retornar algo? paradigma funcional creo
    }
}
