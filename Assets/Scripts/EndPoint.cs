using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndPoint : LevelManager, IRewardOptions
{
    public PopupUI popupUI;
    public PlayerUIDisplayEvent playerUIDisplayEvent;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            playerUIDisplayEvent.Die();
            other.gameObject.SetActive(false);
            LevelManager.LevelCompleted(SceneManager.GetActiveScene().buildIndex);

            AnyReward();
        }

    }


    //Rewarding Coins On Level Completion
    public void AnyReward()
    {

        int coinCount = PlayerPrefs.GetInt("Coins");
        coinCount += Random.Range(1, 10);

        PlayerPrefs.SetInt("Coins", coinCount);
        PlayerPrefs.Save();

        Debug.Log(PlayerPrefs.GetInt("Coins"));
    }
  


}
