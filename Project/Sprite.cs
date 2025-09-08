using System;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;

namespace Barcamp
{
    public enum SpriteType
    {
        Dog
    }
    internal class Sprite
    {
        private static readonly Dictionary<SpriteType, string> paths = new()
        {
            {SpriteType.Dog, "Assets/Animals/Dog.png" }
        };
        Texture2D texture;
        public float X { get; set; }
        public float Y { get; set; }

        public event Action? OnClick;
        public event Action<Vector2>? OnDrop;

        private int visualX, visualY;
        protected bool isDraggable;
        private bool dragging;
        public Sprite(SpriteType type, float scale = 1f)
        {
            texture = Raylib.LoadTextureFromImage(Raylib.LoadImage(paths[type]));
            texture.Width = (int)(texture.Width * scale);
            texture.Height = (int)(texture.Height * scale);
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
