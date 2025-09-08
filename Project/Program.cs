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

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            Raylib.DrawTexture(backgroundTexture, 0, 0, Color.White);

            Raylib.EndDrawing();
        }

        Raylib.UnloadTexture(backgroundTexture);
        Raylib.CloseWindow();
    }
}