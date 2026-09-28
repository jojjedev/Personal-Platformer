using Platformer;
using SFML.Graphics;
using SFML.System;

namespace PersonalPlatformer;

public class Coin : Entity
{
    public event Action OnCoinCollision;
    public Coin() : base("tilemap")
    {
        sprite.TextureRect = new IntRect(198, 126, 18, 18);
        sprite.Origin = new Vector2f(9, 11);

    }
    
    public override void Update(Scene scene, float dt)
    {
        if (scene.FindByType<Hero>(out Hero hero))
        {
            if (Collision.RectangleRectangle(Bounds, hero.Bounds, out _))
            {
                OnCoinCollision?.Invoke();
                Dead = true;
            }            
        }
        base.Update(scene, dt);
    }
}