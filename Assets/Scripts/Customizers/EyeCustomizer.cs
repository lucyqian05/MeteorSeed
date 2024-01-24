using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeCustomizer : MonoBehaviour
{
	public BodyManager bodyManagerUp;
	public BodyManager bodyManagerDown;
	public BodyManager bodyManagerLeft;
	public BodyManager bodyManagerRight;

	[Header("Scriptable Object")]
	public SO_CharacterBody characterBody;
	public SO_Player player;

	[Header("Pixel Eyes")]
	public List<SO_BodyPart> pixelEyesOptions = new List<SO_BodyPart>();

	[Header("Sprite To Change")]
	public SpriteRenderer eyeSprite;

	[Header("Eyes")]
	public List<Sprite> eyeOptions = new List<Sprite>();

	//Variables used to hold the name of the current customized selection 
	string eyeStyle = "Default";
	string eyeColor = "Athena";


	private static List<string> eyeMasterList = new List<string>()
	{
		"DefaultAmetrine",
		"DefaultArctic",
		"DefaultAthena",
		"DefaultBloodstone",
		"DefaultCatseye",
		"DefaultGalaxy",
		"DefaultGold",
		"DefaultJade",
		"DefaultSeafoam",
		"DefaultSunset"
	};

	private static List<string> pixelEyesList = new List<string>()
	{
		"Ametrine",
		"Arctic",
		"Athena",
		"Bloodstone",
		"Catseye",
		"Galaxy",
		"Gold",
		"Jade",
		"Seafoam",
		"Sunset"
	};



	public void SetEye()
		{
			string eyeCode = eyeStyle + eyeColor;
			int eyeIndex = eyeMasterList.BinarySearch(eyeCode);
			
			eyeSprite.sprite = eyeOptions[eyeIndex];
			player.eyes = eyeOptions[eyeIndex];

			int pixelEyesIndex = pixelEyesList.BinarySearch(eyeColor);
			characterBody.characterBodyParts[1].bodyPart = pixelEyesOptions[pixelEyesIndex];
			bodyManagerUp.SetCharacterBodyClips();
			bodyManagerDown.SetCharacterBodyClips();
			bodyManagerLeft.SetCharacterBodyClips();
			bodyManagerRight.SetCharacterBodyClips();

	}


	//Functions for buttons to change eye color
	public void SetEyeColorAmetrine()
	{
		eyeColor = "Ametrine";
		SetEye();
	}

	public void SetEyeColorArctic()
	{
		eyeColor = "Arctic";
		SetEye();
	}

	public void SetEyeColorAthena()
	{
		eyeColor = "Athena";
		SetEye();
	}

	public void SetEyeColorBloodstone()
	{
		eyeColor = "Bloodstone";
		SetEye();
	}

	public void SetEyeColorCatseye()
	{
		eyeColor = "Catseye";
		SetEye();
	}

	public void SetEyeColorGalaxy()
	{
		eyeColor = "Galaxy";
		SetEye();
	}

	public void SetEyeColorGold()
	{
		eyeColor = "Gold";
		SetEye();
	}

	public void SetEyeColorJade()
	{
		eyeColor = "Jade";
		SetEye();
	}

	public void SetEyeColorSeafoam()
	{
		eyeColor = "Seafoam";
		SetEye();
	}

	public void SetEyeColorSunset()
	{
		eyeColor = "Sunset";
		SetEye();
	}



	// Functions to change the eye shape
	public void SetEyeStyleDefault()
	{
		eyeStyle = "Default";
		SetEye();
	}

	public void SetEyeStyleExcited()
	{
		eyeStyle = "Excited";
		SetEye();
	}

	public void SetEyeStyleSad()
	{
		eyeStyle = "Sad";
		SetEye();
	}

	public void SetEyeStyleBubbly()
	{
		eyeStyle = "Bubbly";
		SetEye();
	}

	public void SetEyeStyleDeadpan()
	{
		eyeStyle = "Deadpan";
		SetEye();
	}

	public void SetEyeStyleSharp()
	{
		eyeStyle = "Sharp";
		SetEye();
	}

	public void SetEyeStyleCheerful()
	{
		eyeStyle = "Cheerful";
		SetEye();
	}

	public void SetEyeStyleSomber()
	{
		eyeStyle = "Somber";
		SetEye();
	}

	public void SetEyeStyleMad()
	{
		eyeStyle = "Mad";
		SetEye();
	}

	public void SetEyeStyleCalm()
	{
		eyeStyle = "Calm";
		SetEye();
	}

}
