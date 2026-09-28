namespace PersonalPlatformer;

public class CoinHandler
{
    public int coinsCollected = 0;
    public void SubscribeCoin(Coin coin)
    {
        coin.OnCoinCollision += () => coinsCollected++;
    }
}