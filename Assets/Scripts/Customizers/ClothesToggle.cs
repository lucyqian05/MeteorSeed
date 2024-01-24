using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesToggle : MonoBehaviour
{
    //portraits
    public SpriteRenderer topPortrait;
    public SpriteRenderer pantsPortrait;
    public SpriteRenderer onePiecePortrait;
    
    //sprites
    public SpriteRenderer topDownSprite;
    public SpriteRenderer pantsDownSprite;
    public SpriteRenderer topLeftSprite;
    public SpriteRenderer pantsLeftSprite;
    public SpriteRenderer topRightSprite;
    public SpriteRenderer pantsRightSprite;
    public SpriteRenderer topUpSprite;
    public SpriteRenderer pantsUpSprite;




    public void ToggleClothes()
    {
        if (topPortrait.GetComponent<SpriteRenderer>().enabled == true)
        {
            topPortrait.GetComponent<SpriteRenderer>().enabled = false;
            pantsPortrait.GetComponent<SpriteRenderer>().enabled = false;
            onePiecePortrait.GetComponent<SpriteRenderer>().enabled = false;

            topDownSprite.GetComponent<SpriteRenderer>().enabled = false;
            pantsDownSprite.GetComponent<SpriteRenderer>().enabled = false;

            topLeftSprite.GetComponent<SpriteRenderer>().enabled = false;
            pantsLeftSprite.GetComponent<SpriteRenderer>().enabled = false;

            topRightSprite.GetComponent<SpriteRenderer>().enabled = false;
            pantsRightSprite.GetComponent<SpriteRenderer>().enabled = false;

            topUpSprite.GetComponent<SpriteRenderer>().enabled = false;
            pantsUpSprite.GetComponent<SpriteRenderer>().enabled = false;

        } else {
            
            topPortrait.GetComponent<SpriteRenderer>().enabled = true;
            pantsPortrait.GetComponent<SpriteRenderer>().enabled = true;
            onePiecePortrait.GetComponent<SpriteRenderer>().enabled = true;

            topDownSprite.GetComponent<SpriteRenderer>().enabled = true;
            pantsDownSprite.GetComponent<SpriteRenderer>().enabled = true;

            topLeftSprite.GetComponent<SpriteRenderer>().enabled = true;
            pantsLeftSprite.GetComponent<SpriteRenderer>().enabled = true;

            topRightSprite.GetComponent<SpriteRenderer>().enabled = true;
            pantsRightSprite.GetComponent<SpriteRenderer>().enabled = true;

            topUpSprite.GetComponent<SpriteRenderer>().enabled = true;
            pantsUpSprite.GetComponent<SpriteRenderer>().enabled = true;

        }
    }


}
