using Barcamp.Foods;
using Barcamp.Utilities;

namespace Barcamp.Animals
{
    internal class Snake : Animal
    {
        public Snake(Scene scene) : base(scene.AddSprite(SpriteType.Snake, 0.1f))
        {
            sprite.Flip();
            sprite.isDraggable = false;
            sprite.X = 250;
            sprite.Y = 650;
        }

        public override void Eat(Food food)
        {
            if (hunger < food.filling) return;
            if (food is Snakefood dogFood)
            {
                hunger -= food.Eat();
                happiness += 3f;
                SoundPlayer.Play(SoundType.Hissing);
            }
        }

        public override void Pet()
        {
            sprite.Flip();
            SoundPlayer.Play(SoundType.Hissing);
        }

        public override void Update()
        {
            hunger += 0.01f;
            happiness -= 0.02f;
        }
    }
}
