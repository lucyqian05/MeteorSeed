using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
{
    [SerializeField]
    private Slider HPSlider;

    [SerializeField]
    private GameObject StatusTextUI; 

    public void UpdateHealth(float percentHP)
    {
        HPSlider.value = percentHP;
    }
}
