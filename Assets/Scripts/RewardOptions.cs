using UnityEngine;

public class RewardOptions
{
    public void CoinReward()
    {
        int coinCount = PlayerPrefs.GetInt("Coins");
        coinCount += Random.Range(0, 10);

        PlayerPrefs.SetInt("Coins", coinCount);
        PlayerPrefs.Save();

        Debug.Log(PlayerPrefs.GetInt("Coins"));
    }




}