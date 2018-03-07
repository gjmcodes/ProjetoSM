using Assets.Scripts.Combat.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlayerInputs
{
    public class PlayerCombatInput : MonoBehaviour
    {
        [SerializeField]
        CombatManager _combatManager;

        private void OnEnable()
        {
            _combatManager = transform.root.GetComponentInChildren<CombatManager>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_combatManager.IsAttacking)
                    return;

                _combatManager.Attack();
            }
        }
    }
}
