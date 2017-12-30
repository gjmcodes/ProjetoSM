using Assets.Scripts.Objects.Equippable;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripts.Controllers.Combat
{
    public abstract class BaseWeaponController : MonoBehaviour
    {
        [SerializeField]
        protected BaseWeapon _weapon;

        public virtual AnimationClip GetWeaponAnimationClip()
        {
            return _weapon.animationClip;
        }

        public abstract void ActivateWeapon();
        public abstract void DeactivateWeapon();

    }
}
