using Assets.Scripts.Interfaces.Actions;
using Assets.Scripts.Interfaces.Observers.Combat;
using Assets.Scripts.Managers;
using Assets.Scripts.Managers.Combat;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Combat
{
    public class AttackController : BaseCombatController, IAttackReceivable
    {
        readonly EquippedWeaponController _equippedWeaponController;
        readonly CombatAnimationsController _combatAnimationsController;

        public AttackController(
            ActionManager actionManager,
            EquippedWeaponController equippedWeaponController,
            CombatAnimationsController combatAnimationsController,
            CombatManager combatManager
            )
            : base(actionManager, combatManager)
        {
            _equippedWeaponController = equippedWeaponController;
            _combatAnimationsController = combatAnimationsController;
        }

        
        BaseWeaponController _currentWeaponController;
        bool _isAttacking;


        void FinishAttack()
        {
            _currentWeaponController.DeactivateWeapon();

            // TODO
            //esperar animação de ataque acabar e iniciar cooldown do ataque
            CoolDownAfterAttack();
        }

        void CoolDownAfterAttack()
        {
            const float timeToWait = 2;
            _combatManager.WaitForSomeTime(timeToWait, () =>
            {
                _isAttacking = false;
                _currentWeaponController.DeactivateWeapon();
            });
        }

        IEnumerator CoolDownAfterReceivingAttack()
        {
            // TODO
            // Terminar juntamente com a animação ou um pouco antes
            yield return new WaitForSeconds(3);
            _isAttacking = true;
        }

        public void CastAttack()
        {
            base.CastAction(() =>
            {
                _isAttacking = true;

                _currentWeaponController = _equippedWeaponController.GetCurrentWeaponController();
                _currentWeaponController.ActivateWeapon();
                _combatAnimationsController.PlayAttackAnimation(
                    _currentWeaponController.GetWeaponAnimationClip(),
                    callBack: () => FinishAttack());
            });
        }


        public void ReceiveAttack()
        {
            //if (_isDefending)
            //{
            // TODO
            // diminuir stamina. Ao chegar a zero deverá desativar a defesa
            // Debug.Log("Deflected attack");
            //return;
            //}

            CoolDownAfterAttack();
            //play damage animation
        }

        public bool IsAttacking()
        {
            return _isAttacking;
        }

    }
}
