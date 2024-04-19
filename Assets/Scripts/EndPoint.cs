using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Services.CloudSave;
using System.Threading.Tasks;
using Newtonsoft.Json;



public class EndPoint : LevelManager
{
    private PlayerUIDisplayEvent playerUIDisplayEvent;


    [Tooltip("Setup the range for giving players stars based on number of moves")]
    [SerializeField] protected int tripleStar = 3;
    [SerializeField] protected int doubleStar = 5;
    [SerializeField] protected int singleStar = 7;


    private void Start()
    {
        playerUIDisplayEvent = FindAnyObjectByType<PlayerUIDisplayEvent>();
        coinManager = FindAnyObjectByType<CoinManager>();
    }



    private async void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            playerUIDisplayEvent.Die();
            other.gameObject.SetActive(false);
            LevelManager.LevelCompleted(SceneManager.GetActiveScene().buildIndex);

            await AwardCoinsAsync();
            await AwardStarAsync();

            PlayerPrefs.SetInt("deathCount", 0);
        }

    }

    #region AwardCoin
    private CoinManager coinManager;

    private const string coinCountKey = "CoinCount";

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
    #endregion

    #region AwardStars



    private const string starCountKey = "StarCount";

    private async Task AwardStarAsync()
    {
        int currentStars = await GetStarCountAsync();

        int starsToAward = CheckRewardStats();

        currentStars += starsToAward;

        AddStars(starsToAward);

        await SaveStarCountAsync(currentStars);

        Debug.Log("Stars awarded: " + starsToAward);
        Debug.Log("Total stars: " + currentStars);
    }

    private async Task<int> GetStarCountAsync()
    {
        var cloudData = await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string> { starCountKey });

        if (cloudData.TryGetValue(starCountKey, out var item))
        {
            string json = JsonConvert.SerializeObject(item.Value);
            return JsonConvert.DeserializeObject<int>(json);
        }
        else
        {
            Debug.LogWarning("Star count not found in cloud data.");
            return 0;
        }
    }

    private async Task SaveStarCountAsync(int coinCount)
    {
        var data = new Dictionary<string, object> { { starCountKey, coinCount } };
        await CloudSaveService.Instance.Data.Player.SaveAsync(data);
    }

    private int totalStars;

    private void AddStars(int stars)
    {
        totalStars += stars;
    }


    private int CheckRewardStats()
    {
        int deathcount = PlayerPrefs.GetInt("deathCount");

        if (deathcount <= tripleStar)
        {
            return 3;
        }
        if (deathcount > tripleStar && deathcount <= doubleStar)
        {
            return 2;
        }
        if (deathcount >= doubleStar && deathcount <= singleStar)
        {
            return 1;
        }
        if (deathcount > singleStar)
        {
            return 0;
        }
        return 0;
    }

    #endregion
}


