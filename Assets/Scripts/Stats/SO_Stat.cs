using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SO_Stat : MonoBehaviour
{
    [field: SerializeField]
    public int CurrentHealth { get; private set; } = 10;

    [field: SerializeField]
    public int TotalHealth { get; private set; } = 10;

    public event Action<int> OnHealthModified;

    public void ModifyHealth(int hpChange)
    {
<<<<<<< HEAD
        CurrentHealth += hpChange;
        OnHealthModified?.Invoke(hpChange);
=======
        currentHP = maxHP;
        InformAboutChange();
    }
    private float GetHPPercent()
    {
        float percentHP;
        float currentHPFloat = (float)currentHP;
        float maxHPFloat = (float)maxHP;
        percentHP = currentHPFloat / maxHPFloat;
        return percentHP;
    }
    public void ModifyHP(int hpModifier)
    {
        hpModifier += currentHP;
        InformAboutChange();
    }

    private void InformAboutChange()
    {
        OnHpUpdated?.Invoke(GetHPPercent());
>>>>>>> parent of b6291be (Inventory Update)
    }
}
