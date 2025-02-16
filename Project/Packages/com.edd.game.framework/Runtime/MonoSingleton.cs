using UnityEngine;

namespace EDD
{
    public class MonoSingleton<T> : MonoBehaviour where T : class
    {
       private static T _instance;
       private static readonly object _lock = new ();

       public static T Instance
       {
           get
           {
               if (_instance != null) 
                   return _instance;
               
               var type = typeof(T);
               _instance = FindFirstObjectByType(type) as T;
               
               if (_instance != null)
                   return _instance;
               
               lock (_lock)
               {
                   var go = new GameObject(type.Name);
                   _instance = go.AddComponent(type) as T;
               }

               return _instance;
           }
       }
    }
}
