using SFML.Graphics;

namespace PersonalPlatformer;

public class Scene
{
    private Dictionary<string, Texture> textures;
    private List<Entity> entities;
    private string nextScene;
    private string currentScene;

    public Scene()
    {
        textures = new Dictionary<string, Texture>();
        entities = new List<Entity>();
    }

    public void Load(string scene)
    {
        nextScene = scene;
    }

    public void Reload()
    {
        nextScene = currentScene;
    }
    public void Spawn(Entity entity)
    {
        entities.Add(entity);
        entity.Create(this);
    }
    
    public Texture LoadTexture(string name)
    {
        if (textures.TryGetValue(name, out Texture found))
        {
            return found;
        }
        string fileName = $"assets/{name}.png";
        Texture texture = new Texture(fileName);
        textures.Add(name,texture);
        return texture;
    }
    public void UpdateAll(float dt)
    {
        for (int i = entities.Count; i >= 0; i--) // Om en entity skapar en ny entity i sin update funktion vill
                                                  // man inte att den nya ska köra sin update i samma frame som den skapades, utan vänta till nästa.
        {
            Entity entity = entities[i];
            entity.Update(this, dt);
        }

        for (int i = 0; i < entities.Count; i++)
        {
            Entity entity = entities[i];
            if (entity.Dead) entities.RemoveAt(i);
            else i++;
        }
    }

    public void RenderAll(RenderTarget target)
    {
        foreach (Entity entity in entities)
        {
            entity.Render(target);
        }
    }
}