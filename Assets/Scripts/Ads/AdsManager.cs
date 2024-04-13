using UnityEngine;
using GoogleMobileAds.Api;
using TMPro;
using UnityEngine.UI;
using System;


public class AdsManager : MonoBehaviour
{

    //public TextMeshProUGUI totalCoins;


    public string appId = "";


#if UNITY_ANDROID

    string bannerId = "ca-app-pub-7719156302188907/1138961234";
    string interId = "ca-app-pub-7719156302188907/7337220847";
    string rewardedId = "ca-app-pub-7719156302188907/2957124140";

#endif
    BannerView bannerView;
    InterstitialAd interstitialAd;
    RewardedAd rewardedAd;

    private void Start()
    {
        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        MobileAds.Initialize(initStatus =>
        {
            print("AdsInitialized");

        });
    }

    #region Banner

    public void LoadBannerAd() 
    {
        CreateBannerAD();
        ListentoBannerEvents();

        if (bannerView == null)
        {
            CreateBannerAD();
        }

        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        print("loading Banner Ad");
        bannerView.LoadAd(adRequest);
    }

    public void DestroyBannerAd()
    {
        if (bannerView !=null)
        {
            bannerView.Destroy();
            bannerView = null;  
        }
    }

    void CreateBannerAD()
    {
        if (bannerView!=null)
        {
            DestroyBannerAd();
        }
        bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Top);
    }

    void ListentoBannerEvents()
    {
        bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner view loaded an ad with response : "
                + bannerView.GetResponseInfo());
        };
        // Raised when an ad fails to load into the banner view.
        bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner view failed to load an ad with error : "
                + error);
        };
        // Raised when the ad is estimated to have earned money.
        bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(("Banner view paid {0} {1}."+
                adValue.Value+
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        bannerView.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Banner view recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        bannerView.OnAdClicked += () =>
        {
            Debug.Log("Banner view was clicked.");
        };
        // Raised when an ad opened full screen content.
        bannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Banner view full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Banner view full screen content closed.");
        };
    }

    #endregion


    #region Interstitial

    public void LoadInterstitialAd() 
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;  
        }

        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        InterstitialAd.Load(interId, adRequest, (InterstitialAd ad, LoadAdError error) => {
            if (error!=null||ad==null)
            {
                print("Interstritial Failed to load!!");
                return;
            }

            print("Interstitial ad loaded!!" + ad.GetResponseInfo());
            interstitialAd = ad;
            InterstitialEvent(interstitialAd);
        
        });
    }

    public void ShowInterstitialAd()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
        }
        else
        {
            print("Interstitial ad not ready!!");

        }


    }

    public void InterstitialEvent(InterstitialAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(("Interstitial ad paid {0} {1}." +
                adValue.Value +
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Interstitial ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Interstitial ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Interstitial ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial ad full screen content closed.");
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    #endregion


    #region Rewarded

    public void LoadRewardedAd()
    {
        if (rewardedAd!=null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        RewardedAd.Load(rewardedId, adRequest,(RewardedAd ad, LoadAdError error) =>
        {
            if (error!=null||ad==null)
            {
                print("rewarded ad failed to load" + error);
                return;
            }
            
            print("rewarded ad loaded successfully");
            rewardedAd = ad;
            RewardedEvent(rewardedAd);


        });
    }

    public void ShowRewardedAd()
    {
        if (rewardedAd!= null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward)=> {
                //Give Reward to the player
            });

        }
        else
        {
            print("Rewarded ad not ready!!");
        }
    }

    public void RewardedEvent(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(("Rewarded ad paid {0} {1}."+
                adValue.Value+
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    #endregion
}
