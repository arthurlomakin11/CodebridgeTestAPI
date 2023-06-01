using System.ComponentModel.DataAnnotations;

namespace CodebridgeTestAPI.Features;

public class OrderingModel: IOrderingModel
{
    public OrderType order { get; set; }
    [RegularExpression("name|color|tail_length|weight", ErrorMessage = "Invalid value for attribute")]
    public string attribute { get; set; }
}