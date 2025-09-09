using Barcamp.Foods;
using Barcamp.Utilities;

namespace Barcamp.Animals
{
    internal class Cat : Animal
    {
        public Cat(Scene scene) : base(scene.AddSprite(SpriteType.Cat, 0.2f))
        {
            sprite.isDraggable = false;
            sprite.X = 850;
            sprite.Y = 95;
        }

        public override void Eat(Food food)
        {
            if (hunger < food.filling) return;
            if (food is Dogfood dogFood)
            {
                hunger -= food.Eat();
                food.amount--;
                SoundPlayer.Play(SoundType.Meowing);
            }
        }

        public override void Pet()
        {
            happiness++;
            SoundPlayer.Play(SoundType.Meowing);
            sprite.Flip();
        }

        public override void Update()
        {
            hunger += 0.1f;
            happiness -= 0.05f;
        }
    }
}
