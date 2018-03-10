using Assets.Scripts.ScriptableObjects.Status;
using UnityEngine;

namespace Assets.Scripts.Status.Managers
{
    public class StatusManager : MonoBehaviour
    {
        public Attribute strength;
        public Attribute dexterity;
        public Attribute intelligence;
        public HealthPoints healthPoints;

        private void Start()
        {
            Debug.Log(healthPoints.value);
        }

        public int GetValueByAttribute(Attribute attributeToCheck)
        {

            if (attributeToCheck == strength)
                return RoundAttributeValue(strength.value);

            if (attributeToCheck == dexterity)
                return RoundAttributeValue(dexterity.value);

            return RoundAttributeValue(intelligence.value);
        }

        public int RoundAttributeValue(float attributeValue)
        {
            return Mathf.RoundToInt(attributeValue);
        }

        public float CurrentLife()
        {
            return healthPoints.value;
        }

        public float ReduceLife(float amountToReduce)
        {
            healthPoints.value -= amountToReduce;
            Debug.Log("Current life: " + healthPoints.value);

            if (healthPoints.value <= 0)
                Die();

            return healthPoints.value;
        }

        public void Die()
        {

        }
    }
}
