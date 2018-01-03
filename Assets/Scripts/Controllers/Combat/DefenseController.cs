using Assets.Scripts.Interfaces.Observers.Combat;
using Assets.Scripts.Managers;
using Assets.Scripts.Managers.Combat;
using UnityEngine;

namespace Assets.Scripts.Controllers.Combat
{
    public class DefenseController : BaseCombatController, IAttackReceivable
    {
        public DefenseController(
            ActionManager actionManager,
            CombatManager combatManager
            )
            : base(actionManager, combatManager) { }

        bool _isDefending;

        public void CastDefense()
        {
            base.CastAction(() =>
            {
                _isDefending = true;
            });
        }

        public void ReleaseDefense()
        {
            _isDefending = false;
        }

        public bool IsDefending()
        {
            return _isDefending;
        }


        public void ReceiveAttack()
        {
            throw new System.NotImplementedException();
        }
    }
}
