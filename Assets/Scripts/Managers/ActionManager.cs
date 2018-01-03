using Assets.Scripts.Interfaces.Actions;
using Assets.Scripts.Observers;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Notes: IActionLIsteners must be assigned through the editor
/// </summary>
namespace Assets.Scripts.Managers
{
    public class ActionManager : MonoBehaviour
    {
        public ActionViabilityObserver ActionViabilityObserver { get; private set; }

        IActionListener[] _actionListeners;

        private void Start()
        {
            ActionViabilityObserver = new ActionViabilityObserver(_actionListeners);
        }

        public void Subscribe(IActionListener actionListener)
        {
            int length;
            if(_actionListeners == null)
            {
                length = 1;
            }
            else
            {
                length = _actionListeners.Length + 1;
            }

            _actionListeners = new IActionListener[length];

            _actionListeners[length-1] = actionListener;
        }
    }
}
