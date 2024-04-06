using System.ComponentModel.DataAnnotations;

public class Product{

    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required decimal Price { get; set; }


}