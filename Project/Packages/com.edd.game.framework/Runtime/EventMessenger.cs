using System;
using System.Collections.Generic;

namespace EDD
{
    public enum EEventType
    {
        GamepadOnMove = 1,
        GamepadOnRelease,
    }
    
    public abstract class EventArg { }
    public static class EventMessenger 
    {
        private static readonly Dictionary<int, Action<EventArg>> DicEvents = new ();

        public static void Register(int id, Action<EventArg> callback)
        {
            if (callback == null)
                return;
            
            Logger.Log($"{nameof(Register)} {nameof(id)} = {id} {nameof(callback)} = {callback.Method.Name}", nameof(EventMessenger));
            
            if (!DicEvents.TryAdd(id, callback))
                DicEvents[id] += callback;
        }

        public static void Unregister(int id, Action<EventArg> callback)
        {
            if (callback == null)
                return;
            
            if (!DicEvents.ContainsKey(id))
                return;
            
            Logger.Log($"{nameof(Unregister)} {nameof(id)} = {id} {nameof(callback)} = {callback.Method.Name}", nameof(EventMessenger));
            
            DicEvents[id] -= callback;
            if (DicEvents[id] == null)
                DicEvents.Remove(id);
        }

        public static void Broadcast(int id, EventArg arg = null)
        {
            Logger.Log($"{nameof(Broadcast)} {nameof(id)} = {id} {nameof(arg)} = {arg}", nameof(EventMessenger));
            
            if (DicEvents.TryGetValue(id, out var callback))
                callback?.Invoke(arg);
        }
    }
}
