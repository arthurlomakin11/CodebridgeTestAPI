namespace CodebridgeTestAPI.Features;

public class PagingModel: IPagingModel
{
    public int pageNumber { get; set; }
    public int pageSize { get; set; }
    public int? limit { get; set; }
}