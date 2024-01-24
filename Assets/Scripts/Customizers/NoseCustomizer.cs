using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseCustomizer : MonoBehaviour
{
    [Header("Sprite To Change")]
    public SpriteRenderer noseSprite;

    [Header("Nose Types")]
    public List<Sprite> noseOptions = new List<Sprite>();

    [Header("Scriptable Object")]
    public SO_Player player;


    //Variables need to be public for manipulation from body customizer ------------------------
    [System.NonSerialized] public string noseSkintone = "NMM-";
    private string noseShape = "Nose1";



    private List<string> noseMasterList = new List<string>()
        {

            "CD-Nose1",
            "CD-Nose2",
            "CD-Nose3",
            "ND-Nose1",
            "ND-Nose2",
            "ND-Nose3",
            "NMD-Nose1",
            "NMD-Nose2",
            "NMD-Nose3",
            "NMM-Nose1",
            "NMM-Nose2",
            "NMM-Nose3",
            "NMP-Nose1",
            "NMP-Nose2",
            "NMP-Nose3",
            "NP-Nose1",
            "NP-Nose2",
            "NP-Nose3",
            "WP-Nose1",
            "WP-Nose2",
            "WP-Nose3"

        };




    public void SetNose()
    {

        string noseCode = noseSkintone + noseShape;

        int noseIndex = noseMasterList.BinarySearch(noseCode);

        noseSprite.sprite = noseOptions[noseIndex];
        player.nose = noseOptions[noseIndex];

    }

    public void SetNose1()
    {
        noseShape = "Nose1";
        SetNose(); 
    }

    public void SetNose2()
    {
        noseShape = "Nose2";
        SetNose();
    }

    public void SetNose3()
    {
        noseShape = "Nose3";
        SetNose();
    }

}
