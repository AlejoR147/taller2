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
    public string DocClient { get; set; } = string.Empty;

    [Ignore] // ¡CRÍTICO! Esto evita que CsvHelper explote al intentar guardar la lista
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
        // La validación de cantidad <= 0 ya la tienes protegida en el constructor de SaleDetail
        SaleDetail detail = new SaleDetail(product, quantity);
        PurchasedItems = PurchasedItems.Append(detail).ToList();

        // Se actualizan el total y el texto mágico para el CSV
        Total = PurchasedItems.Sum(d => d.Subtotal);
        Products = string.Join(", ", PurchasedItems.Select(p => $"{p.ProductName} x{p.Quantity}"));
    }
}