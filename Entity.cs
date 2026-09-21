using SFML.Graphics;

namespace PersonalPlatformer;

public class Entity : Scene
{
    private readonly string textureName;
    protected readonly Sprite sprite;
    public bool Dead;

    public Entity(string textureName)
    {
        this.textureName = textureName;
        sprite = new Sprite();
    }
    public virtual void Update(Scene scene, float dt){}

    public virtual void Render(RenderTarget target)
    {
        target.Draw(sprite);
    }
}