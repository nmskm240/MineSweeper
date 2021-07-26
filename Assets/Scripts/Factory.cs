using UnityEngine;

public abstract class Factory<T> 
{
    [SerializeField]
    protected T _original;

    public abstract T Create();
}