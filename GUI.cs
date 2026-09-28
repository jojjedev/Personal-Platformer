using SFML.System;
using SFML.Graphics;

namespace PersonalPlatformer;

public class GUI
{
    private Text gui;
    private CoinHandler coinHandler;
    private Vector2f offset;
    public GUI(Scene scene, CoinHandler coinHandler)
    {
        gui = new Text();
        gui.CharacterSize = 24;
        gui.Font = new Font("assets/vcr.ttf");
        gui.FillColor = Color.Magenta;
        gui.OutlineColor = Color.Black;
        gui.OutlineThickness = 2;
        gui.Position = scene.scenePosition;
        offset = new Vector2f(-Program.SCREEN_WIDTH / 4 + 12, -Program.SCREEN_HEIGHT / 4 + 6);
        this.coinHandler = coinHandler;
    }

    public void Update(Scene scene)
    {
        gui.Position = scene.scenePosition + offset;
    }
    public void Render(RenderTarget target)
    {
        gui.DisplayedString = $"Coins: {coinHandler.coinsCollected}";
        target.Draw(gui);
    }
}