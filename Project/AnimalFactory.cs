using Barcamp.Behaviors.Eat;
using Barcamp.Behaviors.Pet;
using Barcamp.Behaviors.Update;
using Barcamp.Foods;
using Barcamp.Utilities;

namespace Barcamp;

public class AnimalFactory
{
    public static Animal CreateDog(Scene scene, Food food)
    {
        var sprite = scene.AddSprite(SpriteType.Dog, 0.2f);
        sprite.X = 380;
        sprite.Y = 360;
        sprite.isDraggable = false;

        return new Animal(sprite)
        {
            eatBehavior = new EatAlways(food, SoundType.Barking),
            petBehavior = new PetHappyAndSound(SoundType.Barking),
            updateBehavior = new BaseUpdate()
        };
    }
}