using System.Numerics;
using Barcamp.Utilities;

namespace Barcamp.Foods
{
    internal class Turtlefood : Food
    {
        public Turtlefood(Scene scene, Action<Food, Vector2> dropCallback) : base(scene.AddSprite(SpriteType.TurtleFood, 0.3f), dropCallback)
        {
            sprite.X = 700;
            sprite.Y = 620;
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
