namespace ECommerce;

public class Physical : IProduct
{
    //Requeridos por contrato
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal Weight { get; set; }

    //propios
    public int Stock { get; set; }
    public decimal ShippingCost { get; set; }
}
