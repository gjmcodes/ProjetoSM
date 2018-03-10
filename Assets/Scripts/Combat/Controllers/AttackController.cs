using Assets.Scripts.Combat.Managers;
using Assets.Scripts.ScriptableObjects.Items.Equippable.Weapons;
using Assets.Scripts.Status.Managers;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Combat.Controllers
{
    public struct AttackController
    {
        StatusManager _statusManager;
        EquippedWeaponManager _equippedWeaponManager;

        bool _isAttacking;
        bool _isSufferingAttack;

        public AttackController(
            StatusManager statusManager,
            EquippedWeaponManager equippedWeaponManager)

        {
            _statusManager = statusManager;
            _equippedWeaponManager = equippedWeaponManager;
            _isAttacking = false;
            _isSufferingAttack = false;
        }

        public bool WillHitAttack(GameObject target)
        {
            _isSufferingAttack = true;
            //Check if target is defending
            bool willhit = true;

            return willhit;
        }

        public void HitAttack(GameObject targetHit)
        {
           var targetCombatManager = targetHit.GetComponentInChildren<CombatManager>();

            var attackerWeapon = _equippedWeaponManager.GetEquippedWeapon();
            var attributeVal = _statusManager.GetValueByAttribute(attackerWeapon.primaryAttribute);

            var damage = (Random.Range(attackerWeapon.minDamage, attackerWeapon.maxDamage) + attributeVal) / 2;

            targetCombatManager.ReceiveAttack(damage);  
        }

        public bool ReceiveAttack(float rawDamage)
        {
            // Get armor resistance
            // Get natural resistance

            bool isAlive = _statusManager.ReduceLife(rawDamage) > 0;

            return isAlive;
        }

        public bool IsAttacking()
        {
            return _isAttacking;
        }

        public bool IsSufferingAttack()
        {
            return _isSufferingAttack;
        }
        public void SetIsAttacking(bool value)
        {
            _isAttacking = value;
        }
    }
}
