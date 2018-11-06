namespace Epam.Mentoring.MemoryManagement.GC
{
    //Subject
    public interface ILiveTicker
    {
        void Subscribe(ITickListener tickListener);
        void Unsubscribe(ITickListener tickListener);

    }

    //Observer
    public interface ITickListener
    {
        void OnTick();
    }
}