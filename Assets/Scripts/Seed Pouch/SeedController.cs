using UnityEngine;
using System;
using System.Collections.Generic;

public class SeedController : MonoBehaviour
{
    [SerializeField]
    private CropInformation cropInfo;

    [SerializeField]
    private SeedPouchUI seedPouchUI;

    [SerializeField]
    private SeedMouseFollower seedMouseFollower;

    [SerializeField]
    private SeedUI[] freshbudSeeds;

    [SerializeField]
    private SeedUI[] bloomSeeds;

    public Action<SeedUI> SeedDropped;

    public TimeEventManager timeEventManager;

    private string currentSeason; 

    private void Start()
    {
        seedPouchUI.OnFreshbud += SubscribeFreshbud;
        seedPouchUI.OnBloom += SubscribeBloom;
    }

    public void OpenToCurrentSeason()
    {
        currentSeason = timeEventManager.currentSeason;
        
        if(currentSeason == "Freshbud")
        {
            SubscribeFreshbud();
            seedPouchUI.FreshbudTab();
        }
        else if(currentSeason == "Bloom")
        {
            SubscribeBloom();
            seedPouchUI.BloomTab();
        }
        else if (currentSeason == "Glowlush")
        {
            SubscribeGlowlush();
            seedPouchUI.GlowlushTab();
        }
        else if (currentSeason == "Sparktip")
        {
            SubscribeSparktip();
            seedPouchUI.SparktipTab();
        }
        else
        {
            SubscribeFreshbud();
            seedPouchUI.FreshbudTab();
        }
    }

    private void SubscribeFreshbud()
    {
        ClearSubscription();
        for (int i = 0; i < 10; i++)
        {
            freshbudSeeds[i].OnSeedClicked += HandleSeedSelection;
            freshbudSeeds[i].OnSeedBeginDrag += HandleSeedSelection;
            freshbudSeeds[i].OnSeedBeginDrag += HandleDragging;
            freshbudSeeds[i].OnSeedEndDrag += HandleEndDrag;
            freshbudSeeds[i].OnSeedDroppedOn += HandleDroppedOn;  
        }
    }

    private void SubscribeBloom()
    {
        ClearSubscription();
        for (int i = 0; i < 10; i++)
        {
            bloomSeeds[i].OnSeedClicked += HandleSeedSelection;
            bloomSeeds[i].OnSeedBeginDrag += HandleSeedSelection;
            bloomSeeds[i].OnSeedBeginDrag += HandleDragging;
            bloomSeeds[i].OnSeedEndDrag += HandleEndDrag;
            bloomSeeds[i].OnSeedDroppedOn += HandleDroppedOn;
        }
    }

    private void SubscribeGlowlush()
    {
        throw new NotImplementedException();
    }

    private void SubscribeSparktip()
    {
        throw new NotImplementedException();
    }
    private void ClearSubscription()
    {
        for (int i = 0; i < 10; i++)
        {
            freshbudSeeds[i].OnSeedClicked -= HandleSeedSelection;
            freshbudSeeds[i].OnSeedBeginDrag -= HandleSeedSelection;
            freshbudSeeds[i].OnSeedBeginDrag -= HandleDragging;
            freshbudSeeds[i].OnSeedDroppedOn -= HandleDroppedOn;
            freshbudSeeds[i].OnSeedEndDrag -= HandleEndDrag;

            bloomSeeds[i].OnSeedClicked -= HandleSeedSelection;
            bloomSeeds[i].OnSeedBeginDrag -= HandleSeedSelection;
            bloomSeeds[i].OnSeedBeginDrag -= HandleDragging;
            bloomSeeds[i].OnSeedEndDrag -= HandleEndDrag;
            bloomSeeds[i].OnSeedDroppedOn -= HandleDroppedOn;
        }
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
    private void HandleDragging(SeedUI seed)
    {
        seedMouseFollower.Toggle(true);
        seedMouseFollower.SetData(seed);
    }

    private void HandleEndDrag(SeedUI obj)
    {
        seedMouseFollower.Toggle(false);
    }

    private void HandleDroppedOn(SeedUI seed)
    {
        SeedDropped?.Invoke(seed);
    }


}
