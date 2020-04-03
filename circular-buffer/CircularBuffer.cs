using System;
using System.Collections.Generic;

public class CircularBuffer<T>
{
    private Queue<T> Storage {get; set;}
    readonly int Capacity;
    public CircularBuffer(int capacity)
    {
        Capacity = capacity;
        Storage = new Queue<T>(capacity);
    }

    public T Read()
    {
        return Storage.Dequeue();
    }

    public void Write(T value)
    {
        if (Storage.Count >= Capacity) {
            throw new InvalidOperationException();
        }
        Storage.Enqueue(value);
    }

    public void Overwrite(T value)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public void Clear()
    {
        Storage.Clear();
    }
}