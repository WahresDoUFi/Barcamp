using Raylib_cs;

namespace Barcamp.Behaviors.Update;

public class UpdateWithMovement : IUpdateBehavior
{
    private readonly int startX = 50;
    private readonly int endX = 500;
    private readonly int yPos = 150;
    private readonly int upDownRange = 50;
    private readonly float moveSpeed = 90f;
    private double _time;
    private int direction = 1;
    public void Update(Animal animal)
    {
        UpdatePosition(animal);
        ClampPosition(animal);
        animal.hunger += 0.01f;
        animal.happiness -= 0.02f;
    }

    private void UpdatePosition(Animal animal)
    {
        _time += Math.PI * Raylib.GetFrameTime();
        animal.sprite.X += moveSpeed * direction * Raylib.GetFrameTime();
        animal.sprite.Y = ((float)Math.Sin(_time) * upDownRange) + yPos;
    }

    private void ClampPosition(Animal animal)
    {
        if (direction == 1)
        {
            if (animal.sprite.X > endX)
            {
                animal.sprite.Flip();
                direction = -1;
            }
        } else if (direction == -1)
        {
            if (animal.sprite.X < startX)
            {
                animal.sprite.Flip();
                direction = 1;
            }
        }
    }
}