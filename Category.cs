namespace PrologMobile;

public record Category
{
    public string? CategoryName { get; set; }
    public decimal TotalInventoryValue { get; set; }
    public int AvailableRecordCount { get; set; }
    public List<Record> Items { get; set; } = [];
}
