using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce;

public class Digital
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public decimal Weight { get; set; }

    public string Format { get; set; }
    public string Url { get; set; }
}
