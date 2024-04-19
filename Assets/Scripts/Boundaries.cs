using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerHealth
{

    public class Boundaries : MonoBehaviour
    {

        private PlayerLives playerLives;
        private PlayerUIDisplayEvent playerUIDisplayEvent1;
        
        private void Start()
        {
            playerLives = FindObjectOfType<PlayerLives>();
            playerUIDisplayEvent1 = FindAnyObjectByType<PlayerUIDisplayEvent>();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {


                other.gameObject.SetActive(false);
                playerLives.ReduceHealth();
                DIsplayUI(playerUIDisplayEvent1);
                Debug.Log(PlayerPrefs.GetInt("totalLives"));
            }
        }


        public void DIsplayUI(PlayerUIDisplayEvent playerUIDisplayEvent)
        {
            playerUIDisplayEvent.Die();
        }
    }
}
