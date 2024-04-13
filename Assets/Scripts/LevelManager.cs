using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PlayerHealth;

public class LevelManager : MonoBehaviour
{
 

    public static int highestLevelUnlocked = 50;

    public static void LevelCompleted(int level)
    {
        if (level == highestLevelUnlocked)
        {
            highestLevelUnlocked++;
        }

        PlayerPrefs.SetInt("HighestLevelUnlocked", highestLevelUnlocked);
    }

    public static void LoadLevel(int level, bool deductLife = true)
    {
        if (level <= highestLevelUnlocked)
        {
            SceneManager.LoadScene(level);
            if (deductLife)
            {
                int totalLives = PlayerPrefs.GetInt("totalLives");
                PlayerPrefs.SetInt("totalLives", totalLives - 1);
            }
        }
        else
        {
            Debug.Log("Level " + level + " is not yet unlocked!");
        }

        
    }

    public static void LoadNextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        LoadLevel(currentLevel + 1);

    }

    public static void RestartLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        LoadLevel(currentLevel, false);
        

    }

    public static void LoadPreviousLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= 1)
        {
            LoadLevel(currentLevel - 1);
        }
        else
        {
            Debug.Log("There is no previous level!");
        }

    }

    private void Start()
    {
        highestLevelUnlocked = PlayerPrefs.GetInt("HighestLevelUnlocked", 50);
       
    }

   
}
