using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ECommerce;

public class SaleDetail
{
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public decimal Subtotal { get; set; }

    public SaleDetail(string description, int price, int amount, decimal subtotal)
    {
        Description = description;
        Price = price;
        Amount = amount;
        Subtotal = subtotal;

    }


}
