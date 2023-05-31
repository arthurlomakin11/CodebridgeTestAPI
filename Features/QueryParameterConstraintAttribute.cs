﻿using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace CodebridgeTestAPI.Controllers;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class QueryParameterConstraintAttribute : Attribute, IActionConstraint
{
    private readonly string _parameterName;
    private readonly string? _exclusiveParameterName;

    public QueryParameterConstraintAttribute(string parameterName, string? exclusiveParameterName = null)
    {
        _parameterName = parameterName;
        _exclusiveParameterName = exclusiveParameterName;
    }

    public bool Accept(ActionConstraintContext context)
    {
        bool ParameterExists(string parameterName) => context.RouteContext.HttpContext.Request.Query.Keys.Contains(parameterName);

        return ParameterExists(_parameterName) && !ParameterExists(_exclusiveParameterName ?? "");
    }

    public int Order { get; }
}