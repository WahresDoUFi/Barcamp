namespace Barcamp.Behaviors.Update;

public class BaseUpdate : IUpdateBehavior
{
    public void Update(Animal animal)
    {
        animal.hunger += 0.05f;
        animal.happiness -= 0.01f;
    }
}