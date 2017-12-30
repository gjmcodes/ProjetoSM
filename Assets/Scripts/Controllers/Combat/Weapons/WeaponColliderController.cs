using Assets.Scripts.Controllers.Combat;
using UnityEngine;

namespace Assets.Scripts.Controllers.Combat
{
    public class WeaponColliderController : MonoBehaviour
    {
        [SerializeField]
        protected Collider _collider;

        protected virtual void OnEnable()
        {
            _collider = GetComponent<Collider>();
        }

        public virtual Collider GetCollider()
        {
            return _collider;
        }

        public virtual void ActivateCollider()
        {
            _collider.enabled = true;
        }

        public virtual void DeactivateCollider()
        {
            _collider.enabled = false;
        }
    }
}
