namespace ECommerce;
public class Digital : IProduct
{
    //Requeridos por contrato
    public int Id { get; set; } = Random.Shared.Next(1,40);
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal Weight { get; set; }

    //Propios
    public string Format { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public Digital()
    {
        
    }
}
