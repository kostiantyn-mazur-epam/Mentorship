using Epam.Mentoring.MemoryManagement.GC.Zoo.Animals;

namespace Epam.Mentoring.MemoryManagement.GC.Zoo
{
    public interface IAnimalReceiver
    {
        void Receive(IAnimal animal);
    }
}