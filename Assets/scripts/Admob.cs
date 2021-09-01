using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class Admob : MonoBehaviour
{
    private BannerView bannerView;

    private InterstitialAd interstitial;

    public static Admob instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Admob dans la scène");
            return;
        }

        instance = this;
    }

    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner(); 
    }

    public void ShowInterstitial()
    {
        RequestInterstitial();
    }

    public void RequestInterstitial()
    {
        string interstitialUnitId = "ca-app-pub-4560262580368870/1994989867";

        if (interstitial != null)
            interstitial.Destroy();

        interstitial = new InterstitialAd(interstitialUnitId);
        interstitial.OnAdLoaded += HandleOnAdLoaded;

        interstitial.LoadAd(CreateNewRequest());
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        if (interstitial.IsLoaded())
             interstitial.Show();
    }

    private AdRequest CreateNewRequest()
    {
        return new AdRequest.Builder().Build();
    }

    private void RequestBanner()
    {

        string bannerUnitId = "ca-app-pub-4560262580368870/8920540618";

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(bannerUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }
}
