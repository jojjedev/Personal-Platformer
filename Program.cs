using SFML.Window;
using SFML.System;
using SFML.Graphics;
namespace PersonalPlatformer;

class Program
{
    private const int SCREEN_WIDTH = 1200;
    private const int SCREEN_HEIGHT = 800;
    
    static void Main(string[] args)
    {
        using (var window = new RenderWindow(
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
                    new Vector2f(600,400)));
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