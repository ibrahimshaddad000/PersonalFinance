namespace PersonalFinance.Dtos;

public class TransactionCreateDto
{
    public string Title { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Type { get; set; } = "Expense";
    public string Category { get; set; } = "General";
    public DateTime Date { get; set; }
}