using System;
using System.Collections.Generic;

namespace EDD
{
    public enum EEventType
    {
        GamepadMove = 1,
    }
    
    public abstract class EventMessengerArg { }
    public static class EventMessenger 
    {
        private static readonly Dictionary<int, Action<EventMessengerArg>> DicEvents = new ();

        public static void Register(int id, Action<EventMessengerArg> callback)
        {
            if (!DicEvents.TryAdd(id, callback))
                DicEvents[id] += callback;
        }

        public static void Unregister(int id, Action<EventMessengerArg> callback)
        {
            if (!DicEvents.ContainsKey(id))
                return;
            
            DicEvents[id] -= callback;
            if (DicEvents[id] == null)
                DicEvents.Remove(id);
        }

        public static void Broadcast(int id, EventMessengerArg messengerArg)
        {
            if (DicEvents.TryGetValue(id, out var callback))
                callback?.Invoke(messengerArg);
        }
    }
}
