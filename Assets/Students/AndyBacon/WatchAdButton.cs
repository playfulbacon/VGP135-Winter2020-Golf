using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchAdButton : MonoBehaviour
{
    Button myButton;

    private void Awake()
    {
        myButton = GetComponent<Button>();
        
        AdsManager.instance.OnAdReady += OnAdReady;    
    }

    void Start()
    {
        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener(AdsManager.instance.ShowRewardedVideo);

        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = AdsManager.instance.IsAdReady();
    }

    void OnAdReady()
    {
        myButton.interactable = true;
    }
}
