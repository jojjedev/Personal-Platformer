namespace PersonalPlatformer;

public class EventBus
{
    public delegate void ScoreEvent(int amount);
    public event ScoreEvent GainScore;

    public void PublishScore(int amount)
    {
        GainScore?.Invoke(amount);
    }
    
}