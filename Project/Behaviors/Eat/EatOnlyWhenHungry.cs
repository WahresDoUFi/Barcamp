using Barcamp.Behaviors.Eat;
using Barcamp.Foods;
using Barcamp.Utilities;

namespace Barcamp.Behaviors.Eat;

public class EatOnlyWhenHungry : IEatBehavior
{
    private readonly Food food;
    private readonly SoundType soundType;
    
    public EatOnlyWhenHungry(Food food, SoundType soundType)
    {
        this.food = food;
        this.soundType = soundType;
    }
    
    public void Eat(Animal animal, Food droppedFood)
    {
        if (droppedFood.GetType() != food.GetType()) return;
        
        if (animal.hunger < droppedFood.filling) return;
        animal.hunger -= droppedFood.Eat();
        animal.happiness += 1f;
        SoundPlayer.Play(soundType);
    }
}