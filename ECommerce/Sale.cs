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

    public DateTime Date { get; set; } = DateTime.Now;

    // Le quitamos el [Ignore] al Total porque NECESITAMOS que se guarde en el CSV
    public decimal Total { get; set; }

    public string Products { get; set; } = string.Empty;

    public Sale()
    {
    }

    public Sale(string docCliente)
    {
        DocClient = docCliente;
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