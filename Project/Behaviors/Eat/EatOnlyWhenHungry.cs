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
    public void Eat(Animal animal)
    {
        if (animal.hunger < food.filling) return;
            animal.hunger -= food.Eat();
            animal.happiness += 1f;
            SoundPlayer.Play(soundType);
    }
}