using Barcamp.Foods;
using Barcamp.Utilities;
using Raylib_cs;

namespace Barcamp.Animals
{
    internal class Bird : Animal
    {
        private readonly int startX = 50;
        private readonly int endX = 500;
        private readonly int yPos = 150;
        private readonly int upDownRange = 50;
        private readonly float flapSpeed = 0.25f;
        private readonly float moveSpeed = 90f;
        private double _time;
        private int direction = 1;
        public Bird(Scene scene) : base(scene.AddSprite(SpriteType.Bird, 0.15f))
        {
            sprite.isDraggable = false;
            sprite.X = startX;
            sprite.Y = yPos;
        }

        public override void Eat(Food food)
        {
            if (hunger < food.filling) return;
            if (food is Birdfood)
            {
                hunger -= food.Eat();
                happiness += 3f;
                SoundPlayer.Play(SoundType.Tweeting);
            }
        }

        public override void Pet()
        {
            SoundPlayer.Play(SoundType.Tweeting);
        }

        public override void Update()
        {
            UpdatePosition();
            ClampPosition();
            hunger += 0.01f;
            happiness -= 0.02f;
        }

        private void UpdatePosition()
        {
            _time += Math.PI * Raylib.GetFrameTime();
            sprite.X += moveSpeed * direction * Raylib.GetFrameTime();
            sprite.Y = ((float)Math.Sin(_time) * upDownRange) + yPos;
        }

        private void ClampPosition()
        {
            if (direction == 1)
            {
                if (sprite.X > endX)
                {
                    sprite.Flip();
                    direction = -1;
                }
            } else if (direction == -1)
            {
                if (sprite.X < startX)
                {
                    sprite.Flip();
                    direction = 1;
                }
            }
        }
    }
}
