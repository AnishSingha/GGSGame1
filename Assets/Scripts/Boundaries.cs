using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerHealth
{

    public class Boundaries : BoundaryAbstract
    {

        private PlayerLives playerLives;
        public PlayerUIDisplayEvent playerUIDisplayEvent1;

        private void Start()
        {
            playerLives = FindObjectOfType<PlayerLives>();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {

                int currentLevel = SceneManager.GetActiveScene().buildIndex;

                other.gameObject.SetActive(false);
                playerLives.PlayerDied();
                DIsplayUI(playerUIDisplayEvent1);
               // SceneManager.LoadScene(currentLevel);
                Debug.Log(PlayerPrefs.GetInt("totalLives"));
            }
        }


        public void DIsplayUI(PlayerUIDisplayEvent playerUIDisplayEvent)
        {
            playerUIDisplayEvent.Die();
        }
    }
}
