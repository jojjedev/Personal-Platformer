using SFML.Window;
using SFML.System;
using SFML.Graphics;
namespace PersonalPlatformer;

class Program
{
    public const int SCREEN_WIDTH = 800;
    public const int SCREEN_HEIGHT = 600;
    
    static void Main(string[] args)
    {
        for (int i = 0; i <= 42; i++)
        {
            Console.WriteLine($"p {(i * 18)} 590");
        }
        using (RenderWindow window = new RenderWindow(
                   new VideoMode(SCREEN_WIDTH, SCREEN_HEIGHT), "Platformer"))
        {  
            Scene scene = new Scene();
            scene.Load("level0");
            window.Closed += (o, e) => window.Close();
            Clock clock = new Clock();
            while (window.IsOpen)
            {
                window.SetView(new View(
                    scene.scenePosition,
                    new Vector2f(SCREEN_WIDTH / 2, SCREEN_HEIGHT / 2)));
                float dt = clock.Restart().AsSeconds();
                window.DispatchEvents();
                //TODO UPDATES
                scene.UpdateAll(dt);
                window.Clear();
                // TODO DRAWING
                scene.RenderAll(window);
                window.Display();
            }
        }
    }
}