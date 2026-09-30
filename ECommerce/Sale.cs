using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce;

public class Sale
{
    public int Id { get; set; }
    public int Num { get; set; }
    public string DocClient { get; set; } = "";
    public List<SaleDetail> Details { get; set; }
    public DateTime date;
    public decimal Total { get; set; }


    public Sale(int num, string docCliente, List<SaleDetail> details, decimal total)
    {
        Id = 123;
        Num = num;
        DocClient = docCliente;
        Details = details;
        Total = total;

    }

    public AddProduct(Producto producto)
    { return }



}
