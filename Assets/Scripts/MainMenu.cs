using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button levelButtonPrefab; 
    public Transform levelButtonContainer; 

    void Start()
    {
        // Load the highest level unlocked
        int highestLevelUnlocked = PlayerPrefs.GetInt("HighestLevelUnlocked", 1);

        // The total number of levels in the game
        int totalLevels = SceneManager.sceneCountInBuildSettings - 1; // Assuming the main menu is the first scene

        for (int i = 1; i <= totalLevels; i++)
        {
            Button levelButton = Instantiate(levelButtonPrefab, levelButtonContainer);

            TextMeshProUGUI buttonText = levelButton.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.text = "Level " + i;
            }

            levelButton.interactable = (i <= highestLevelUnlocked);

            int level = i; 
            levelButton.onClick.AddListener(() => LevelManager.LoadLevel(level));
        }
    }
}