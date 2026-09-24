using System.Text;
using Platformer;
using SFML.Graphics;
using SFML.System;

namespace PersonalPlatformer;

public class Scene
{
    private Dictionary<string, Texture> textures;
    private List<Entity> entities;
    private string nextScene;
    private string currentScene;
    public Vector2f scenePosition = new Vector2f(300, 200);
    public Scene()
    {
        textures = new Dictionary<string, Texture>();
        entities = new List<Entity>();
    }

    public bool TryMove(Entity entity, Vector2f movement)
    {
        entity.Position += movement;
        bool collided = false;
        for (int i = 0; i < entities.Count; i++)
        {
            Entity other = entities[i];
            if (!other.Solid) continue;
            if (other == entity) continue;

            FloatRect BoundsA = entity.Bounds;
            FloatRect BoundsB = other.Bounds;
            if (Collision.RectangleRectangle(BoundsA, BoundsB, out Collision.Hit hit))
            {
                entity.Position += hit.Normal * hit.Overlap;
                i = -1;
                collided = true;
            }
            
        }

        return collided;
    }

    public void Load(string scene)
    {
        nextScene = scene;
    }

    public void Reload()
    {
        nextScene = currentScene;
    }

    private void HandleSceneChange()
    {
        if (nextScene == null) return;
        entities.Clear();
        Spawn(new Background());

        string file = $"assets/{nextScene}.txt";
        Console.WriteLine($"Loading scene '{file}'");

        foreach (string line in File.ReadLines(file, Encoding.UTF8))
        {
            if (line.Length != 0)
            {
                string parsed = line.Trim();
                int commentAt = parsed.IndexOf('#');
                if (commentAt >= 0)
                {
                    parsed = parsed.Substring(0, commentAt);
                    parsed = parsed.Trim();
                }

                string[] words = parsed.Split(" ");
                Vector2f position = new Vector2f();
                switch (words[0])
                {
                    case "d":
                        Door door = new Door();
                        door.Position = new Vector2f(float.Parse(words[1]), float.Parse(words[2]));
                        nextScene = words[3];
                        Spawn(door);
                        break;
                    case "k":
                        Key key = new Key();
                        key.Position = new Vector2f(float.Parse(words[1]), float.Parse(words[2]));
                        Spawn(key);
                        break;
                    case "p":
                        Platform platform = new Platform();
                        platform.Position = new Vector2f(float.Parse(words[1]), float.Parse(words[2]));
                        Spawn(platform);
                        break;
                    case "h":
                        Hero hero = new Hero();
                        hero.Position = new Vector2f(float.Parse(words[1]), float.Parse(words[2]));
                        Spawn(hero);
                        break;
                }

            }
        }

        currentScene = nextScene;
        nextScene = null;
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
        HandleSceneChange();
        for (int i = entities.Count -1; i >= 0; i--) // Om en entity skapar en ny entity i sin update funktion vill
                                                  // man inte att den nya ska köra sin update i samma frame som den skapades, utan vänta till nästa.
        {
            Entity entity = entities[i];
            if (entity is Hero) scenePosition = entity.Position;

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