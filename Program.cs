using SFML.Window;
using SFML.System;
using SFML.Graphics;
namespace PersonalPlatformer;

class Program
{
    private const int SCREEN_HEIGHT = 800;
    private const int SCREEN_WIDTH = 1200;

    static void Main(string[] args)
    {
        using (var window = new RenderWindow(
                   new VideoMode(SCREEN_WIDTH, SCREEN_HEIGHT), "Platformer"))
        {
            window.Closed += (o, e) => window.Close();
            Clock clock = new Clock();
            while (window.IsOpen)
            {
                float dt = clock.Restart().AsSeconds();
                window.DispatchEvents();
                //TODO UPDATES
                window.Clear();
                // TODO DRAWING
                window.Display();
            }
        }
}
}