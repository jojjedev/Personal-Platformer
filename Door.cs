using SFML.Graphics;
using SFML.System;

namespace PersonalPlatformer;

public class Door : Entity
{
    public Door() : base("tilemap")
    {
        sprite.TextureRect = new IntRect(180, 103, 18, 23);
        sprite.Origin = new Vector2f(9, 11);
    }
}