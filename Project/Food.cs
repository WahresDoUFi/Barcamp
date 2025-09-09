using System.Numerics;
using Barcamp.Utilities;

namespace Barcamp
{
    internal abstract class Food
    {
        protected Sprite sprite;
        public float filling { get; protected set; }
        protected float amount;
        public Food(Sprite sprite, Action<Food, Vector2> dropCallback)
        {
            this.sprite = sprite;
            sprite.OnDrop += (position) => dropCallback.Invoke(this, position);
        }

        public abstract float Eat();
        public abstract void Update();
    }
}
