using Unity.VisualScripting;
using UnityEngine;

public class KeyHandler : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        // Check if the player collected the key
        if (other.gameObject.tag == "Player")
        {
            // Get the current level
            int currentLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

            // Save that the key was collected
            PlayerPrefs.SetInt("KeyCollectedInLevel" + currentLevel, 1);
            PlayerPrefs.Save();

            // Destroy the key
            Destroy(gameObject);
        }
    }


}
