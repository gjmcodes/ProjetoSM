using Assets.Scripts.Constants;
using Assets.Scripts.Interfaces.Actions;
using Assets.Scripts.Interfaces.Observers.Combat;
using Assets.Scripts.Managers;
using System;
using UnityEngine;

namespace Assets.Scripts.Controllers.Combat
{
    public class BaseCombatController : MonoBehaviour, IAttackNotifiable, IActionListener
    {
        [SerializeField]
        AttackObserverController _attackObserverController;

        [SerializeField]
        protected ActionManager _actionManager;

        protected virtual void Start()
        {
            _actionManager = this.transform.parent
                .Find(ObjectsPathConstants.actionManager)
                .GetComponent<ActionManager>();


            _attackObserverController = GetComponent<AttackObserverController>();
            _attackObserverController.Subscribe(this);
        }

        protected void CastAction(Action actionToCast)
        {
            if (!_actionManager.ActionViabilityObserver.CanCastAction())
            {
                Debug.Log("Outra ação está impedindo esta");
                return;
            }

            actionToCast.Invoke();
        }

        public virtual void ReceiveNotification()
        {
        }

        public virtual bool HasImpedingActionRunning()
        {
            return false;
        }
    }
}
