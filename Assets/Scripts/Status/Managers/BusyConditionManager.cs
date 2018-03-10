using Assets.Scripts.Status.Interfaces;
using UnityEngine;
using System.Linq;

namespace Assets.Scripts.Status.Managers
{
    public class BusyConditionManager : MonoBehaviour
    {
        [SerializeField]
        public IBusyConditioner[] _busyConditioners = new IBusyConditioner[0];

        public bool IsBusy()
        {
            return _busyConditioners.Any(x => x.IsBusy());
        }

        public void SubscribeBusyConditioner(IBusyConditioner busyConditioner)
        {
            if (_busyConditioners.Contains(busyConditioner))
                return;

            var list = _busyConditioners.ToList();
            list.Add(busyConditioner);

            _busyConditioners = list.ToArray();
        }

        public void UnsubscribeBusyConditioner(IBusyConditioner busyConditioner)
        {
            var list = _busyConditioners.ToList();
            list.Remove(busyConditioner);

            _busyConditioners = list.ToArray();
        }
    }
}
