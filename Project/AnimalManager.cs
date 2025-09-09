using System.Numerics;
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

            var snakeFood = new Snakefood(scene, FoodDropped);
            var dogFood   = new Dogfood(scene, FoodDropped);
            var catFood   = new Catfood(scene, FoodDropped);
            var turtleFood = new Turtlefood(scene, FoodDropped);
            var birdFood   = new Birdfood(scene, FoodDropped);

            foods.Add(snakeFood);
            foods.Add(dogFood);
            foods.Add(catFood);
            foods.Add(turtleFood);
            foods.Add(birdFood);
            
            animals.Add(AnimalFactory.CreateDog(scene, dogFood));
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
