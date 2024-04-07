using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LevelCompleteUI : MonoBehaviour
{
    public static LevelCompleteUI instance;


    public Button nextLevelButton;
    public Button previousLevelButton;
    public Button restartLevelButton;

    private void Awake()
    {
        InstanceCreation();
    }
    private void Start()
    {
        

        nextLevelButton.onClick.AddListener(LevelManager.LoadNextLevel);
        previousLevelButton.onClick.AddListener(LevelManager.LoadPreviousLevel);
        restartLevelButton.onClick.AddListener(LevelManager.RestartLevel);
    }

    public void OnLevelCompleted()
    {
        

        nextLevelButton.interactable = (SceneManager.GetActiveScene().buildIndex < LevelManager.highestLevelUnlocked);

        previousLevelButton.interactable = (SceneManager.GetActiveScene().buildIndex >= 1);
    }

    private void InstanceCreation()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }



}