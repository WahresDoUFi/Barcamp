using Barcamp.Behaviors;
using Barcamp.Behaviors.Eat;
using Barcamp.Behaviors.Pet;
using Barcamp.Behaviors.Update;
using Barcamp.Utilities;
using Raylib_cs;

namespace Barcamp
{
    public class Animal
    {
        public float hunger;
        public float happiness;
        
        public readonly Sprite sprite;
        public required IEatBehavior eatBehavior;
        public required IPetBehavior petBehavior;
        public required IUpdateBehavior updateBehavior;


        public Animal(Sprite sprite)
        {
            this.sprite = sprite;
            sprite.OnClick += Pet;
        }

        public Rectangle GetRect()
        {
            return sprite.GetRect();
        }
        
        public void Eat() => eatBehavior.Eat(this);
        public void Pet() => petBehavior.Pet(this);
        public void Update() => updateBehavior.Update(this);
    }
}
