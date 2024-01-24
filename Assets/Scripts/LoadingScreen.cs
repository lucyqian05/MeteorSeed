using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject wishes;
    public GameObject nextButton;
    public GameObject previousButton;
    public GameObject wishButton;
    public GameObject progressSlider;
    public TMP_Text progressText;
    public Slider slider;

    private static bool created = false; 

    void Awake()
    {

        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true; 
        }


    }

    //Functions for the loading screen wish selection

    [Header("Wish List")]
    public List<Sprite> wishSprites = new List<Sprite>();
    private Image wishImage;
    private int wishIndex = 0;


    public void Start()
    {

        wishImage = wishes.GetComponent<Image>();

    }


    public void NextWish()
    {

        if (wishIndex < 4)
        {
            wishIndex++;
            wishImage.sprite = wishSprites[wishIndex];

        }

        else

        {
            wishIndex = 0;
            wishImage.sprite = wishSprites[wishIndex];
        }

    }

    public void PreviousWish()
    {

        if (wishIndex > 0)
        {
            wishIndex--;
            wishImage.sprite = wishSprites[wishIndex];

        }

        else

        {
            wishIndex = 4;
            wishImage.sprite = wishSprites[wishIndex];
        }

    }


    public void LockInWish()
    {
        nextButton.SetActive(false);
        previousButton.SetActive(false);
        wishButton.SetActive(false);

        progressSlider.SetActive(true);

    }




    //Functions for the actual loading screen 
    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }

    }
}
