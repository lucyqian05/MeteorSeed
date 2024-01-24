using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairCustomizer : MonoBehaviour
{
    public BodyManager bodyManagerUp;
    public BodyManager bodyManagerDown;
    public BodyManager bodyManagerLeft;
    public BodyManager bodyManagerRight;

    [Header("Scriptable Objects")]
    public SO_CharacterBody characterBody;
    public SO_Player player;

    [Header("Sprite To Change")]
    public SpriteRenderer hairFront;
    public SpriteRenderer hairBack;

    [Header("Hair Front")]
    public List<Sprite> hairFrontOptions = new List<Sprite>();

    [Header("Hair Behind")]
    public List<Sprite> hairBackOptions = new List<Sprite>();

    [Header("Pixel Hair Styles")]
    public List<SO_BodyPart> pixelHairOptions = new List<SO_BodyPart>();

    
    string hairStyle = "Bob"; 
    string hairColor ="Black";
    bool backHair = true; 



    private static List<string> frontHairMasterList = new List<string>()
        {
            "BobBlack",
            "BobBlonde",
            "BobDarkBrown",
            "BobLightBrown",
            "BobOrange",
            "BobRed"
        };

    private static List<string> backHairMasterList = new List<string>()
        {
            "BobBlack",
            "BobBlonde",
            "BobDarkBrown",
            "BobLightBrown",
            "BobOrange",
            "BobRed"
        };

    public void SetHairStyle()
    {

        string frontHairCode = hairStyle + hairColor;
        string backHairCode = hairStyle + hairColor;

        int frontHairIndex = frontHairMasterList.BinarySearch(frontHairCode);
        int backHairIndex = 1;

        if (backHair)
        {
            hairBack.GetComponent<SpriteRenderer>().enabled = true;
            backHairIndex = backHairMasterList.BinarySearch(backHairCode);
        }
        else
        {
            hairBack.GetComponent<SpriteRenderer>().enabled = false;
        }
        

        hairFront.sprite = hairFrontOptions[frontHairIndex];
        hairBack.sprite = hairBackOptions[backHairIndex];

        player.hairFront = hairFrontOptions[frontHairIndex];
        player.hairBack = hairBackOptions[backHairIndex];

        characterBody.characterBodyParts[2].bodyPart = pixelHairOptions[frontHairIndex];
        bodyManagerUp.SetCharacterBodyClips();
        bodyManagerDown.SetCharacterBodyClips();
        bodyManagerLeft.SetCharacterBodyClips();
        bodyManagerRight.SetCharacterBodyClips();
        

    }


    //in the future when I get better at coding, maybe this can be written as an enum that gets selected by a field on the button idk 
    public void SetHairBlack()
    {
        hairColor = "Black";
        SetHairStyle();
    }

    public void SetHairBlonde()
    {
        hairColor = "Blonde";
        SetHairStyle();
    }

    public void SetHairDarkBrown()
    {
        hairColor = "DarkBrown";
        SetHairStyle();
    }

    public void SetHairLightBrown()
    {
        hairColor = "LightBrown";
        SetHairStyle();
    }

    public void SetHairOrange()
    {
        hairColor = "Orange";
        SetHairStyle();
    }

    public void SetHairRed()
    {
        hairColor = "Red";
        SetHairStyle();
    }

    public void SetHairBob()
    {
        hairStyle = "Bob";
        backHair = true;
        SetHairStyle();
    }

    public void SetHairBowl()
    {
        hairStyle = "Bowl";
        backHair = false;
        SetHairStyle();
    }

    public void SetHairCrew()
    {
        hairStyle = "Crew";
        backHair = false;
        SetHairStyle();
    }

    public void SetHairPonytail()
    {
        hairStyle = "Ponytail";
        backHair = true;
        SetHairStyle();
    }

}
