using UnityEngine;
using System.Linq;

namespace Assets.Scripts.ScriptableObjects.Status
{
    [CreateAssetMenu(menuName = "Status/HealthPoints")]
    public class HealthPoints : Attribute
    {
        public Attribute[] attributesForMaxPoints;

        protected override void OnEnable()
        {
            maxValue = attributesForMaxPoints.Sum(x => x.maxValue) / attributesForMaxPoints.Count();

            value = maxValue / 3;

            Debug.Log(value);
        }
    }
}
