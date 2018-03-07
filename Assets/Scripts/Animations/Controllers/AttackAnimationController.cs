using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Animations.Controllers
{
    public class AttackAnimationController
    {
        int AttackTrigger = Animator.StringToHash("Attack");
        int AttackHitTrigger = Animator.StringToHash("AttackHit");

        bool _isPlayingAttackAnim;

        Animator _animator;
        Action _finishedAttackCallback;
        
        public AttackAnimationController(Animator animator)
        {
            _animator = animator;
        }

        public int PlayAttackAnimation(Action finishedAttackCallback)
        {
            _finishedAttackCallback = finishedAttackCallback;

            _animator.SetTrigger(AttackTrigger);

            _isPlayingAttackAnim = true;
            var teste = _animator.GetCurrentAnimatorStateInfo(0);
            return teste.fullPathHash;
        }

        public void PlayAttackHitAnimation()
        {
            _animator.SetTrigger(AttackHitTrigger);
        }


        public IEnumerator CheckAnimationHasEnded(int attackFullPathHash)
        {
            while (_isPlayingAttackAnim)
            {
                if (_animator.GetCurrentAnimatorStateInfo(0).fullPathHash != attackFullPathHash)
                {
                    _finishedAttackCallback.Invoke();
                    _isPlayingAttackAnim = false;
                }

                yield return new WaitForSeconds(0.1f);
            }
        }

    }
}
