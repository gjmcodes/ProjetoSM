using Assets.Scripts.Constants;
using Assets.Scripts.Controllers.Combat;
using Assets.Scripts.Managers.Combat;
using UnityEngine;

namespace Assets.Scripts.Managers.Combat
{
    public class PlayerCombatInputManager : MonoBehaviour
    {
        CombatManager _combatManager;

        KeyCode defenseButton = KeyCode.D;
        KeyCode attackButton = KeyCode.A;

        void Start()
        {
            _combatManager = this.transform.parent
                .Find(ObjectsPathConstants.combatManager)
                .GetComponent<CombatManager>();
        }

        void Update()
        {
            if (Input.GetKeyDown(attackButton) && !_combatManager.HasImpedingActionRunning())
            {
                _combatManager.AttackController.CastAttack();
            }

            if (Input.GetKey(defenseButton) && !_combatManager.HasImpedingActionRunning())
            {
                _combatManager.DefenseController.CastDefense();
            }
            else if (Input.GetKeyUp(defenseButton))
            {
                _combatManager.DefenseController.ReleaseDefense();
            }
        }
    }
}
