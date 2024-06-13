using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBus
{
    private static readonly IDictionary<EventType, UnityEvent> Events = new Dictionary<EventType, UnityEvent>();

    public static void Subscribe(EventType eventType, UnityAction listener, Sprite eventImage)
    {
        UnityEvent thisEvent;

        if (ButtonManager.instance.currBtn == null) return;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            if (ButtonManager.instance.currBtn.listener == null)
            {
                thisEvent.AddListener(listener);
                ButtonManager.instance.BtnActChange(listener, eventImage);
            }
            else
            {
                Unsubscribe(eventType);
                thisEvent.AddListener(listener);
                ButtonManager.instance.BtnActChange(listener, eventImage);
            }
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            ButtonManager.instance.BtnActChange(listener, eventImage);
            Events.Add(eventType, thisEvent);
        }
    }

    //public static void Unsubscribe(EventType type, UnityAction listener)
    //{
    //    UnityEvent thisEvent;

    //    if (ButtonManager.instance.currBtn == null) return;

    //    if (Events.TryGetValue(type, out thisEvent) && ButtonManager.instance.currBtn.listener != null)
    //    {
    //        thisEvent.RemoveListener(listener);
    //        ButtonManager.instance.BtnActClear();
    //    }
    //}

    public static void Unsubscribe(EventType type)
    {
        UnityEvent thisEvent;

        if (ButtonManager.instance.currBtn == null) return;

        if (Events.TryGetValue(type, out thisEvent) && ButtonManager.instance.currBtn.listener != null)
        {
            thisEvent.RemoveListener(ButtonManager.instance.currBtn.listener);
            ButtonManager.instance.BtnActClear();
        }
    }

    public static void Publish(EventType type)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(type, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }

    public static void Clear()
    {
        Events.Clear();
    }
}
