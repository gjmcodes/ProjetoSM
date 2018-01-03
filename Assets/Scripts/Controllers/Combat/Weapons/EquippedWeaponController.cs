using UnityEngine;


namespace Assets.Scripts.Controllers.Combat
{
    public class EquippedWeaponController : MonoBehaviour
    {
        [SerializeField]
        BaseWeaponController weaponController;

        void Start()
        {
            // TODO
            // Remover mock. A weaponController será definida sempre ao trocar de arma
            weaponController = transform.parent.Find("Renderer/Body/WeaponHolder/Weapon").transform.GetComponent<BaseWeaponController>();

        }
        public BaseWeaponController GetCurrentWeaponController()
        {
            return this.weaponController;
        }
  
    }
}
