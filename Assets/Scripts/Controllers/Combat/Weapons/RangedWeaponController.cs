using Assets.Scripts.Constants;
using Assets.Scripts.Controllers.Combat.Weapons;
using System;
using UnityEngine;

namespace Assets.Scripts.Controllers.Combat
{
    public class RangedWeaponController : BaseWeaponController
    {
        public RangedWeaponColliderController _rangedCollider;
        public RangedCollidersPoolController _rangedCollidersPoolController;

        Transform combatManagerObj;

        protected virtual void Start()
        {
            // TODO
            // Remover string mágica
            combatManagerObj = transform.parent.parent.parent.parent.Find(ObjectsPathConstants.combatManager);

            _rangedCollidersPoolController = FindObjectOfType<RangedCollidersPoolController>();
        }

        public override void ActivateWeapon()
        {
            _rangedCollider = _rangedCollidersPoolController.GetAvailableRangedCollider();
            Debug.Log(_rangedCollider.name);

            var positionController = _rangedCollider.GetColliderPositionController();
           
            //Pass in CombatManager object
            positionController.SetInitialPosition(combatManagerObj);
            positionController.SetInMotion();

            _rangedCollider.ActivateCollider();
        }

        public override void DeactivateWeapon()
        {
            _rangedCollider.DeactivateCollider();
        }
    }
}
