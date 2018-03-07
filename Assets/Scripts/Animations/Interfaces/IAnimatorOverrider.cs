using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Animations.Interfaces
{
    public interface IAnimatorOverrider
    {
        AnimatorOverrideController OverrideAnimatorController(RuntimeAnimatorController runtimeAnimatorController,
            AnimationClip newAnimationClip);
    }
}
