using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; 

public class LoadScreen : MonoBehaviour
{
    public TMP_Text progressText; 
    public Slider slider; 
    
    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex)); 
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%"; 

            yield return null; 
        }

    }
}
