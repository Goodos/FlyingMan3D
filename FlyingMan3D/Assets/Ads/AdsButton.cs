using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdsButton : MonoBehaviour
{
    [SerializeField] private Button _skipLvl;
    [SerializeField] private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _skipLvl.onClick.AddListener(ShowAds);
        _skipLvl.gameObject.SetActive(AdsController.Instance.IsInterReady);
        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += UpdateBtn;
    }

    private void UpdateBtn(string s, MaxSdkBase.AdInfo adInfo)
    {
        _skipLvl.gameObject.SetActive(AdsController.Instance.IsInterReady);
    }

    private void ShowAds()
    {
        AdsController.Instance.ShowInter(() =>
        {
            gameManager.LoadNextLevel();
        });
    }

    private void OnDestroy()
    {
        _skipLvl.onClick.RemoveListener(ShowAds);  
        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent -= UpdateBtn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}