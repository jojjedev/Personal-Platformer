using Platformer;
using SFML.Graphics;

namespace PersonalPlatformer;

public class Breakable : Platform
{

    public Breakable()
    {
        sprite.TextureRect = new IntRect(126, 36, 18, 18);
    }

    public override void CheckHit(Scene scene)
    {
        if (scene.FindByType(out Hero hero))
        {
            if (Collision.RectangleRectangle(Bounds, hero.Bounds, out _))
            {
                /*if (hero.Position.Y - hero.Bounds.Height * 0.5f >= Position.Y + 6 
                    && hero.Position.X - hero.Bounds.Width * 0.5f >= Position.X - Bounds.Width
                    && hero.Position.X + hero.Bounds.Width * 0.5f <= Position.X + Bounds.Width) // Om kollisionen skedde när hero var under breakable objektet
                {
                    Dead = true; // Ta bort breakableobjektet
                }*/
                if (hero.verticalSpeed < 0 &&
                    Position.Y + Bounds.Height * 0.5f >= hero.Position.Y - hero.Bounds.Height * 0.5f &&
                    Position.Y + Bounds.Height * 0.5f <= hero.Position.Y + hero.Bounds.Height * 0.5f &&
                    Position.X - Bounds.Width * 0.5f <= hero.Position.X + hero.Bounds.Width * 0.5f &&
                    Position.X + Bounds.Width * 0.5f >= hero.Position.X - hero.Bounds.Width * 0.5f)
                {
                    Dead = true;
                }
            }
        }
    }
}