using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteUI : MonoBehaviour
{
    public Button nextLevelButton;
    public Button previousLevelButton;
    public Button restartLevelButton;

    private void Start()
    {
        gameObject.SetActive(false);

        nextLevelButton.onClick.AddListener(LevelManager.LoadNextLevel);
        previousLevelButton.onClick.AddListener(LevelManager.LoadPreviousLevel);
        restartLevelButton.onClick.AddListener(LevelManager.RestartLevel);
    }

    public void OnLevelCompleted()
    {
        gameObject.SetActive(true);

        nextLevelButton.interactable = (SceneManager.GetActiveScene().buildIndex < LevelManager.highestLevelUnlocked);

        previousLevelButton.interactable = (SceneManager.GetActiveScene().buildIndex >= 1);
    }
}