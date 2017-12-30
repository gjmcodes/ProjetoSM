using Assets.Scripts.Interfaces.Actions;
using System.Collections.Generic;

namespace Assets.Scripts.Observers
{
    public class ActionViabilityObserver
    {
        IActionListener[] _actionListeners;

        public ActionViabilityObserver(IActionListener[] actionListeners)
        {
            _actionListeners = actionListeners;
        }

        public bool CanCastAction()
        {
            for (int i = 0; i < _actionListeners.Length; i++)
            {
                if (_actionListeners[i].HasImpedingActionRunning())
                    return false;
            }

            return true;
        }
    }
}
