using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CircularList<T> : IList<T>
{
    [SerializeField]
    private readonly List<T> list = new List<T>();
    int i = 0;
    public CircularList(IEnumerable<T> ie)
    {
        foreach (var item in ie)
        {
            if (item != null)
            {
                list.Add(item);
            }
        }
    }
    public CircularList()
    {

    }



    public T this[int index]
    {
        get => ((IList<T>)list)[index % list.Count];
        set => ((IList<T>)list)[index % list.Count] = value;
    }

    public T Current => list[i];

    public int Count => ((ICollection<T>)list).Count;
    public int Index => i;
    public bool IsReadOnly => ((ICollection<T>)list).IsReadOnly;

    public void Add(T item)
    {
        ((ICollection<T>)list).Add(item);
    }

    public void Clear()
    {
        ((ICollection<T>)list).Clear();
    }

    public bool Contains(T item)
    {
        return ((ICollection<T>)list).Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        ((ICollection<T>)list).CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)list).GetEnumerator();
    }

    public int IndexOf(T item)
    {
        return ((IList<T>)list).IndexOf(item);
    }

    public void Insert(int index, T item)
    {
        ((IList<T>)list).Insert(index, item);
    }

    public T Next()
    {
        i = (i + 1) % list.Count;

        return Current;
    }
    public T Prev()
    {
        i--;
        if (i < 0)
        {
            i = list.Count - 1;
        }
        return Current;
    }

    public bool Remove(T item)
    {
        return ((ICollection<T>)list).Remove(item);
    }

    public void RemoveAt(int index)
    {
        ((IList<T>)list).RemoveAt(index);
    }

    public void Reset()
    {
        i = 0;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)list).GetEnumerator();
    }
}
