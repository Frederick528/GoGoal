using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventBus
{
    private static readonly IDictionary<EventType, UnityEvent> Events = new Dictionary<EventType, UnityEvent>();

    public static short Subscribe(EventType eventType, UnityAction listener, Sprite eventImage)
    {
        UnityEvent thisEvent;
        short retVal = 0;

        if (ButtonManager.instance.currBtn == null) return retVal;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            if (ButtonManager.instance.currBtn.listener == null)
            {
                thisEvent.AddListener(listener);
                ButtonManager.instance.BtnActChange(listener, eventImage);
                retVal = 1;
            }
            else
            {
                Unsubscribe(eventType);
                thisEvent.AddListener(listener);
                ButtonManager.instance.BtnActChange(listener, eventImage);
                retVal = 0;
            }
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            ButtonManager.instance.BtnActChange(listener, eventImage);
            Events.Add(eventType, thisEvent);
            retVal = 1;
        }
        return retVal;
    }

    public static void ChangeSubscribe(EventType eventType, UnityAction listener, Sprite eventImage)
    {
        UnityEvent thisEvent;

        if (ButtonManager.instance.currBtn == null) return;

        if (Events.TryGetValue(eventType, out thisEvent) && ButtonManager.instance.currBtn.listener != null)
        {
            Unsubscribe(eventType);
            thisEvent.AddListener(listener);
            ButtonManager.instance.BtnActChange(listener, eventImage);
        }
    }

    public static int Unsubscribe(EventType type, UnityAction listener)
    {
        UnityEvent thisEvent;
        short retVal = 0;

        if (ButtonManager.instance.currBtn == null) return retVal;

        if (Events.TryGetValue(type, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
            retVal = 1;
        }
        return retVal;
    }

    public static short Unsubscribe(EventType type)
    {
        UnityEvent thisEvent;
        short retVal = 0;

        //if (ButtonManager.instance.currBtn == null) return retVal;    // check complete

        if (Events.TryGetValue(type, out thisEvent) && ButtonManager.instance.currBtn.listener != null)
        {
            thisEvent.RemoveListener(ButtonManager.instance.currBtn.listener);
            ButtonManager.instance.BtnActClear();
            retVal = 1;
        }
        return retVal;
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
