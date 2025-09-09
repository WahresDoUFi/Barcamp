using System.Numerics;
using Barcamp.Utilities;

namespace Barcamp.Foods
{
    internal class Birdfood : Food
    {
        public Birdfood(Scene scene, Action<Food, Vector2> dropCallback) : base(scene.AddSprite(SpriteType.BirdFood, 0.2f), dropCallback)
        {
            sprite.X = 520;
            sprite.Y = 600;
            filling = 1f;
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
