using Assets.Scripts.Animations.Controllers;
using System;
using UnityEngine;

namespace Assets.Scripts.Animations.Managers
{
    public class AnimationsManager : MonoBehaviour
    {

        [SerializeField]
        Animator _animator;

        AttackAnimationController _attackAnimationController;

        private void OnEnable()
        {
            _animator = transform.root.GetComponentInChildren<Animator>();
            _attackAnimationController = new AttackAnimationController(_animator);
        }

        public void OverrideAnimation(AnimationClip animationClip)
        {
            AnimationClipsChanger animationClipsChanger = new AnimationClipsChanger(_animator);
            animationClipsChanger.OverrideAnimationClip(animationClip);
        }

        public void PlayAttackAnimation(Action finishedAttackCallback)
        {
            var attackFullPathHash =_attackAnimationController.PlayAttackAnimation(finishedAttackCallback);

            CheckAttackAnimationHasEnded(attackFullPathHash);
        }

        public void PlayAttackHitAnimation()
        {
            _attackAnimationController.PlayAttackHitAnimation();
        }

        public void CheckAttackAnimationHasEnded(int attackFullPathHash)
        {
            StartCoroutine(_attackAnimationController.CheckAnimationHasEnded(attackFullPathHash));
        }
    }
}
