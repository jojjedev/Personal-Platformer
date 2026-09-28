namespace PersonalPlatformer;

public class GUI
{
    private int coinsCollected;

    public void Create(EventBus bus)
    {
        bus.GainScore += (int amount) => coinsCollected += amount;
    }
}