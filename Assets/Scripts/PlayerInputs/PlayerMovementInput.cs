using UnityEngine;

namespace Assets.Scripts.PlayerInputs
{
    public class PlayerMovementInput : MonoBehaviour
    {
        public float speed;

        Rigidbody rigidBody;

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            transform.Translate(x, 0, z);
        }

    }
}
