using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class SO_Seed : ScriptableObject
{

    [field: SerializeField]
    public string seedName { get; set; }

    [field: SerializeField]
    public Sprite seedSprite { get; set; }

    [field: SerializeField]
    public SO_Plant plant { get; set; }

    [field: SerializeField]
    public int buyPrice { get; set; }

    [field: SerializeField]
    public int sellPrice { get; set; }

}