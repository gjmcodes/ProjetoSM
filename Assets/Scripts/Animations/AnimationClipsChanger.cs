using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Animations
{
    public class AnimationClipsChanger
    {
        private Animator _animator;

        public AnimationClipsChanger(Animator animator)
        {
            _animator = animator;
        }

        public Animator OverrideAnimationClip(AnimationClip animationClip)
        {
            var animatorOverrider = new AnimatorOverrider();
            _animator.runtimeAnimatorController = animatorOverrider
                                                    .OverrideAnimatorController(_animator.runtimeAnimatorController, animationClip);
            return _animator;
        }
    }
}
