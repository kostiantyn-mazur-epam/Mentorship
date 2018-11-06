using Epam.Mentoring.MemoryManagement.GC.Animals;

namespace Epam.Mentoring.MemoryManagement.GC
{
    public interface IAnimalStatusTracker
    {
        void IsInHunger(IAnimal animal);
        void Died(IAnimal animal);
    }
}