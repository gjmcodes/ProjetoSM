using Assets.Scripts.Constants;
using Assets.Scripts.Controllers.Combat;
using UnityEngine;

namespace Assets.Scripts.Controllers.Combat
{
    public class PlayerCombatInputController : MonoBehaviour
    {
        CombatController _attackController;
        KeyCode rightMouseButton = KeyCode.Mouse1;

        void Start()
        {
            _attackController = transform.parent
                .Find(ObjectsPathConstants.combatController)
                .GetComponent<CombatController>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && _attackController.CanAttack())
            {
                _attackController.CastAttack();
            }

            if (Input.GetKey(rightMouseButton) && _attackController.CanDefend())
            {
                _attackController.CastDefense();
            }
            else if (Input.GetKeyUp(rightMouseButton))
            {
                _attackController.ReleaseDefense();
            }
        }
    }
}
