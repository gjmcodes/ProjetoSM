namespace Assets.Scripts.Interfaces.Observers
{
    public interface IObserver
    {
        void Subscribe(IListener notifiable);
        void Unsubscribe(IListener notifiable);
        void NotifySubscribers();
    }
}
