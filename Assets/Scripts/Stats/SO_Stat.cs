using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SO_Stat : ScriptableObject
{
    [field: SerializeField]
    private int currentHP;

    [field: SerializeField]
    private int maxHP;

    public event Action<float> OnHpUpdated;

    public void ResetHealth()
    {
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
        currentHP += hpModifier;
        InformAboutChange();
    }

    private void InformAboutChange()
    {
        OnHpUpdated?.Invoke(GetHPPercent());
    }
}
