using System.Numerics;
using Raylib_cs;

namespace Barcamp.Utilities
{
    public enum SpriteType
    {
        Dog,
        Cat,
        Snake,
        Turtle,
        Bird
    }
    internal class Sprite
    {
        private static readonly Dictionary<SpriteType, string> paths = new()
        {
            {SpriteType.Dog, "Assets/Animals/dog.png" },
            {SpriteType.Cat, "Assets/Animals/cat.png" },
            {SpriteType.Snake, "Assets/Animals/snake.png" },
            {SpriteType.Turtle, "Assets/Animals/turtle.png" },
            {SpriteType.Bird, "Assets/Animals/bird.png" }
        };
        
        Texture2D texture;
        public float X { get; set; }
        public float Y { get; set; }

        public event Action? OnClick;
        public event Action<Vector2>? OnDrop;

        public bool isDraggable;
        private int visualX, visualY;
        private bool dragging;

        private float defaultWidth, defaultHeight;
        public Sprite(SpriteType type, float scale = 1f)
        {
            SetSprite(type);
            SetScale(scale);
        }

        public void SetSprite(SpriteType type)
        {
            texture = Raylib.LoadTextureFromImage(Raylib.LoadImage(paths[type]));
            defaultWidth = texture.Width;
            defaultHeight = texture.Height;
        }

        public void SetScale(float scale)
        {
            texture.Width = (int)(defaultWidth * scale);
            texture.Height = (int)(defaultHeight * scale);
        }

        public void Draw()
        {
            Raylib.DrawTexture(texture, visualX, visualY, Color.White);
        }

        public void Update()
        {
            if (dragging)
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
                if (isDraggable && Raylib.IsMouseButtonPressed(MouseButton.Left))
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
