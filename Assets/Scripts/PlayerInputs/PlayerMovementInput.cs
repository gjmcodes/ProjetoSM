using UnityEngine;

namespace Assets.Scripts.PlayerInputs
{
    public class PlayerMovementInput : MonoBehaviour
    {
        public float speed;

        private void Update()
        {
            var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            transform.Translate(0, 0, z);
        }
    }
}
