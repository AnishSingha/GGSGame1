using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Services.CloudSave;
using System.Threading.Tasks;
using Newtonsoft.Json;


public class EndPoint : LevelManager
{
    public PopupUI popupUI;
    public PlayerUIDisplayEvent playerUIDisplayEvent;
    [SerializeField] CoinManager coinManager;
    private const string coinCountKey = "CoinCount";

    private async void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            playerUIDisplayEvent.Die();
            other.gameObject.SetActive(false);
            LevelManager.LevelCompleted(SceneManager.GetActiveScene().buildIndex);

            await AwardCoinsAsync();
        }

    }


    private async Task AwardCoinsAsync()
    {
        int currentCoins = await GetCoinCountAsync();

        int coinsToAward = Random.Range(1, 11);

        currentCoins += coinsToAward;

        coinManager.AddCoins(coinsToAward);

        await SaveCoinCountAsync(currentCoins);

        Debug.Log("Coins awarded: " + coinsToAward);
        Debug.Log("Total coins: " + currentCoins);
    }

    private async Task<int> GetCoinCountAsync()
    {
        var cloudData = await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string> { coinCountKey });

        if (cloudData.TryGetValue(coinCountKey, out var item))
        {
            string json = JsonConvert.SerializeObject(item.Value);
            return JsonConvert.DeserializeObject<int>(json);
        }
        else
        {
            Debug.LogWarning("Coin count not found in cloud data.");
            return 0;
        }
    }

    private async Task SaveCoinCountAsync(int coinCount)
    {
        var data = new Dictionary<string, object> { { coinCountKey, coinCount } };
        await CloudSaveService.Instance.Data.Player.SaveAsync(data);
    }



}
