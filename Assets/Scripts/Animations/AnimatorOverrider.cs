using UnityEngine;
using System.Linq;
using Assets.Scripts.Animations.Interfaces;
using System.Threading.Tasks;

namespace Assets.Scripts.Animations
{
    public class AnimatorOverrider : IAnimatorOverrider
    {
        public AnimatorOverrideController OverrideAnimatorController(RuntimeAnimatorController runtimeAnimatorController,
            AnimationClip newAnimationClip)
        {

                AnimatorOverrideController currentAnimatorController = runtimeAnimatorController as AnimatorOverrideController;
                AnimatorOverrideController newOverrideController = new AnimatorOverrideController();

                if (currentAnimatorController != null) //Use existing overrideController
                {
                    RuntimeAnimatorController originalRuntimeController = currentAnimatorController.runtimeAnimatorController;
                    newOverrideController.runtimeAnimatorController = originalRuntimeController;
                }
                else //If there's no existing overrideController, use a new one
                {
                    newOverrideController.runtimeAnimatorController = runtimeAnimatorController;
                }

                newOverrideController[newAnimationClip.name] = newAnimationClip;

                //Dispose pointer: Unity known issue.
                runtimeAnimatorController = null;

                return newOverrideController;
        }
    }
}
