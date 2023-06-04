namespace CodebridgeTestAPI.Features;

public interface IOrderingModel
{
    public OrderType order { get; set; }
    public string attribute { get; set; }
}