namespace PrologMobile;

public class ApiResponse
{
    public List<Record> Records { get; set; } = [];
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
}
