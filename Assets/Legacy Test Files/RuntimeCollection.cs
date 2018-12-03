using UnityEngine;
using System.Collections.Generic;

public abstract class RuntimeCollection<T> : ScriptableObject
{
    public List<T> collection = new List<T>();

    public void Add(T obj)
    {
        if(!collection.Contains(obj))
        {
            collection.Add(obj);
        }
    }

    public void Remove(T obj)
    {
        if(collection.Contains(obj))
        {
            collection.Remove(obj);
        }
    }
}