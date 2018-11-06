using Epam.Mentoring.MemoryManagement.GC.Zoo.Animals;

namespace Epam.Mentoring.MemoryManagement.GC.Zoo
{
    public interface IAnimalStatusTracker
    {
        void IsInHunger(IAnimal animal);
        void Died(IAnimal animal);
    }
}