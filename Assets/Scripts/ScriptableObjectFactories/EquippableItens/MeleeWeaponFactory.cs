using Assets.Scripts.Objects.Equippable;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjectFactories.EquippableItens
{
    public class MeleeWeaponFactory
    {
        [MenuItem("Assets/Create/Melee Weapon")]
        public static void CreateAsset()
        {
            MeleeWeapon asset = ScriptableObject.CreateInstance<MeleeWeapon>();

            AssetDatabase.CreateAsset(asset, "Resources/Data/Equippable Itens/Weapons/New Melee Weapon.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}
