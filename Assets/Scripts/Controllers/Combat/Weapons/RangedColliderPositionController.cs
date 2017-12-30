using UnityEngine;

namespace Assets.Scripts.Controllers.Combat
{
    public class RangedColliderPositionController : MonoBehaviour
    {
        public Transform originalParent;

        bool _isInMotion;

        private void OnEnable()
        {
            originalParent = this.transform.parent;
        }

        private void Update()
        {
            if (_isInMotion)
            {
                this.transform.Translate(Vector3.forward);
            }
        }
        public void ResetCollider()
        {
            this.transform.parent = originalParent;
            this.transform.position = new Vector3(0, 0, 0);
            _isInMotion = false;
            this.gameObject.SetActive(false);
        }

        public void SetInMotion()
        {
            _isInMotion = true;
        }

        public void SetInitialPosition(Transform combatManager)
        {
            this.transform.parent = combatManager;
            //this.transform.position = new Vector3(0,0,0);

            // usar a rotação do game object inteiro
            this.transform.localRotation = combatManager.parent.transform.localRotation;
        }
    }
}
