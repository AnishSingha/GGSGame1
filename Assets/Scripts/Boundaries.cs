using UnityEngine;

namespace PlayerHealth
{
    
    public class Boundaries : BoundaryAbstract
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
               
                
                other.gameObject.SetActive(false);
                playerLives.PlayerDied();
                LevelManager.RestartLevel();
                Debug.Log(PlayerPrefs.GetInt("totalLives"));
            }
        }
    }
}