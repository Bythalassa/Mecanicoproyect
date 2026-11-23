public class BaseStats
{
    private int base_health;
    private int base_speed;

    public BaseStats(int _base_health, int _base_speed)
    {
        base_health = _base_health;
        base_speed = _base_speed;
    }

    public int BaseHealth => base_health;
    public int BaseSpeed => base_speed;
}