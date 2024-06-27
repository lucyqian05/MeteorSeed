using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class CropInformation : MonoBehaviour
{
    [SerializeField]
    private GameObject cropInfo;

    [SerializeField]
    private Image cropImage;

    [SerializeField]
    private TMP_Text cropName;

    [SerializeField]
    private List<Image> companionCrops = new List<Image>();

    [SerializeField]
    private List<Image> antagonistCrops = new List<Image>();

    [SerializeField]
    private GameObject GO_cropImage;

    [SerializeField]
    private List<GameObject> GO_comCrops = new List<GameObject>();

    [SerializeField]
    private List<GameObject> GO_antCrops = new List<GameObject>();

    public void SetCropInfo(Sprite cropSprite, string seedName, List<Sprite> companionSeeds, List<Sprite> antagonistSeeds)
    {
        ClearCropInfo();
        cropInfo.SetActive(true);
        GO_cropImage.SetActive(true);
        cropImage.sprite = cropSprite;
        cropName.text = seedName;

        for (int i = 0; i < companionSeeds.Count; i++)
        {
            companionCrops[i].sprite = companionSeeds[i];
            GO_comCrops[i].SetActive(true);
        }

        for (int i = 0; i < antagonistSeeds.Count; i++)
        {
            antagonistCrops[i].sprite = antagonistSeeds[i];
            GO_antCrops[i].SetActive(true);
        }
    }

    public void DisableCropInfo()
    {
        cropInfo.SetActive(false);
    }

    public void ClearCropInfo()
    {
        cropName.text = " ";

        GO_cropImage.SetActive(false);

        for (int i = 0; i < 3; i++)
        {
            GO_comCrops[i].SetActive(false);
            GO_antCrops[i].SetActive(false);
        }

    }
}
