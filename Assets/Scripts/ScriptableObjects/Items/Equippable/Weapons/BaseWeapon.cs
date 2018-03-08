using Assets.Scripts.ScriptableObjects.Status;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Items.Equippable.Weapons
{
    [CreateAssetMenu(menuName = "Weapons/BaseWeapon")]
    public class BaseWeapon : BaseEquippable
    {
        public float minDamage;
        public float maxDamage;

        public Attribute primaryAttribute;

        public AnimationClip attackAnimation;
    }
}
