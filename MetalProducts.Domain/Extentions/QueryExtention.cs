﻿using System.Linq.Expressions;

namespace MetalProducts.Domain.Extentions;

public static class QueryExtention
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition,
        Expression<Func<T, bool>> predicate)
    {
        if (condition)
            return source.Where(predicate);
        return source;
    }
}