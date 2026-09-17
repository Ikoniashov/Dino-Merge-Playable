using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class ListExtensions
{
    public static T PopLast<T>(this IList<T> list)
    {
        if (list.Count == 0)
        {
            throw new InvalidOperationException();
        }
        T result = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        return result;
    }
}
