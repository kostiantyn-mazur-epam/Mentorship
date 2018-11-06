namespace Epam.Mentoring.MemoryManagement.GC.Zoo.Animals
{
    //Inheriting IDisposable is overdesign, but every our animal needs to be disposed!!!
    public interface IAnimal//: IDisposable
    {
        void Eat(string eatName);
        int Age { get; }
        bool IsAlive { get; }
        void Kill();
        void Infect();
    }
}