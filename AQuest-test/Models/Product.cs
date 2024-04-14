using System.ComponentModel.DataAnnotations;

public class Product{

    
    public int Id { get; set; }
    
    public required string Name { get; set; }
    public string? Description { get; set; }
    
    public float Price { get; set; }

    //public int Quantity { get; set; }

}