using Assets.Scripts.Objects.Equippable;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripts.Controllers.Combat
{
    public class MeleeWeaponController : BaseWeaponController
    {
        WeaponColliderController _weaponColliderManager;

        void Start()
        {
            _weaponColliderManager = GetComponent<WeaponColliderController>();
        }

        public override void ActivateWeapon()
        {
            _weaponColliderManager.ActivateCollider();
        }

        public override void DeactivateWeapon()
        {
            _weaponColliderManager.DeactivateCollider();
        }
    }
}
