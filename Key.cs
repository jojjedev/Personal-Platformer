using Platformer;
using SFML.Graphics;
using SFML.System;

namespace PersonalPlatformer;

public class Key : Entity
{
    public Key() : base("tilemap")
    {
        sprite.TextureRect = new IntRect(126, 18, 18, 18);
        sprite.Origin = new Vector2f(9, 9);
    }   

    public override void Update(Scene scene, float dt)
    {
        if (scene.FindByType(out Hero hero))
        {
            if (Collision.RectangleRectangle(Bounds, hero.Bounds, out _))
            {
                if (scene.FindByType(out Door door))
                {
                    door.Unlocked = true;
                    Dead = true;
                    Console.WriteLine("Key picked up");
                }
            }
        }
        base.Update(scene, dt);
    }
}