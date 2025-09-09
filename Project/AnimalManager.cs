using System.Numerics;
using Barcamp.Animals;
using Barcamp.Utilities;

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
            animals.Add(new Cat(scene));
            animals.Add(new Turtle(scene));
            animals.Add(new Snake(scene));
        }

        //  This method will be called every frame
        public override void Update()
        {
            animals.ForEach(animal => animal.Update());
            foods.ForEach(food => food.Update());
        }

        private void FoodDropped(Food food, Vector2 position)
        {

        }
    }
}
