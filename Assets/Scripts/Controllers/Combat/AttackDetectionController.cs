using UnityEngine;

namespace Assets.Scripts.Controllers.Combat
{
    public class AttackDetectionController : MonoBehaviour
    {
        [SerializeField]
        AttackObserverController _attackObserverManager;

        private void Start()
        {
            _attackObserverManager = this.transform.parent.GetComponent<AttackObserverController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Weapon")
            {
                Debug.Log(other.name);
                _attackObserverManager.NotifySubscribers();
            }
        }
    }
}
