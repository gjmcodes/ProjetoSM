using Assets.Scripts.Interfaces.Observers;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Observers
{
    public class Observer : MonoBehaviour, IObserver
    {
        protected List<IListener> _notifiables;

        public Observer()
        {
            _notifiables = new List<IListener>();
        }

        public void NotifySubscribers()
        {
            for (int i = 0; i < _notifiables.ToArray().Length; i++)
            {
                _notifiables[i].ReceiveNotification();
            }
        }

        public void Subscribe(IListener notifiable)
        {
            _notifiables.Add(notifiable);
        }

        public void Unsubscribe(IListener notifiable)
        {
            _notifiables.Remove(notifiable);
        }
    }
}
