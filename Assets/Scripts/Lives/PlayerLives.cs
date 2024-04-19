using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerHealth
{
    public class PlayerLives : MonoBehaviour
    {
        public static PlayerLives instance;
        

        [Tooltip("Setup the range for giving players stars based on number of moves")]
        [SerializeField] protected int tripleStar = 3;
        [SerializeField] protected int doubleStar = 5;
        [SerializeField] protected int singleStar = 7;

        private void Awake()
        {
            InstanceCreation();
            NullCheck();

            //StartCoroutine(RechargeLives());
           
            Debug.Log(PlayerPrefs.GetInt("totalLives"));
        }

       

        private static void NullCheck()
        {
            if (!PlayerPrefs.HasKey("totalLives"))
            {
                PlayerPrefs.SetInt("totalLives", 5);
            }
          
        }

        private void InstanceCreation()
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
        }

        

        public void ReduceHealth()
        {
            int deathcount = PlayerPrefs.GetInt("deathCount");
            PlayerPrefs.SetInt("deathCount", deathcount + 1);
            PlayerPrefs.Save();

            Debug.Log(PlayerPrefs.GetInt("deathCount"));
        }

        /*IEnumerator RechargeLives()
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
            
        }*/


    }
}
