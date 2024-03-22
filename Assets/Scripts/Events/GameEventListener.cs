using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MyUtils
{
    [System.Serializable]
    public class CustomGameEvent : UnityEvent<Component, object> { }

    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent gameEvent;

        public CustomGameEvent response;

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }

        public void OnRaisedEvent(Component sender, object data)
        {
            response.Invoke(sender, data);
        }
    }
}