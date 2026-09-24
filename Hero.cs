using System.Data;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace PersonalPlatformer;

public class Hero : Entity // TODO: Fixa running animation och lås animering när man faller med bool.
{
    private bool faceRight = false;
    private const float jumpForce = 300.0f;
    private const float walkSpeed = 150.0f;
    private const float gravityForce = 500.0f;
    private float verticalSpeed;
    private bool isGrounded;
    private bool isUpPressed;
    private bool isMidAir;
    public Hero() : base("characters")
    {   
        sprite.TextureRect = new IntRect(0, 0, 24, 24);
        sprite.Origin = new Vector2f(12, 12);
    }

    public override FloatRect Bounds
    {
        get
        {
            var bounds = base.Bounds;
            bounds.Left += 3;
            bounds.Width -= 8;
            bounds.Top += 3;
            bounds.Height -= 3;
            return bounds;
        }
    }
    private bool isOutOfBounds()
    {
        return sprite.Position.X < 0 ||
                  sprite.Position.Y < 0 ||
                  sprite.Position.X >= Program.SCREEN_WIDTH ||
                  sprite.Position.Y>= Program.SCREEN_HEIGHT;
    }

    private void HeroMove(Scene scene, float dt)
    {
        if (isOutOfBounds())
        {
            Console.WriteLine("Test");
            scene.Reload();
        }
        if (Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.Left))
        {
            scene.TryMove(this, new Vector2f(-walkSpeed * dt, 0));
            faceRight = false;
        }

        if (Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right))
        {
            scene.TryMove(this, new Vector2f(walkSpeed * dt, 0));
            faceRight = true;
        }

        if (Keyboard.IsKeyPressed(Keyboard.Key.W) || Keyboard.IsKeyPressed(Keyboard.Key.Up) || Keyboard.IsKeyPressed(Keyboard.Key.Space))
        {
            if (isGrounded && !isUpPressed)
            {
                verticalSpeed = -jumpForce;
                isGrounded = false;
            }
            else isUpPressed = false;
        }

        isGrounded = false;
        Vector2f velocity = new Vector2f(0, verticalSpeed * dt);
        if (scene.TryMove(this, velocity))
        {
            if (verticalSpeed > 0.0f)
            {
                isGrounded = true;
                verticalSpeed = 0.0f;
            }
            else verticalSpeed = 0.5f * verticalSpeed;

        }
        verticalSpeed += gravityForce * dt;
        if (verticalSpeed > 500.0f) verticalSpeed = 500.0f;
    }
    public override void Update(Scene scene, float dt)
    {
        HeroMove(scene, dt);
        scene.SetScenePositon(this);
    }

    public override void Render(RenderTarget target)
    {
        sprite.Scale = new Vector2f(faceRight ? -1 : 1, 1);
        /*if (faceRight)      Samma som raden ovan.
        {
            sprite.Scale = new Vector2f(-1, 1);
        }
        else sprite.Scale = new Vector2f(1, 1);
        */
        base.Render(target);
    }
}