using System.Numerics;
using Raylib_cs;

namespace Barcamp.Utilities
{
    public enum SpriteType
    {
        Dog,
        DogFood,
        Cat,
        CatFood,
        Snake,
        SnakeFood,
        Turtle,
        TurtleFood,
        Bird,
        BirdFood
    }
    internal class Sprite
    {
        private static readonly Dictionary<SpriteType, string> paths = new()
        {
            {SpriteType.Dog, "Assets/Animals/dog.png" },
            {SpriteType.DogFood, "Assets/Animals/dogfood.png" },
            {SpriteType.Cat, "Assets/Animals/cat.png" },
            {SpriteType.CatFood, "Assets/Animals/catfood.png" },
            {SpriteType.Snake, "Assets/Animals/snake.png" },
            {SpriteType.SnakeFood, "Assets/Animals/snakefood.png" },
            {SpriteType.Turtle, "Assets/Animals/turtle.png" },
            {SpriteType.TurtleFood, "Assets/Animals/turtlefood.png" },
            {SpriteType.Bird, "Assets/Animals/bird.png" },
            {SpriteType.BirdFood, "Assets/Animals/birdfood.png" }
        };

        Image image;
        Texture2D texture;
        public float X { get; set; }
        public float Y { get; set; }

        public event Action? OnClick;
        public event Action<Vector2>? OnDrop;

        public bool visible = true;
        public bool isDraggable = false;
        private int visualX, visualY;
        private float scale;
        private bool dragging;

        private float defaultWidth, defaultHeight;
        public Sprite(SpriteType type, float scale = 1f)
        {
            SetSprite(type);
            SetScale(scale);
        }

        public void SetSprite(SpriteType type)
        {
            image = Raylib.LoadImage(paths[type]);
            texture = Raylib.LoadTextureFromImage(image);
            defaultWidth = texture.Width;
            defaultHeight = texture.Height;
        }

        public void SetScale(float scale)
        {
            this.scale = scale;
            texture.Width = (int)(defaultWidth * scale);
            texture.Height = (int)(defaultHeight * scale);
        }

        public void Flip()
        {
            Raylib.ImageFlipHorizontal(ref image);
            texture = Raylib.LoadTextureFromImage(image);
            SetScale(scale);
        }

        public void Draw()
        {
            if (visible)
            {
                Raylib.DrawTexture(texture, visualX, visualY, Color.White);
            }
        }

        public void Update()
        {
            if (dragging && isDraggable)
            {
                var mousePos = Raylib.GetMousePosition();
                visualX = (int)mousePos.X;
                visualY = (int)mousePos.Y;
            } else
            {
                visualX = (int)X;
                visualY = (int)Y;
            }
        }

        public void CheckDrag()
        {
            if (dragging == false)
            {
                if (Raylib.IsMouseButtonPressed(MouseButton.Left))
                {
                    var mousePos = Raylib.GetMousePosition();
                    if (Raylib.CheckCollisionPointRec(mousePos, new Rectangle(visualX, visualY, texture.Width, texture.Height)))
                    {
                        dragging = true;
                        OnClick?.Invoke();
                        return;
                    }
                }
            } else if (Raylib.IsMouseButtonReleased(MouseButton.Left))
            {
                OnDrop?.Invoke(Raylib.GetMousePosition());
                dragging = false;
            }
        }
    }
}
