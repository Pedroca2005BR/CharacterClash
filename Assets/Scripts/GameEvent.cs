using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyUtils
{
    [CreateAssetMenu(fileName ="NewGameEvent", menuName ="GameEvent")]
    public class GameEvent : ScriptableObject
    {
       public List<GameEventListener> listeners = new List<GameEventListener>();

        public void Raise(Component sender, object data)
        {
            foreach (GameEventListener listener in listeners)
            {
                listener.OnRaisedEvent(sender, data);
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }
    }
}