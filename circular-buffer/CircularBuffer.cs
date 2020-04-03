using System;

public class CircularBuffer<T>
{
    public CircularBuffer(int capacity)
    {
        
    }

    public T Read()
    {
        throw new InvalidOperationException();
    }

    public void Write(T value)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public void Overwrite(T value)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public void Clear()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}