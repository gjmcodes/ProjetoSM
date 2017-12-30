using Assets.Scripts.Controllers.Combat.Weapons;
using UnityEngine;

namespace Assets.Scripts.Controllers.Combat
{
    public class RangedCollidersPoolController : MonoBehaviour
    {
        public RangedWeaponColliderController GetAvailableRangedCollider()
        {
            Transform ranCollider = null;

            foreach (Transform collider in transform)
            {
                if (!collider.gameObject.activeInHierarchy)
                {
                    ranCollider = collider;
                    break;
                }
            }

            ranCollider.gameObject.SetActive(true);
            return ranCollider.GetComponent<RangedWeaponColliderController>();
        }
    }
}
