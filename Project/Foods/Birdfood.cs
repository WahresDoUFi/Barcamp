using System.Numerics;
using Barcamp.Utilities;

namespace Barcamp.Foods
{
    internal class Birdfood : Food
    {
        public Birdfood(Scene scene, Action<Food, Vector2> dropCallback) : base(scene.AddSprite(SpriteType.SnakeFood, 0.3f), dropCallback)
        {
            sprite.X = 200;
            sprite.Y = 530;
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
            amount += 0.1f;
            sprite.visible = amount >= 1;
        }
    }
}
