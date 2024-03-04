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
        CurrentHealth += hpChange;
        OnHealthModified?.Invoke(hpChange);
    }
}
