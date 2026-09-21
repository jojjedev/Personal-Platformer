namespace PersonalPlatformer;

public class Scene
{
    private Dictionary<string, Entity> textures;
    private List<Entity> entities;
    private string nextScene;
    private string currentScene;

    public void UpdateAll(float dt)
    {
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].Update(this, dt);
        }
    }
}