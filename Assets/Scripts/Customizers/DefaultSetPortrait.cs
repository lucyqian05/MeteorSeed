using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSetPortrait : MonoBehaviour
{
    [Header("Player Scriptable Object")]
    public SO_Player player;

    [Header("Main Body Portrait Sprites")]
    public SpriteRenderer accessories;
    public SpriteRenderer hairFront;
    public SpriteRenderer eyebrows;
    public SpriteRenderer eyes;
    public SpriteRenderer nose;
    public SpriteRenderer mouth;
    public SpriteRenderer bottom;
    public SpriteRenderer onePiece;
    public SpriteRenderer top;
    public SpriteRenderer body;
    public SpriteRenderer hairBack; 

    void Start()
    {

        accessories.sprite = player.accessories; 
        hairFront.sprite = player.hairFront;
        eyebrows.sprite = player.eyebrows;
        eyes.sprite = player.eyes;
        nose.sprite = player.nose;
        mouth.sprite = player.mouth;
        bottom.sprite = player.bottom;
        onePiece.sprite = player.onePiece;
        top.sprite = player.top;
        body.sprite = player.body;
        hairBack.sprite = player.hairBack; 


    }

    
}
