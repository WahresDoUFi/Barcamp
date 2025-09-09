using Barcamp.Foods;

namespace Barcamp.Behaviors.Eat;

public interface IEatBehavior
{
    void Eat(Animal animal, Food droppedFood);
}