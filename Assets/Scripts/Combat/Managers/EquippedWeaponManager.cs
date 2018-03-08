using Assets.Scripts.Animations.Managers;
using Assets.Scripts.ScriptableObjects.Items.Equippable.Weapons;
using UnityEngine;

namespace Assets.Scripts.Combat
{
    public class EquippedWeaponManager : MonoBehaviour
    {
        [SerializeField]
        BaseWeapon _equippedWeapon;

        [SerializeField]
        BaseWeapon _defaultWeapon;

        // TODO 
        // Remover (usado somente para testes)
        public Transform hand;

        public void EquipNewWeapon(BaseWeapon weaponToEquip)
        {
            AnimationsManager animationsManager = GetComponent<AnimationsManager>();
            animationsManager.OverrideAnimation(weaponToEquip.attackAnimation);
            _equippedWeapon = weaponToEquip;
            _equippedWeapon.InstantiateItemPrefab(hand);
        }

        public BaseWeapon GetEquippedWeapon()
        {
            if (_equippedWeapon == null)
                return _defaultWeapon;

            return _equippedWeapon;
        }
    }
}
