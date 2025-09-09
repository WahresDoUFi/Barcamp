using Raylib_cs;

namespace Barcamp.Utilities;

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