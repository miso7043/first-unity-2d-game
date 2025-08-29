using System.Collections.Generic;
using UnityEngine;

public interface IKeyObserver
{
    List<KeyCode> Keys { get; }
    void OnKeyPressed(KeyCode key);
}

public class KeyChecker : MonoBehaviour
{
    private List<IKeyObserver> observers = new List<IKeyObserver>();

    public void RegisterObserver(IKeyObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void UnregisterObserver(IKeyObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    private void Update()
    {
        foreach (var observer in observers)
        {
            foreach (var key in observer.Keys)
            {
                if (Input.GetKeyDown(key))
                {
                    observer.OnKeyPressed(key);
                }
            }
        }
    }
}
