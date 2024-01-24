using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class SO_Player : ScriptableObject
{

    // Holds information about the player including the name, pronouns, and portrait 

    public string playerName;
    public string subjectivePronoun;
    public string objectivePronoun;
    public string possessivePronoun;
    public string reflexivePronoun;

    [Header("Accessories")]
    public Sprite accessories;

    [Header("Hair")]
    public Sprite hairFront;
    public Sprite hairBack;

    [Header("Face")]
    public Sprite eyebrows;
    public Sprite eyes;
    public Sprite nose;
    public Sprite mouth;

    [Header("Clothes")]
    public Sprite bottom;
    public Sprite onePiece;
    public Sprite top;

    [Header("Body")]
    public Sprite body;



    public bool isName = false;
    public bool portraitChanged = true;




    public void PortraitChangedFalse()
    {

        portraitChanged = false; 

    }

    public void PortraitChangedTrue()
    {

        portraitChanged = true;

    }

}