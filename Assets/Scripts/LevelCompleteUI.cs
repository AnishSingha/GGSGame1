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
        

        nextLevelButton.onClick.AddListener(LevelManager.LoadNextLevel);
        previousLevelButton.onClick.AddListener(LevelManager.LoadPreviousLevel);
        restartLevelButton.onClick.AddListener(LevelManager.RestartLevel);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            previousLevelButton.interactable = false;
        }
    }

    /*public void OnLevelCompleted()
    {
        

        nextLevelButton.interactable = (SceneManager.GetActiveScene().buildIndex < LevelManager.highestLevelUnlocked);

        previousLevelButton.interactable = (SceneManager.GetActiveScene().buildIndex >= 1);
    }
*/
   



}