using System.Data;
using SFML.Graphics;
using SFML.System;

namespace PersonalPlatformer;

public class Hero : Entity
{
    public Hero() : base("characters")
    {
        sprite.TextureRect = new IntRect(0, 0, 24, 24);
        sprite.Origin = new Vector2f(12, 12);
    }
}