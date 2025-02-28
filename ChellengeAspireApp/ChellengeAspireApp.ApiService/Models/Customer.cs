using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Customers")]
public class Customer
{
    [Key]
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
}
