using Assets.Scripts.Combat.Managers;
using Assets.Scripts.ScriptableObjects.Items.Equippable.Weapons;
using Assets.Scripts.Status.Managers;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Combat.Controllers
{
    public class AttackController
    {
        CombatManager _combatManager;
        StatusManager _statusManager;
        EquippedWeaponManager _equippedWeaponManager;

        public AttackController(
            CombatManager combatManager,
            StatusManager statusManager,
            EquippedWeaponManager equippedWeaponManager)

        {
            _combatManager = combatManager;
            _statusManager = statusManager;
            _equippedWeaponManager = equippedWeaponManager;
        }

        public bool WillHitAttack(GameObject target)
        {
            //Check if target is defending
            return true;
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
    }
}
