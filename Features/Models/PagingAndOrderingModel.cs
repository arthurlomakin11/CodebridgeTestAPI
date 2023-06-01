using System.ComponentModel.DataAnnotations;

namespace CodebridgeTestAPI.Features;

public class PagingAndOrderingModel: IPagingModel, IOrderingModel
{
    public int pageNumber { get; set; }
    public int pageSize { get; set; }
    public int? limit { get; set; }
    public OrderType order { get; set; }
    [RegularExpression("name|color|tail_length|weight", ErrorMessage = "Invalid value for attribute")]
    public string attribute { get; set; }
}