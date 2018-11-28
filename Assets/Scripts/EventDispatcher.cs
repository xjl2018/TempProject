using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDispatcher
{
    public delegate void Func();

    private static Dictionary<string, Func> eventDic = new Dictionary<string, Func>();

    public static void AddEventListener(string eventName, Func func)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic[eventName] += func;
        }
        else
        {
            eventDic.Add(eventName, func);
        }
    }

    public static void removeEventListener(string eventName, Func func)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic[eventName] -= func;
        }
    }

    public static void TriggerEvent(string eventName)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic[eventName].Invoke();
        }
    }
}
