using System.Numerics;
using Barcamp.Utilities;

namespace Barcamp.Foods
{
    internal class Dogfood : Food
    {
        public Dogfood(Scene scene, Action<Food, Vector2> dropCallback) : base(scene.AddSprite(SpriteType.DogFood, 0.3f), dropCallback)
        {
            sprite.X = 750;
            sprite.Y = 550;
            filling = 1.5f;
            amount = 10;
        }

        public override float Eat()
        {
            amount--;
            return filling;
        }

        public override void Update()
        {
            amount += 0.01f;
            sprite.visible = amount >= 1;
        }
    }
}
