using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Items.Equippable
{
    public class BaseEquippable : BaseItem
    {
        public GameObject gameObjectPrefab;
        public float duration;

        public void InstantiateItemPrefab(Transform parent)
        {
            var instance = Instantiate(gameObjectPrefab);
            instance.transform.parent = parent;
        }
    }
}
