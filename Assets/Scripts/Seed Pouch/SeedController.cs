using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Collections.Generic;

public class SeedController : MonoBehaviour
{
    [SerializeField]
    private CropInformation cropInfo;

    [SerializeField]
    private SeedMouseFollower seedMouseFollower;

    [SerializeField]
    private SeedUI[] freshbudSeeds;

    private void Start()
    {
        SubscribeFreshbud();
    }

    private void HandleSeedSelection(SeedUI seedUI)
    {
        Sprite seedSprite = seedUI.seed.plant.crop.Image;
        string seedName = seedUI.seed.plant.crop.Name;
        List<Sprite> companionSprite = new List<Sprite>();
        List<Sprite> antagonistSprite = new List<Sprite>();

        int companionLength = seedUI.seed.plant.companionPlants.Length;
        int antagonistLength = seedUI.seed.plant.antagonistPlants.Length;

        for (int i = 0; i < companionLength; i++)
        {
            Sprite comSprite;

            comSprite = seedUI.seed.plant.companionPlants[i].crop.Image;
            companionSprite.Add(comSprite);
        }

        for (int i = 0; i < antagonistLength; i++)
        {
            Sprite antSprite;

            antSprite = seedUI.seed.plant.antagonistPlants[i].crop.Image;
            antagonistSprite.Add(antSprite);
        }
        cropInfo.SetCropInfo(seedSprite, seedName, companionSprite, antagonistSprite);
    }

    private void SubscribeFreshbud()
    {
        ClearSubscription();

        for (int i = 0; i < 10; i++)
        {
            freshbudSeeds[i].OnSeedClicked += HandleSeedSelection;
            freshbudSeeds[i].OnSeedBeginDrag += HandleDragging;
            freshbudSeeds[i].OnSeedEndDrag += HandleEndDrag;
            freshbudSeeds[i].OnSeedDroppedOn += HandleDroppedOn;  
        }
    }

    private void HandleEndDrag(SeedUI obj)
    {
        seedMouseFollower.Toggle(false);
    }

    private void HandleDroppedOn(SeedUI obj)
    {
        throw new NotImplementedException();
    }

    private void HandleDragging(SeedUI seed)
    {
        seedMouseFollower.Toggle(true);
        seedMouseFollower.SetData(seed);
    }

    private void SubscribeBloom()
    {

    }

    private void ClearSubscription()
    {
        for (int i = 0; i < 10; i++)
        {
            freshbudSeeds[i].OnSeedClicked -= HandleSeedSelection;
            freshbudSeeds[i].OnSeedBeginDrag -= HandleDragging;
            freshbudSeeds[i].OnSeedDroppedOn -= HandleDroppedOn;
            freshbudSeeds[i].OnSeedEndDrag -= HandleEndDrag;
        }
    }

}
