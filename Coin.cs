using Platformer;
using SFML.Graphics;
using SFML.System;

namespace PersonalPlatformer;

public class Coin : Entity
{
    public Coin() : base("tilemap")
    {
        sprite.TextureRect = new IntRect(198, 126, 18, 18);
        sprite.Origin = new Vector2f(9, 11);
    }

    public void Create(EventBus bus)
    {
        bus.GainScore += OnScoreGained;
    }
    private void OnScoreGained(int amount)
    {
        Console.WriteLine($"Gained {amount} points!");
    }
    public override void Update(Scene scene, float dt)
    {
        if (scene.FindByType<Hero>(out Hero hero))
        {
            if (Collision.RectangleRectangle(Bounds, hero.Bounds, out _))
            {
                Dead = true; 
                Create(scene.EventBus);
            }            
        }
        base.Update(scene, dt);
    }
}