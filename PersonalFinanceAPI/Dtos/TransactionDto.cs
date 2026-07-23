using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinance.Dtos;

public class TransactionDto
{
    public int Id { get; set; }
    [Required] [MaxLength(100)] public string Title { get; set; } = string.Empty;
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string Type { get; set; } = "Expense";

    [Required]
    [MaxLength(50)]
    public string Category { get; set; } = "General";

    public DateTime Date { get; set; } = DateTime.UtcNow;
}