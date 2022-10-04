﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Text.Json.Nodes;

namespace FastEndpoints;

internal class PropCache
{
    public Type PropType { get; init; }
    public Action<object, object> PropSetter { get; init; }
}

internal class QueryPropCacheEntry : PropCache
{
    public Action<IDictionary<string, StringValues>, JsonObject> JsonSetter { get; init; }
}

internal class PrimaryPropCacheEntry : PropCache
{
    public Func<object?, (bool isSuccess, object value)>? ValueParser { get; init; }
}

internal class SecondaryPropCacheEntry : PrimaryPropCacheEntry
{
    public string Identifier { get; init; }
    public bool ForbidIfMissing { get; init; }
    public string? PropName { get; set; }
    public bool IsCollection { get; set; }
}