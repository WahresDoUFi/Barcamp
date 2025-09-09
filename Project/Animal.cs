using Barcamp.Utilities;
using Raylib_cs;

namespace Barcamp
{
    internal abstract class Animal
    {
        protected readonly Sprite sprite;
        protected float hunger;
        protected float happiness;

        public Animal(Sprite sprite)
        {
            this.sprite = sprite;
            sprite.OnClick += Pet;
        }

        public Rectangle GetRect()
        {
            return sprite.GetRect();
        }

        public abstract void Eat(Food food);
        public abstract void Pet();
        public abstract void Update();
    }
}
