using System.Numerics;
using Barcamp.Utilities;

namespace Barcamp.Foods
{
    internal class Turtlefood : Food
    {
        public Turtlefood(Sprite sprite, Action<Food, Vector2> dropCallback) : base(sprite, dropCallback)
        {
            amount = 10;
        }
    }
}
