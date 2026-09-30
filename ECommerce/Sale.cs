using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce;

public class Sale
{
    public int Id { get; set; }
    public int Num { get; set; }
    public string DocClient { get; set; } = "";
    public List<SaleDetail> PurchasedItems { get; set; } = new();
    public DateTime date;
    public decimal Total => PurchasedItems.Sum(i => i.Subtotal);


    public Sale(int num, string docCliente, List<SaleDetail> purchasedItems, decimal total)
    {
        Id = Random.Shared.Next();
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
