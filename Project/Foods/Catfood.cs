using System.Numerics;
using Barcamp.Utilities;

namespace Barcamp.Foods
{
    internal class Catfood : Food
    {
        public Catfood(Scene scene, Action<Food, Vector2> dropCallback) : base(scene.AddSprite(SpriteType.CatFood, 0.3f), dropCallback)
        {
            sprite.X = 1070;
            sprite.Y = 550;
            filling = 2f;
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
