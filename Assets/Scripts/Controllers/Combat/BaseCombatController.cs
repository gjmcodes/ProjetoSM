using Assets.Scripts.Interfaces.Actions;
using Assets.Scripts.Managers;
using Assets.Scripts.Managers.Combat;
using System;
using UnityEngine;

namespace Assets.Scripts.Controllers.Combat
{
    public abstract class BaseCombatController : IActionCaster
    {
        protected readonly ActionManager _actionManager;
        protected readonly CombatManager _combatManager;

        public BaseCombatController(
            ActionManager actionManager,
            CombatManager combatManager)
        {
            _actionManager = actionManager;
            _combatManager = combatManager;

        }

        public void CastAction(Action actionToCast)
        {
            if (!_actionManager.ActionViabilityObserver.CanCastAction())
            {
                Debug.Log("Outra ação está impedindo esta");
                return;
            }

            actionToCast.Invoke();
        }

    }
}
