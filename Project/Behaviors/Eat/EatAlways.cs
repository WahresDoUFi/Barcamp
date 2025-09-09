using Barcamp.Foods;
using Barcamp.Utilities;

namespace Barcamp.Behaviors.Eat;

public class EatAlways : IEatBehavior
{
    private readonly Food food;
    private readonly SoundType soundType;
    
    public EatAlways(Food food, SoundType soundType)
    {
        this.food = food;
        this.soundType = soundType;
    }

    public void Eat(Animal animal, Food droppedFood)
    {
        if (droppedFood.GetType() != food.GetType())
        {
            return;
        }
        
        animal.hunger -= droppedFood.Eat();
        if (animal.hunger < 0)
        {
            animal.happiness += animal.hunger;
            animal.hunger = 0;
        }
        SoundPlayer.Play(soundType);
    }
}