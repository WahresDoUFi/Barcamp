using Raylib_cs;

namespace Barcamp.Utilities
{
    public class Scene
    {
        public Texture2D background;

        private List<Sprite> sprites = new();
        private readonly AnimalManager _animalManager;

        public Scene()
        {
            _animalManager = new AnimalManager() { scene = this };
            _animalManager.Start();
        }

        public Sprite AddSprite(SpriteType type, float scale = 1f)
        {
            var sprite = new Sprite(type, scale);
            sprite.isDraggable = true;
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
            _animalManager.Update();
            foreach (var sprite in sprites)
            {
                sprite.CheckDrag();
                sprite.Update();
            }
        }
    }
}
