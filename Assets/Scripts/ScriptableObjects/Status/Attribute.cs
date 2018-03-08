using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Status
{
    [CreateAssetMenu(menuName = "Status/Attribute")]
    public class Attribute : ScriptableObject
    {
        public float maxValue;
        public float value;

        protected virtual void OnEnable()
        {
            value = maxValue;
        }
    }
}
