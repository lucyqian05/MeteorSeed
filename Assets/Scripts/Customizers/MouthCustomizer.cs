using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthCustomizer : MonoBehaviour
{
    [Header("Sprite To Change")]
    public SpriteRenderer mouthSprite;

    [Header("Mouth Types")]
    public List<Sprite> mouthOptions = new List<Sprite>();

    [Header("Scriptable Object")]
    public SO_Player player;


    [System.NonSerialized] public string mouthSkintone = "NMM-";
    private string mouthShape = "Lip1";


    private List<string> mouthMasterList = new List<string>()
        {

            "CD-Lip1",
            "CD-Lip2",
            "ND-Lip1",
            "ND-Lip2",
            "NMD-Lip1",
            "NMD-Lip2",
            "NMM-Lip1",
            "NMM-Lip2",
            "NMP-Lip1",
            "NMP-Lip2",
            "NP-Lip1",
            "NP-Lip2",
            "WP-Lip1",
            "WP-Lip2"

        };



    public void SetLip()
    {

        string mouthCode = mouthSkintone + mouthShape;

        int mouthIndex = mouthMasterList.BinarySearch(mouthCode);

        mouthSprite.sprite = mouthOptions[mouthIndex];
        player.mouth = mouthOptions[mouthIndex];

    }



    public void SetLip1()
    {
        mouthShape = "Lip1";
        SetLip();
    }

    public void SetLip2()
    {
        mouthShape = "Lip2";
        SetLip();
    }

}
