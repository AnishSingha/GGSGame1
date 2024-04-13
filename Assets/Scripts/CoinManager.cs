using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int totalCoins;

    public void AddCoins(int coins)
    {
        totalCoins += coins;
    }

    public int GetCurrentCoins()
    {
        return totalCoins;
    }
}