using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController : MonoBehaviour
{
    [SerializeField]
    private StatUI statUI;

    [SerializeField]
    private SO_Stat statData;
    public void Start()
    {
        PrepareHP();
    }

    private void PrepareHP()
    {
        statData.OnHpUpdated += UpdateHealthUI;
        statData.ResetHealth();
    }

    private void UpdateHealthUI(float hpPercent)
    {
        statUI.UpdateHealth(hpPercent);
    }

    public void ModifyHealth(int value)
    {
        statData.ModifyHP(value);
    }

}
