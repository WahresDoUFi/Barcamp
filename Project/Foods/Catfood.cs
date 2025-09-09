using System.Numerics;
using Barcamp.Utilities;

namespace Barcamp.Foods
{
    internal class Catfood : Food
    {
        public Catfood(Sprite sprite, Action<Food, Vector2> dropCallback) : base(sprite, dropCallback)
        {
            amount = 10;
        }
    }
}
