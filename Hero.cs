using System.Data;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace PersonalPlatformer;

public class Hero : Entity
{
    private bool faceRight = false;
    private const float jumpForce = 250.0f;
    private const float walkSpeed = 100.0f;
    private const float gravityForce = 500.0f;
    private float verticalSpeed;
    private bool isGrounded;
    private bool isUpPressed;
    public Hero() : base("characters")
    {
        sprite.TextureRect = new IntRect(0, 0, 24, 24);
        sprite.Origin = new Vector2f(12, 12);
    }

    public override void Update(Scene scene, float dt)
    {
        if (Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.Left))
        {
            scene.TryMove(this, new Vector2f(-100 * dt, 0));
            faceRight = false;
        }

        if (Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right))
        {
            scene.TryMove(this, new Vector2f(100 * dt, 0));
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