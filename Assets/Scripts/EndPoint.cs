using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndPoint : LevelManager
{
    private RewardOptions options;
    public PopupUI popupUI;
    public PlayerUIDisplayEvent playerUIDisplayEvent;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            playerUIDisplayEvent.Die();
            other.gameObject.SetActive(false);
            LevelManager.LevelCompleted(SceneManager.GetActiveScene().buildIndex);

            options.CoinReward();
        }

    }

  


}
