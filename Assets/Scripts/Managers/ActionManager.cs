using Assets.Scripts.Interfaces.Actions;
using Assets.Scripts.Observers;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Managers
{
    public class ActionManager : MonoBehaviour
    {
        public ActionViabilityObserver ActionViabilityObserver { get; private set; }

        IActionListener[] _actionListeners;

        [SerializeField]
        List<Transform> _actionListenersTransforms;

        private void Start()
        {
            if (_actionListenersTransforms == null || _actionListenersTransforms.Count == 0)
                return;

            _actionListeners = new IActionListener[_actionListenersTransforms.Count];

            for (int i = 0; i < _actionListenersTransforms.Count; i++)
            {
                var actionListener = _actionListenersTransforms[i].GetComponent<IActionListener>();

                if (actionListener == null)
                    throw new Exception("All Action Listeners Transforms must implement IActionListener interface");

                _actionListeners[i] = actionListener;
            }

            ActionViabilityObserver = new ActionViabilityObserver(_actionListeners);
        }
    }
}
