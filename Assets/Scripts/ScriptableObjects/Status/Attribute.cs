using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Status
{
    [CreateAssetMenu(menuName = "Status/Attribute")]
    public class Attribute : ScriptableObject
    {
        public int maxValue;
        public int value;
    }
}
