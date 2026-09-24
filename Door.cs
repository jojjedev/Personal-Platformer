using Platformer;
using SFML.Graphics;
using SFML.System;

namespace PersonalPlatformer;

public class Door : Entity
{
    public string NextRoom;
    public bool Unlocked;
    public Door() : base("tilemap")
    {
        sprite.TextureRect = new IntRect(180, 103, 18, 23);
        sprite.Origin = new Vector2f(9, 11);
    }

    public override void Update(Scene scene, float dt)
    {
        if (Unlocked) sprite.Color = Color.Black;
        if (scene.FindByType(out Hero hero))
        {
            if (Collision.RectangleRectangle(Bounds, hero.Bounds, out _))
            {
                if (Unlocked)
                {
                    scene.Load(NextRoom);
                }
            }
        }
    }
}