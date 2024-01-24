using System.Collections.Generic;
using UnityEngine;

public class BodyManager : MonoBehaviour
{
    
    //Strings in the inspector to create the key for the AnimataionClipOverrides lookup. MUST BE SORTED!!! 
    public string[] bodyPartTypes;
    public string[] characterStates;
    public string[] characterDirections;

    //Put the scriptable object of the character body in here
    public SO_CharacterBody characterBody;

    //Animations
    private Animator animator;
    private AnimationClip animationClip;
    public AnimatorOverrideController animatorOverrideController;
    public AnimationClipOverrides defaultAnimationClips;


    //These are private lists which hold the animation clips of the new override(SO_CharacterBodyClips) and the key look up for the defaultAnimationClipsName.
    //If this isn't working, expose this to public and and use the debug to see if these lists are nu11 or are filling properly 
    private List<AnimationClip> SO_CharacterBodyClips = new List<AnimationClip>();
    private List<string> defaultAnimationClipsNames = new List<string>();

    void Start()
    {
        animator = GetComponent<Animator>();
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        defaultAnimationClips = new AnimationClipOverrides(animatorOverrideController.overridesCount);
        animatorOverrideController.GetOverrides(defaultAnimationClips);

        SetCharacterBodyClips();

    }

    //This function updates the entire playersprite 
    public void SetCharacterBodyClips()
    {

        //This loop adds all the animation clips from all the body parts into one list
        for (int i = 0; i < characterBody.characterBodyParts.Length; i++)
        {

            SO_CharacterBodyClips.AddRange(characterBody.characterBodyParts[i].bodyPart.allBodyPartAnimations);

        }


        //This loop creates a list of all the keys for the default animation clips 
        for (int partIndex = 0; partIndex < characterBody.characterBodyParts.Length; partIndex++)
        {
            string partType = bodyPartTypes[partIndex]; 

            for (int stateIndex = 0; stateIndex < characterStates.Length; stateIndex++)
            {
                string state = characterStates[stateIndex]; 

                for (int directionIndex = 0; directionIndex < characterDirections.Length; directionIndex++)
                {
                    string direction = characterDirections[directionIndex];

                    string clipName = partType + "_" + "Default" + "_" + state + "_" + direction;

                    defaultAnimationClipsNames.Add(clipName);
                }
            }
        }

        //this loop replaces each value with the associated defaultAnimationClips key
        for (int i = 0; i < SO_CharacterBodyClips.Count; i++)
        {
            defaultAnimationClips[defaultAnimationClipsNames[i]] = SO_CharacterBodyClips[i];
        }

        //this is the official override for the aniamtion clips 
        animatorOverrideController.ApplyOverrides(defaultAnimationClips);

    }


    //This is part of the unity documentation which creates a dictionary for the animation override. do not touch! 
    public class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
    {
        public AnimationClipOverrides(int capacity) : base(capacity) { }

        public AnimationClip this[string name]
        {
            get { return this.Find(x => x.Key.name.Equals(name)).Value; }
            set
            {
                int index = this.FindIndex(x => x.Key.name.Equals(name));
                if (index != -1)
                    this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
            }
        }
    }






 }
