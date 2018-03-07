using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Items.Equippable.Weapons
{
    [CreateAssetMenu(menuName = "Weapons/BaseWeapon")]
    public class BaseWeapon : BaseEquippable
    {
        public float minDamage;
        public float maxDamage;

        public AnimationClip attackAnimation;
    }
}
