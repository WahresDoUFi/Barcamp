using Barcamp;
using Raylib_cs;

namespace HelloWorld;

class Program
{
    public static void Main()
    {
        Raylib.InitWindow(1280, 800, "Tiere");
        var backgroundTexture = Raylib.LoadTextureFromImage(Raylib.LoadImage("Assets/background.jpg"));
        backgroundTexture.Width *= 2;
        backgroundTexture.Height *= 2;
        Raylib.SetTargetFPS(30);

        var scene = new Scene();
        scene.background = backgroundTexture;
        var dog = scene.AddSprite(SpriteType.Dog, 0.75f);
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();

            scene.Draw();
            Raylib.EndDrawing();
        }

        Raylib.UnloadTexture(backgroundTexture);
        Raylib.CloseWindow();
    }
}