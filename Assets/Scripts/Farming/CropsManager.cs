using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropsManager : MonoBehaviour
{
    [SerializeField]
    public Dictionary<Vector3Int, Plant> cropManager = new Dictionary<Vector3Int, Plant>();
}
