using System;

namespace Assets.Scripts.Interfaces.Actions
{
    public interface IActionCaster
    {
        void CastAction(Action actionToCast);
    }
}
