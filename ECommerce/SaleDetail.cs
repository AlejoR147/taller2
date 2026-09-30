using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ECommerce;

public class SaleDetail
{
    public string ProductName { get; set; }
    public string ProductDetails { get; set; }
    public decimal ProductPrice { get; set; }
    public string ProductDescrip { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal => ProductPrice * Quantity;

    public SaleDetail(IProduct product, int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("La cantidad debe ser mayor que cero.");

        ProductName = product.Name;
        ProductDescrip = product.Description;
        ProductPrice = product.Price; 
        Quantity = quantity;

        ProductDetails = $"Producto: {ProductName}, Precio Unitario: {ProductPrice}, Cantidad {Quantity}";

    }
}
