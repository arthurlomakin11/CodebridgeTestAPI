using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace CodebridgeTestAPI.Features;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class QueryParameterConstraintAttribute: Attribute, IActionConstraint
{
    private readonly string _parameterName;
    public QueryParameterConstraintAttribute(string parameterName) => _parameterName = parameterName;

    public bool Accept(ActionConstraintContext context)
    {
        return context.RouteContext.HttpContext.Request.Query.Keys.Contains(_parameterName);
    }

    public int Order { get; }
}