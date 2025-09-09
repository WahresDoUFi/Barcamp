using System.Numerics;
using Barcamp.Utilities;

namespace Barcamp.Foods
{
    internal class Catfood : Food
    {
        public Catfood(Scene scene, Action<Food, Vector2> dropCallback) : base(scene.AddSprite(SpriteType.CatFood), dropCallback)
        {
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
            amount += 0.1f;
            sprite.visible = amount >= 1;
        }
    }
}
