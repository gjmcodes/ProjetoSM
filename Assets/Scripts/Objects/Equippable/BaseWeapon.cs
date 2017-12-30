using UnityEngine;

namespace Assets.Scripts.Objects.Equippable
{
    [CreateAssetMenu()]
    public abstract class BaseWeapon : ScriptableObject
    {
        public float damage;
        public AnimationClip animationClip;
    }
}
