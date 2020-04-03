using System;
using System.Collections.Generic;

public class CircularBuffer<T>
{
    private Queue<T> Storage = new Queue<T>();
    readonly int Capacity;
    public CircularBuffer(int capacity) => Capacity = capacity;

    public T Read() => Storage.Dequeue();

    public void Write(T value)
    {
        if (IsFull()) {
            throw new InvalidOperationException();
        }
        Storage.Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if (IsFull()) {
            Storage.Dequeue();
        }
        Write(value);
    }

    public void Clear() => Storage.Clear();

    private bool IsFull() => Storage.Count >= Capacity;
}