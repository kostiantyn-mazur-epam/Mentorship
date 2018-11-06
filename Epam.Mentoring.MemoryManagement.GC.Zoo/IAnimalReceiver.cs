using Epam.Mentoring.MemoryManagement.GC.Animals;

namespace Epam.Mentoring.MemoryManagement.GC
{
    public interface IAnimalReceiver
    {
        void Receive(IAnimal animal);
    }
}