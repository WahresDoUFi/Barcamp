using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Barcamp
{
    internal class Scene
    {
        public Texture2D background;

        private List<Sprite> sprites = new();

        public Sprite AddSprite(SpriteType type, float scale = 1f)
        {
            var sprite = new Sprite(type, scale);
            sprites.Add(sprite);
            return sprite;
        }
        public void RemoveSprite(Sprite sprite)
        {
            sprites.Remove(sprite);
        }
        public void Draw()
        {
            Raylib.DrawTexture(background, 0, 0, Color.White);
            UpdateAll();
            foreach (var sprite in sprites)
            {
                sprite.Draw();
            }
        }
        private void UpdateAll()
        {
            foreach (var sprite in sprites)
            {
                sprite.CheckDrag();
                sprite.Update();
            }
        }
    }
}
