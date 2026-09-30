using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce;

public class Physical : IProduct
{

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal Weight { get; set; }

    public int Stock { get; set; }
    public decimal ShippingCost { get; set; }




}
