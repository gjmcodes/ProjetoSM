using System;
using System.Collections;
using UnityEngine;
using System.Linq;

namespace Assets.Scripts.Controllers.Combat
{
    public class CombatAnimationsController : MonoBehaviour
    {
        Animator _combatAnimator;

        int _attackTrigger = Animator.StringToHash("Attack");

        bool _playingAttackAnim;
        Action _animCallback;
        int _currentAnimationClipHash;

        private void Start()
        {
            _combatAnimator = GetComponent<Animator>();
        }

        public void PlayAttackAnimation(AnimationClip weaponAnimation, Action callBack)
        {
            OverrideAnimationClip(weaponAnimation);
            _combatAnimator.SetTrigger(_attackTrigger);
            _animCallback = callBack;
            _playingAttackAnim = true;

            StartCoroutine(CheckAnimationHasEnded());
        }

        void OverrideAnimationClip(AnimationClip weaponAnimationClip)
        {
            if (weaponAnimationClip.GetHashCode() != _currentAnimationClipHash)
            {
                AnimatorOverrideController aoc =
                    new AnimatorOverrideController(_combatAnimator.runtimeAnimatorController);
                _combatAnimator.runtimeAnimatorController = aoc;

                aoc[weaponAnimationClip.name] = weaponAnimationClip;
                _currentAnimationClipHash = weaponAnimationClip.GetHashCode();
            }
        }

        IEnumerator CheckAnimationHasEnded()
        {
            while (_playingAttackAnim)
            {
                if (_combatAnimator.GetCurrentAnimatorStateInfo(0).IsName("WeaponSwing_Test"))
                {
                    _animCallback.Invoke();
                    _playingAttackAnim = false;
                }

                yield return new WaitForSeconds(0.1f);
            }

            StopCoroutine(CheckAnimationHasEnded());
        }

    }
}
