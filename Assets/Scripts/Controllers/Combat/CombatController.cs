using Assets.Scripts.Constants;
using Assets.Scripts.Interfaces.Actions;
using Assets.Scripts.Interfaces.Observers.Combat;
using Assets.Scripts.Managers;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Combat
{
    public class CombatController : BaseCombatController, IAttackNotifiable, IActionListener
    {
        [SerializeField]
        EquippedWeaponController _equippedWeaponController;

        [SerializeField]
        BaseWeaponController _currentWeaponController;

        [SerializeField]
        CombatAnimationsController _combatAnimationsController;

        [SerializeField]
        bool _isAttacking;

        [SerializeField]
        bool _isDefending;


        void OnEnable()
        {
            _equippedWeaponController = GetComponent<EquippedWeaponController>();

            // TODO
            // remover string mágica
            _combatAnimationsController = this.transform.parent
                .Find(ObjectsPathConstants.combatAnimationsController)
                .transform.GetComponent<CombatAnimationsController>();
        }

        void FinishAttack()
        {
            _currentWeaponController.DeactivateWeapon();

            // TODO
            //esperar animação de ataque acabar e iniciar cooldown do ataque
            StartCoroutine(CoolDownAfterAttack());
        }

        IEnumerator CoolDownAfterAttack()
        {
            yield return new WaitForSeconds(2);
            _isAttacking = false;
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
            CastAction(() =>
            {
                _isAttacking = true;

                _currentWeaponController = _equippedWeaponController.GetCurrentWeaponController();
                _currentWeaponController.ActivateWeapon();
                _combatAnimationsController.PlayAttackAnimation(
                    _currentWeaponController.GetWeaponAnimationClip(),
                    callBack: () => FinishAttack());
            });
        }

        

        public void ReleaseDefense()
        {
            _isDefending = false;
        }

        public override void ReceiveNotification()
        {
            ReceiveAttack();
        }

        public void ReceiveAttack()
        {
            if (_isDefending)
            {
                // TODO
                // diminuir stamina. Ao chegar a zero deverá desativar a defesa
                Debug.Log("Deflected attack");
                return;
            }
            _currentWeaponController.DeactivateWeapon();
            StartCoroutine(CoolDownAfterReceivingAttack());
            //play damage animation
        }

        public bool CanAttack()
        {
            return !_isAttacking && !_isDefending;
        }

        public bool CanDefend()
        {
            return !_isDefending && !_isAttacking;
        }

        public override bool HasImpedingActionRunning()
        {
            return _isDefending || _isAttacking;
        }
    }
}
