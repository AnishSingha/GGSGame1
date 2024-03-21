using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerHealth
{
    public class PlayerLives : MonoBehaviour
    {
        public static PlayerLives instance;


        public int maxDeathsBeforeLoseLife = 3; // The number of deaths before the player loses a life

        private void Awake()
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

            if (!PlayerPrefs.HasKey("totalLives"))
            {
                PlayerPrefs.SetInt("totalLives", 5);
            }

            //StartCoroutine(RechargeLives());


            Debug.Log(PlayerPrefs.GetInt("totalLives"));
        }

        private int currentDeaths = 0; // The current number of deaths

        public void PlayerDied()
        {
            int totalLives = PlayerPrefs.GetInt("totalLives"); 

            
            currentDeaths++;
           // Debug.Log(currentDeaths);



            if (currentDeaths >= maxDeathsBeforeLoseLife)
            {
                // Reset the death count
                currentDeaths = 0;
               // Debug.Log(currentDeaths);
                
                
                PlayerPrefs.SetInt("totalLives", totalLives - 1);
                PlayerPrefs.Save();


                if (totalLives <= 0)
                {
                    Debug.Log("Game Over");
                    
                }
            }
        }





        IEnumerator RechargeLives()
        {
            yield return new WaitForSeconds(5); // Wait for 5 minutes

            int totalLives = PlayerPrefs.GetInt("totalLives");

            if (totalLives < 5)
            {
                totalLives++;
                PlayerPrefs.SetInt("totalLives", totalLives);
                PlayerPrefs.Save();
                Debug.Log("recharged one life");
            }

            // Call the coroutine again to wait for the next recharge
            StartCoroutine(RechargeLives());
            
        }








    }
}
 