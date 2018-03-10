using UnityEngine;

namespace Assets.Scripts.Combat.Managers
{
    public class WeaponAttackColliderManager : MonoBehaviour
    {
        [SerializeField]
        CombatManager _combatManager;

        [SerializeField]
        Collider _collider;

        private void OnEnable()
        {
            if (_collider == null)
                _collider = GetComponent<Collider>();
            _collider.enabled = true;

            _combatManager = transform.root.GetComponentInChildren<CombatManager>();

            if (!_combatManager.ComponentIsSubscribedAsDependency(this))
                _combatManager.SubscribeAttackDependency(this);
        }

        private void Start()
        {
            this.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name);
            //check if collision was against targetable
            _combatManager.HitAttack(other.transform.root.gameObject);
        }

        private void OnDisable()
        {
            _collider.enabled = false;
        }
    }
}
