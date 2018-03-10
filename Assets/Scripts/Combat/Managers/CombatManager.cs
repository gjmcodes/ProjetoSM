using Assets.Scripts.Animations.Managers;
using Assets.Scripts.Combat.Controllers;
using Assets.Scripts.ScriptableObjects.Items.Equippable.Weapons;
using Assets.Scripts.Status.Managers;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Scripts.Status.Interfaces;

namespace Assets.Scripts.Combat.Managers
{
    public class CombatManager : MonoBehaviour, IBusyConditioner
    {
        [SerializeField]
        AnimationsManager _animationsManager;

        [SerializeField]
        EquippedWeaponManager _equippedWeaponManager;

        [SerializeField]
        StatusManager _statusManager;

        [SerializeField]
        BusyConditionManager _busyConditionManager;

        [SerializeField]
        List<MonoBehaviour> _attackDependencies;
        AttackController _attackController;
        public AttackController AttackController { get { return _attackController; } }

        private void OnEnable()
        {
            _busyConditionManager = GetComponent<BusyConditionManager>();
            _busyConditionManager.SubscribeBusyConditioner(this);

            _equippedWeaponManager = GetComponent<EquippedWeaponManager>();
            _statusManager = GetComponent<StatusManager>();
            _attackController = new AttackController(_statusManager, _equippedWeaponManager);
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
            AttackController.SetIsAttacking(false);
            SetAttackDependenciesEnabled(isEnabled: false);
        }

        public void Attack()
        {
            if (_busyConditionManager.IsBusy())
                return;

            AttackController.SetIsAttacking(true);
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

        public bool IsBusy()
        {
            return AttackController.IsAttacking();
        }
    }
}
