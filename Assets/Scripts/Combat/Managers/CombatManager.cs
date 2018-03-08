using Assets.Scripts.Animations.Managers;
using Assets.Scripts.Combat.Controllers;
using Assets.Scripts.ScriptableObjects.Items.Equippable.Weapons;
using Assets.Scripts.Status.Managers;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Assets.Scripts.Combat.Managers
{
    public class CombatManager : MonoBehaviour
    {
        [SerializeField]
        AnimationsManager _animationsManager;

        [SerializeField]
        EquippedWeaponManager _equippedWeaponManager;

        [SerializeField]
        StatusManager _statusManager;

        [SerializeField]
        bool _isAttacking;
        public bool IsAttacking { get { return _isAttacking; } set { _isAttacking = value; } }

        [SerializeField]
        List<MonoBehaviour> _attackDependencies;
        AttackController _attackController;

        private void OnEnable()
        {
            _equippedWeaponManager = GetComponent<EquippedWeaponManager>();
            _statusManager = GetComponent<StatusManager>();
            _attackController = new AttackController(this, _statusManager, _equippedWeaponManager);
            _animationsManager = GetComponent<AnimationsManager>();
        }

        private void SetAttackDependenciesEnabled(bool isEnabled)
        {
            for (int i = 0; i < _attackDependencies.Count; i++)
            {
                _attackDependencies[i].enabled = isEnabled;
            }
        }

        private void FinishAttack()
        {
            _isAttacking = false;
            SetAttackDependenciesEnabled(isEnabled: false);
        }

        public void Attack()
        {
            if (_isAttacking)
                return;

            _isAttacking = true;
            SetAttackDependenciesEnabled(isEnabled: true);

            _animationsManager.PlayAttackAnimation(finishedAttackCallback: () => FinishAttack());
        }

        public void HitAttack(GameObject hitTarget)
        {
            if (_attackController.WillHitAttack(hitTarget))
            {
                _attackController.HitAttack(hitTarget);
                //_animationsManager.PlayAttackHitAnimation();
            }

        }

        public void SubscribeAttackDependency(MonoBehaviour dependency)
        {
            _attackDependencies = _attackDependencies ?? new List<MonoBehaviour>();
            _attackDependencies.Add(dependency);
        }

        public bool ComponentIsSubscribedAsDependency(MonoBehaviour component)
        {
            if (_attackDependencies == null || _attackDependencies.Count == 0)
                return false;

            return _attackDependencies.Contains(component);
        }

        public bool ReceiveAttack(float rawDamage)
        {
            return _attackController.ReceiveAttack(rawDamage);
        }
        public BaseWeapon GetEquippedWeapon()
        {
            return _equippedWeaponManager.GetEquippedWeapon();
        }
    }
}
