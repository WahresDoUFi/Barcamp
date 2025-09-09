using Barcamp.Utilities;

namespace Barcamp.Behaviors.Pet;

public class PetSpin : IPetBehavior
{
    public void Pet(Animal animal)
    {
        animal.sprite.Flip();
    }
}