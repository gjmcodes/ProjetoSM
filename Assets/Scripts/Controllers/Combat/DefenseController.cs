using UnityEngine;

namespace Assets.Scripts.Controllers.Combat
{
    public class DefenseController : BaseCombatController
    {
        [SerializeField]
        bool _isDefending;

        public void CastDefense()
        {
            CastAction(() =>
            {
                if (HasImpedingActionRunning())
                    return;

                _isDefending = true;
            });
        }

        public override void ReceiveNotification()
        {
            base.ReceiveNotification();
        }

        public override bool HasImpedingActionRunning()
        {
            return !_isDefending;
        }
    }
}
