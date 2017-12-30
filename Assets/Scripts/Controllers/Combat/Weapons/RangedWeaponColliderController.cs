using UnityEngine;

namespace Assets.Scripts.Controllers.Combat.Weapons
{
    public class RangedWeaponColliderController : WeaponColliderController
    {
        [SerializeField]
        RangedColliderPositionController _positionController;

        protected override void OnEnable()
        {
            base.OnEnable();
            _positionController = GetComponent<RangedColliderPositionController>();
        }

        public override void ActivateCollider()
        {
            base.ActivateCollider();
        }

        public override void DeactivateCollider()
        {
            base.DeactivateCollider();
            _positionController.ResetCollider();
        }

        public RangedColliderPositionController GetColliderPositionController()
        {
            return _positionController;
        }
    }
}
