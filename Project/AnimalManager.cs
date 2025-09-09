using System.Numerics;
using Barcamp.Animals;
using Barcamp.Foods;
using Barcamp.Utilities;
using Raylib_cs;

namespace Barcamp
{
    internal class AnimalManager : SceneObject
    {
        private List<Food> foods = new();
        private List<Animal> animals = new();
        //  This method will be called once on loadup
        public override void Start()
        {
            animals.Add(new Dog(scene));

            foods.Add(new Snakefood(scene, FoodDropped));
            foods.Add(new Dogfood(scene, FoodDropped));
            foods.Add(new Catfood(scene, FoodDropped));
            foods.Add(new Turtlefood(scene, FoodDropped));
            foods.Add(new Birdfood(scene, FoodDropped));
        }

        //  This method will be called every frame
        public override void Update()
        {
            animals.ForEach(animal => animal.Update());
            foods.ForEach(food => food.Update());
        }

        private void FoodDropped(Food food, Vector2 position)
        {
            foreach (var animal in animals)
            {
                if (Raylib.CheckCollisionPointRec(position, animal.GetRect()))
                {
                    animal.Eat(food);
                }
            }
        }
    } 
}
