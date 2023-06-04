using System.ComponentModel.DataAnnotations;

namespace CodebridgeTestAPI.Features;

public class PagingAndOrderingModel: IPagingModel, IOrderingModel
{
    [Range(0, int.MaxValue)]
    public int pageNumber { get; set; }
    
    [Range(0, int.MaxValue)]
    public int pageSize { get; set; }
    
    [Range(0, int.MaxValue)]
    public int? limit { get; set; }
    public OrderType order { get; set; }
    
    [RegularExpression("name|color|tail_length|weight", ErrorMessage = "Invalid value for attribute")]
    public string attribute { get; set; }
}