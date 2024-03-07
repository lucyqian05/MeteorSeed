using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_PlayerStatHealthModifier : SO_PlayerStatModifier
{
    public override void AffectPlayer(GameObject player, float val)
    {
        StatController health = player.GetComponent<StatController>();

        if (health != null)
            health.ModifyHealth((int)val);
    }
}
