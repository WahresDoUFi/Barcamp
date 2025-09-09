using Barcamp.Foods;
using Barcamp.Utilities;

namespace Barcamp.Animals
{
    internal class Dog : Animal
    {
        public Dog(Scene scene) : base(scene.AddSprite(SpriteType.Dog, 0.2f))
        {
            sprite.isDraggable = false;
            sprite.X = 380;
            sprite.Y = 360;
        }

        public override void Eat(Food food)
        {
            if (food is Dogfood)
            {
                hunger -= food.Eat();
                if (hunger < 0)
                {
                    happiness += hunger;
                    hunger = 0;
                }
                SoundPlayer.Play(SoundType.Barking);
            }
        }

        public override void Pet()
        {
            happiness++;
            SoundPlayer.Play(SoundType.Barking);
        }

        public override void Update()
        {
            hunger += 0.3f;
        }
    }
}
