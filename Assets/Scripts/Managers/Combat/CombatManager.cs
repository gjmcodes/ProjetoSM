using Assets.Scripts.Constants;
using Assets.Scripts.Controllers.Combat;
using Assets.Scripts.Entities.Combat;
using Assets.Scripts.Interfaces.Actions;
using Assets.Scripts.Interfaces.Observers.Combat;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Managers.Combat
{
    public class CombatManager : MonoBehaviour, IAttackNotifiable
    {
        AttackController _attackController;
        public AttackController AttackController { get { return _attackController; } }

        DefenseController _defenseController;
        public DefenseController DefenseController { get { return _defenseController; } }

        [SerializeField]
        AttackObserverController _attackObserverController;

        [SerializeField]
        ActionManager _actionManager;

        [SerializeField]
        EquippedWeaponController _equippedWeaponController;

        [SerializeField]
        CombatAnimationsController _combatAnimationsController;

        ActionListener _actionListener;

        private void Awake()
        {
            _attackObserverController = GetComponent<AttackObserverController>();
            _actionManager = transform.parent.Find(ObjectsPathConstants.actionManager)
                .GetComponent<ActionManager>();
            _equippedWeaponController = GetComponent<EquippedWeaponController>();
            _combatAnimationsController = transform.parent
                .Find(ObjectsPathConstants.combatAnimationsController)
                .GetComponent<CombatAnimationsController>();
        }

        void Start()
        {
            _attackObserverController.Subscribe(this);

            _attackController = new AttackController(
                _actionManager,
                _equippedWeaponController,
                _combatAnimationsController,
                this);

            _defenseController = new DefenseController(_actionManager, this);

            _actionListener = new ActionListener(HasImpedingActionRunning, _actionManager);
        }

        IEnumerator WaitCoroutine(float timeToWait, Action callBack)
        {
            yield return new WaitForSeconds(timeToWait);

            if (callBack != null)
                callBack.Invoke();
        }

        public bool HasImpedingActionRunning()
        {
            return _attackController.IsAttacking() || _defenseController.IsDefending();
        }

        public void WaitForSomeTime(float timeToWait, Action callBack = null)
        {
            StartCoroutine(WaitCoroutine(timeToWait, callBack));
        }

        public void ReceiveNotification()
        {
            if (_defenseController.IsDefending())
            {
                // TODO
                // defense controller recebe ataque
                _defenseController.ReceiveAttack();
                return;
            }

            _attackController.ReceiveAttack();
        }
    }
}
