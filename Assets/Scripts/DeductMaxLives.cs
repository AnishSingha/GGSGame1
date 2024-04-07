using UnityEngine;

public class DeductMaxLives
{
    public void DeductLife()
    {
        int totalLives = PlayerPrefs.GetInt("totalLives");
        PlayerPrefs.SetInt("totalLives", totalLives - 1);
    }
}