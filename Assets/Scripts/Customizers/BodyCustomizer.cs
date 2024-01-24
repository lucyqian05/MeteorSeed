using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCustomizer : MonoBehaviour
{

    /// SPRITE GAME OBJECTS --------------------------------------------------------
    public BodyManager bodyManagerUp;
    public BodyManager bodyManagerDown;
    public BodyManager bodyManagerLeft;
    public BodyManager bodyManagerRight;




    /// HEADERS FOR THE INSPECTOR --------------------------------------------------
    [Header("Scriptable Objects")]
    public SO_CharacterBody characterBody;
    public SO_Player player; 

    [Header("Sprite To Change")]
    public SpriteRenderer bodySprite;

    [Header("Body Shapes")]
    public List<Sprite> bodyOptions = new List<Sprite>();

    [Header("Pixel Body Shapes")]
    public List<SO_BodyPart> pixelbodyOptions = new List<SO_BodyPart>();

    [Header("Clothing Customizers")]
    public TopCustomizer topCustomizer;
    public BottomCustomizer bottomCustomizer;
    public OnePieceCustomizer onePieceCustomizer;

    [Header("Facial Features Customizers")]
    public NoseCustomizer noseCustomizer;
    public MouthCustomizer mouthCustomizer;

    [Header("Bottom and OnePiece Sprites")]
    public GameObject bottomGameObject;
    public GameObject onePieceGameObject;




    /// Variables used to hold the name of the current customized selection --------
    string bodyShape = "Female_Body2_";
    string skinTone = "NMM";
    string pixelSkinTone = "NMM";
    string pixelBody = "FEMM-";




    private List<string> bodyShapeMasterList = new List<string>()
        {
            "Female_Body1_CD",
            "Female_Body1_ND",
            "Female_Body1_NMD",
            "Female_Body1_NMM",
            "Female_Body1_NMP",
            "Female_Body1_NP",
            "Female_Body1_WP",
            "Female_Body2_CD",
            "Female_Body2_ND",
            "Female_Body2_NMD",
            "Female_Body2_NMM",
            "Female_Body2_NMP",
            "Female_Body2_NP",
            "Female_Body2_WP",
            "Female_Body3_CD",
            "Female_Body3_ND",
            "Female_Body3_NMD",
            "Female_Body3_NMM",
            "Female_Body3_NMP",
            "Female_Body3_NP",
            "Female_Body3_WP",
            "Female_Body4_CD",
            "Female_Body4_ND",
            "Female_Body4_NMD",
            "Female_Body4_NMM",
            "Female_Body4_NMP",
            "Female_Body4_NP",
            "Female_Body4_WP",
            "Female_Body5_CD",
            "Female_Body5_ND",
            "Female_Body5_NMD",
            "Female_Body5_NMM",
            "Female_Body5_NMP",
            "Female_Body5_NP",
            "Female_Body5_WP"

        };


    private List<string> spriteBodyMasterList = new List<string>()
        {
            "FEML-ND",
            "FEML-NMD",
            "FEML-NMM",
            "FEML-NMP",
            "FEML-NP",
            "FEMM-ND",
            "FEMM-NMD",
            "FEMM-NMM",
            "FEMM-NMP",
            "FEMM-NP",
            "FEMS-ND",
            "FEMS-NMD",
            "FEMS-NMM",
            "FEMS-NMP",
            "FEMS-NP",
            "MALL-ND",
            "MALL-NMD",
            "MALL-NMM",
            "MALL-NMP",
            "MALL-NP",
            "MALM-ND",
            "MALM-NMD",
            "MALM-NMM",
            "MALM-NMP",
            "MALM-NP"
        };




    /// Function updates body shape and face shape to skin tone ---------------------------------
    public void SetSkinTone()
    {
        string bodyCode = bodyShape + skinTone;
        string spriteCode = pixelBody + pixelSkinTone;

        int bodyIndex = bodyShapeMasterList.BinarySearch(bodyCode);
        int spriteIndex = spriteBodyMasterList.BinarySearch(spriteCode);

        bodySprite.sprite = bodyOptions[bodyIndex];
        player.body = bodyOptions[bodyIndex];

        //changes all the scriptable objects
        characterBody.characterBodyParts[0].bodyPart = pixelbodyOptions[spriteIndex];
        bodyManagerUp.SetCharacterBodyClips();
        bodyManagerDown.SetCharacterBodyClips();
        bodyManagerLeft.SetCharacterBodyClips();
        bodyManagerRight.SetCharacterBodyClips();

        noseCustomizer.SetNose();
        mouthCustomizer.SetLip();

    }

    public void SetSkinCoolDeep()
    {
        skinTone = "CD";
        pixelSkinTone = "ND";

        noseCustomizer.noseSkintone = "CD-";
        mouthCustomizer.mouthSkintone = "CD-";

        SetSkinTone();
    }

    public void SetSkinNeutralDeep()
    {
        skinTone = "ND";
        pixelSkinTone = "ND";
        
        noseCustomizer.noseSkintone = "ND-";
        mouthCustomizer.mouthSkintone = "ND-";

        SetSkinTone();
    }

    public void SetSkinNeutralMediumDeep()
    {
        skinTone = "NMD";
        pixelSkinTone = "NMD";

        noseCustomizer.noseSkintone = "NMD-";
        mouthCustomizer.mouthSkintone = "NMD-";

        SetSkinTone();
    }

    public void SetSkinNeutralMediumMedium()
    {
        skinTone = "NMM";
        pixelSkinTone = "NMM";

        noseCustomizer.noseSkintone = "NMM-";
        mouthCustomizer.mouthSkintone = "NMM-";

        SetSkinTone();
    }

    public void SetSkinNeutralMediumPale()
    {
        skinTone = "NMP";
        pixelSkinTone = "NMP";

        noseCustomizer.noseSkintone = "NMP-";
        mouthCustomizer.mouthSkintone = "NMP-";

        SetSkinTone();
    }

    public void SetSkinNeutralPale()
    {
        skinTone = "NP";
        pixelSkinTone = "NP";

        noseCustomizer.noseSkintone = "NP-";
        mouthCustomizer.mouthSkintone = "NP-";

        SetSkinTone();
    }

    public void SetSkinWarmPale()
    {
        skinTone = "WP";
        pixelSkinTone = "NP";

        noseCustomizer.noseSkintone = "WP-";
        mouthCustomizer.mouthSkintone = "WP-";

        SetSkinTone();
    }


    //Function updates body shape
    public void SetBodyShape()
    {
        string bodyCode = bodyShape + skinTone;
        int bodyIndex = bodyShapeMasterList.BinarySearch(bodyCode);
        string spriteCode = pixelBody + skinTone;
        int spriteIndex = spriteBodyMasterList.BinarySearch(spriteCode);
        
        bodySprite.sprite = bodyOptions[bodyIndex];
        player.body = bodyOptions[bodyIndex];

        characterBody.characterBodyParts[0].bodyPart = pixelbodyOptions[spriteIndex];
        bodyManagerUp.SetCharacterBodyClips();
        bodyManagerDown.SetCharacterBodyClips();
        bodyManagerLeft.SetCharacterBodyClips();
        bodyManagerRight.SetCharacterBodyClips();

        topCustomizer.SetTop();

        if (bottomGameObject.activeInHierarchy == true)
        {
            bottomCustomizer.SetBottom();
        } 
        else
        {
            onePieceCustomizer.SetOnePiece();
        }
        
    }


    public void SetFemaleBody1()
    {
        bodyShape = "Female_Body1_";
        pixelBody = "FEMS-";

        topCustomizer.spriteTopSize = "Medium";
        topCustomizer.topSize = "Body1";
        topCustomizer.topGender = "Female";

        bottomCustomizer.spriteBottomSize = "Medium";
        bottomCustomizer.bottomSize = "Body1";
        bottomCustomizer.bottomGender = "Female";

        onePieceCustomizer.spriteOnePieceSize = "Medium";
        onePieceCustomizer.onePieceSize = "Body1";
        onePieceCustomizer.onePieceGender = "Female";

        SetBodyShape();
    }

    public void SetFemaleBody2()
    {
        bodyShape = "Female_Body2_";
        pixelBody = "FEMM-";

        topCustomizer.spriteTopSize = "Medium";
        topCustomizer.topSize = "Body2";
        topCustomizer.topGender = "Female";

        bottomCustomizer.spriteBottomSize = "Medium";
        bottomCustomizer.bottomSize = "Body2";
        bottomCustomizer.bottomGender = "Female";

        onePieceCustomizer.spriteOnePieceSize = "Medium";
        onePieceCustomizer.onePieceSize = "Body2";
        onePieceCustomizer.onePieceGender = "Female";

        SetBodyShape();

    }

    public void SetFemaleBody3()
    {
        bodyShape = "Female_Body3_";
        pixelBody = "FEMM-";

        topCustomizer.spriteTopSize = "Medium";
        topCustomizer.topSize = "Body2";
        topCustomizer.topGender = "Female";

        bottomCustomizer.spriteBottomSize = "Medium";
        bottomCustomizer.bottomSize = "Body2";
        bottomCustomizer.bottomGender = "Female";

        onePieceCustomizer.spriteOnePieceSize = "Medium";
        onePieceCustomizer.onePieceSize = "Body2";
        onePieceCustomizer.onePieceGender = "Female";

        SetBodyShape();

    }

    public void SetFemaleBody4()
    {
        bodyShape = "Female_Body4_";
        pixelBody = "FEMM-";

        topCustomizer.spriteTopSize = "Medium";
        topCustomizer.topSize = "Body4";
        topCustomizer.topGender = "Female";

        bottomCustomizer.spriteBottomSize = "Medium";
        bottomCustomizer.bottomSize = "Body4";
        bottomCustomizer.bottomGender = "Female";

        onePieceCustomizer.spriteOnePieceSize = "Medium";
        onePieceCustomizer.onePieceSize = "Body4";
        onePieceCustomizer.onePieceGender = "Female";

        SetBodyShape();
    }

    public void SetFemaleBody5()
    {
        bodyShape = "Female_Body5_";
        pixelBody = "FEML-";

        topCustomizer.spriteTopSize = "Large";
        topCustomizer.topSize = "Body5";
        topCustomizer.topGender = "Female";

        bottomCustomizer.spriteBottomSize = "Large";
        bottomCustomizer.bottomSize = "Body5";
        bottomCustomizer.bottomGender = "Female";

        onePieceCustomizer.spriteOnePieceSize = "Large";
        onePieceCustomizer.onePieceSize = "Body5";
        onePieceCustomizer.onePieceGender = "Female";

        SetBodyShape();
    }

    

}
