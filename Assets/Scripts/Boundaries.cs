using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerHealth
{

    public class Boundaries : MonoBehaviour
    {

        private PlayerLives playerLives;
        
        
        private void Start()
        {
            playerLives = FindObjectOfType<PlayerLives>();
           
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {

                int currentlevel = SceneManager.GetActiveScene().buildIndex;
                other.gameObject.SetActive(false);
                playerLives.ReduceHealth();
                SceneManager.LoadScene(currentlevel);
                Debug.Log(PlayerPrefs.GetInt("totalLives"));
            }
        }


        
    }
}
