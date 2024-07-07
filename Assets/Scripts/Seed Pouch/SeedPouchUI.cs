using System;
using UnityEngine;

public class SeedPouchUI : MonoBehaviour
{
    [SerializeField]
    private GameObject freshbud;

    [SerializeField]
    private GameObject bloom;

    [SerializeField]
    private GameObject glowlush;

    [SerializeField]
    private GameObject sparktip;

    [SerializeField]
    private CropInformation cropInformation; 

    public event Action OnFreshbud,
        OnBloom, OnGlowlush, OnSparktip;
    private void DeselectSeasons()
    {
        freshbud.SetActive(false);
        bloom.SetActive(false);
        glowlush.SetActive(false);
        sparktip.SetActive(false);
        cropInformation.ClearCropInfo();
    }

    public void FreshbudTab()
    {
        DeselectSeasons();
        freshbud.SetActive(true);
        OnFreshbud?.Invoke();
    }

    public void BloomTab()
    {
        DeselectSeasons();
        bloom.SetActive(true);
        OnBloom?.Invoke();
    }

    public void GlowlushTab()
    {
        DeselectSeasons();
        glowlush.SetActive(true);
        OnGlowlush?.Invoke();
    }

    public void SparktipTab()
    {
        DeselectSeasons();
        sparktip.SetActive(true);
        OnSparktip?.Invoke();
    }

}
