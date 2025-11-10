using UnityEngine;

public class UserStats
{
    public string playerName;

    public Vector3 playerPosition;

    public int playerMaxHealth;

    public int playerExp;

    public int playerMaxMana;
}

public static class Stats
{
    public static UserStats userStats = new UserStats();
}
