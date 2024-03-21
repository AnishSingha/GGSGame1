using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndPoint : LevelManager
{
  

    public LevelCompleteUI levelCompleteUI;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            levelCompleteUI.OnLevelCompleted();
            other.gameObject.SetActive(false);
            LevelManager.LevelCompleted(SceneManager.GetActiveScene().buildIndex);

            int coinCount = PlayerPrefs.GetInt("Coins");

            coinCount += Random.Range(0, 10);
            PlayerPrefs.SetInt("Coins", coinCount);
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetInt("Coins"));
            
        }
              
    }

  

}
