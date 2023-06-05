using System.ComponentModel.DataAnnotations;

namespace CodebridgeTestAPI.Features;

public class PagingModel: IPagingModel
{
    [Range(1, int.MaxValue)]
    public int pageNumber { get; set; }
    
    [Range(1, int.MaxValue)]
    public int pageSize { get; set; }
    
    [Range(1, int.MaxValue)]
    public int? limit { get; set; }
}