using UnityEngine;

public class KeyLoader : MonoBehaviour
{
    [SerializeField] GameObject keyPrefab; // The prefab for the key
    [SerializeField] Vector2 keySpawnPosition = new Vector2(0, 1); // The position where the key will spawn

    void Start()
    {
        // Get the current level
        int currentLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        // Check if the key was collected
        if (PlayerPrefs.GetInt("KeyCollectedInLevel" + currentLevel, 0) == 0)
        {
            // If the key was not collected, spawn the key at the specified position
            Instantiate(keyPrefab, keySpawnPosition, Quaternion.identity);
        }
    }
}