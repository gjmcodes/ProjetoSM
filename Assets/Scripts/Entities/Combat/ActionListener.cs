using Assets.Scripts.Interfaces.Actions;
using Assets.Scripts.Managers;
using System;

namespace Assets.Scripts.Entities.Combat
{
    public class ActionListener : IActionListener
    {
        private Func<bool> _impedingActionDelegate;

        public ActionListener(Func<bool> impedingActionDelegate, ActionManager actionManager)
        {
            _impedingActionDelegate = impedingActionDelegate;
            actionManager.Subscribe(this);
        }

        public bool HasImpedingActionRunning()
        {
            return _impedingActionDelegate.Invoke();
        }
    }
}
