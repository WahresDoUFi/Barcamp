using Barcamp.Foods;
using Barcamp.Utilities;

namespace Barcamp.Animals
{
    internal class Turtle : Animal
    {
        public Turtle(Scene scene) : base(scene.AddSprite(SpriteType.Turtle, 3f))
        {
            sprite.isDraggable = false;
            sprite.X = 1000;
            sprite.Y = 650;
        }

        public override void Eat(Food food)
        {
            if (hunger < food.filling) return;
            if (food is Turtlefood dogFood)
            {
                hunger -= food.filling;
                happiness += 1f;
                SoundPlayer.Play(SoundType.Squeaking);
            }
        }

        public override void Pet()
        {
            sprite.Flip();
        }

        public override void Update()
        {
            hunger += 0.05f;
            happiness -= 0.01f;
        }
    }
}
