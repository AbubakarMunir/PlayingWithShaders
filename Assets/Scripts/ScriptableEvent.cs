using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "Custom Event", menuName = "Custom/Event")]
public class ScriptableEvent : ScriptableObject
{
    public delegate void EventDelegate();
    private event EventDelegate eventListeners;

    public void InvokeEvent()
    {
        eventListeners?.Invoke();
    }

    public void AddListener(EventDelegate listener)
    {
        eventListeners += listener;
    }

    public void RemoveListener(EventDelegate listener)
    {
        eventListeners -= listener;
    }
}

